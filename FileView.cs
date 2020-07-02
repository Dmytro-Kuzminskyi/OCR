using Newtonsoft.Json.Linq;
using Spire.Pdf;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using OCR.Properties;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace OCR
{
	public partial class FileView : Form
	{
		Image<Bgr, byte> inputImage = null;
		Image<Gray, byte> outputImage = null;
		int cellCount = 0;
		string filePath = "";
		string templatePath = "";
		List<Rectangle> BBoxes;
		readonly MainForm caller;
		readonly BackgroundWorker bw;
		DocTemplate? template = null;
		Bitmap convertedImage = null;
		ConvertedDocumentView convertedDocumentView = null;

		public FileView(MainForm f, string path)
		{
			caller = f;
			filePath = path;
			InitializeComponent();
			RenderDocument(filePath);
			bw = new BackgroundWorker();
			BBoxes = new List<Rectangle>();
		}

		private void FileView_Load(object sender, EventArgs e)
		{
			string imgPath, tmpPath = "";
			using var templateDialog = new TemplateDialog();
			var result = templateDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				template = templateDialog.docTemplate;
				tmpPath = Path.Combine(Directory.GetCurrentDirectory(), "temp");
				if (!Directory.Exists(tmpPath))
					Directory.CreateDirectory(tmpPath);
				imgPath = Path.Combine(tmpPath, Text + ".jpg");
				using (var img = new Bitmap(documentWrapper.Image))
					img.Save(imgPath);
				inputImage = new Image<Bgr, byte>(imgPath);
				outputImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
				if (template == DocTemplate.PersonEvidence)
				{
					templatePath =  Path.Combine(Directory.GetCurrentDirectory(), Resources.PERSON_EVIDENCE_TEMPLATE_PATH);
				}
				using var reader = new StreamReader(templatePath);
				var jsonString = reader.ReadToEnd();
				var obj = JObject.Parse(jsonString);
				cellCount = int.Parse(obj["cells"].ToString());
				VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
				Mat hierarhy = new Mat();
				CvInvoke.FindContours(outputImage, contours, hierarhy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
				Dictionary<int, double> contoursDict = new Dictionary<int, double>();
				for (int i = 0; i < contours.Size; i++)
				{
					double area = CvInvoke.ContourArea(contours[i]);
					contoursDict.Add(i, area);
				}

				var items = contoursDict.OrderByDescending(i => i.Value).Skip(1).Take(cellCount);
				foreach (var item in items)
				{
					int key = int.Parse(item.Key.ToString());
					BBoxes.Add(CvInvoke.BoundingRectangle(contours[key]));
				}
			}
			else if (result == DialogResult.Cancel || result == DialogResult.Abort)
			{
				BeginInvoke(new MethodInvoker(Close));
			}
			
		}

		public void SetMaximumSize()
		{
			if (documentWrapper.Image != null)
			{
				int width = caller.ClientSize.Width > documentWrapper.Image.Width + 16 ?
					documentWrapper.Image.Width : caller.ClientSize.Width - 28;
				int height = caller.ClientSize.Height > documentWrapper.Image.Height + 67 ?
					documentWrapper.Image.Height + 28 : caller.ClientSize.Height - 75;
				try
				{
					MaximumSize = new Size(width + 16, height + 39);
					if (convertedDocumentView != null)
						convertedDocumentView.MaximumSize = MaximumSize;
				}
				catch (Exception ex) 
				{
					Debug.WriteLine(ex.StackTrace);
				}
			}
		}

		private void RenderDocument(string path)
		{
			using var document = new PdfDocument();
			document.LoadFromFile(path);
			var bmp = (Bitmap)document.SaveAsImage(0);
			documentWrapper.Size = new Size(bmp.Width, bmp.Height);
			documentWrapper.Image = bmp;
			int width = caller.ClientSize.Width > bmp.Width + 16 ? bmp.Width : caller.ClientSize.Width - 28;
			int height = caller.ClientSize.Height > bmp.Height + 67 ? bmp.Height + 28 : caller.ClientSize.Height - 75;
			ClientSize = new Size(width, height);
			MaximumSize = new Size(width + 16, height + 39);
		}

		private void FileView_FormClosing(object sender, FormClosingEventArgs e)
		{
			caller.DeleteSelfReference(this);
			Dispose();
			if (convertedDocumentView != null)
				convertedDocumentView.InitiateClosing();
			caller.CloseFileState();
		}

		public void DeleteReference()
        {
			convertedDocumentView = null;
		}

			private void ConvertButton_Click(object sender, EventArgs e)
		{
			bw.DoWork += DoWork;
			bw.RunWorkerCompleted += WorkCompleted;
			bw.RunWorkerAsync();
			convertButton.Enabled = false;
			if (template == DocTemplate.PersonEvidence)
				convertedImage = Resources.PEF;
		}
		private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var error = e.Error;
			if (error != null)
			{
				MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				convertedDocumentView = new ConvertedDocumentView(caller, this, convertButton, convertedImage, filePath)
				{
					Text = Text,
					Location = new Point(Location.X + 50, Location.Y + 25),
					MdiParent = caller
				};
				convertedDocumentView.Show();
				MessageBox.Show("File is successfully converted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			bw.DoWork -= DoWork;
			bw.RunWorkerCompleted -= WorkCompleted;
		}

		private void DoWork(object sender, DoWorkEventArgs e)
		{
			BBoxes.Sort((item1, item2) => item1.Y.CompareTo(item2.Y));
			using var reader = new StreamReader(templatePath);
			ParseJSON(reader);			
		}

		private void ParseJSON(StreamReader reader)
		{
			var jsonString = reader.ReadToEnd();
			var obj = JObject.Parse(jsonString);			
			var jsonRow = JArray.Parse(obj["template"].ToString()).ToArray();
			int skipItemsCount = 0;
			foreach (var t in jsonRow)
			{
				var type = t["type"].ToString();
				var count = int.Parse(t["count"].ToString());
				var items = BBoxes.Skip(skipItemsCount).Take(count);
				skipItemsCount += count;
				foreach (var item in items) 
				{
					Replace(type, item);
				}
			}
		}

		private void Replace(string type, Rectangle replacementArea)
		{
			string output;
			Bitmap preprocessedImage;
			Bitmap bmp = new Bitmap(Resources.cell, new Size(32, 32));
			using var g = Graphics.FromImage(bmp);
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.DrawImage(outputImage.ToBitmap(), new Rectangle(new Point(0, 0), new Size(32, 32)), replacementArea, GraphicsUnit.Pixel);
			preprocessedImage = ImageProcessor.PrepareImage(bmp);
			if (type == "digit")
			{
				output = ModelConsumer.PredictDigit(ImageProcessor.ConvertImageToData(preprocessedImage));
				ImageProcessor.ReplacePrediction(output, convertedImage, replacementArea);
			}
			else if (type == "letter")
			{
				output = ModelConsumer.PredictLetter(ImageProcessor.ConvertImageToData(preprocessedImage));
				ImageProcessor.ReplacePrediction(output, convertedImage, replacementArea);
			}
			else if (type == "selector")
            {
				ImageProcessor.ReplaceSelector(convertedImage, replacementArea);
            }
			bmp.Dispose();
		}
	}
}
