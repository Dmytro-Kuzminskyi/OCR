using Spire.Pdf;
using OCR.Properties;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.ComponentModel;
using System.Resources;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace OCR
{
	public partial class FileView : Form
	{
		readonly MainForm caller;
		readonly BackgroundWorker bw;
        DocTemplate? template = null;
		Bitmap convertedImage = null;

        public FileView(MainForm f, string path)
		{
			caller = f;
			InitializeComponent();
			RenderDocument(path);
			bw = new BackgroundWorker();
		}

		private void FileView_Load(object sender, EventArgs e)
		{
			using var templateDialog = new TemplateDialog();
			var result = templateDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				template = templateDialog.docTemplate;
				using var document = new PdfDocument();
				ResourceManager rm = Resources.ResourceManager;
				if (template == DocTemplate.BankReceipt)
					document.LoadFromBytes((byte[])rm.GetObject("BankReceiptBlank"));
				convertedImage = (Bitmap)document.SaveAsImage(0);
			}
			if (result == DialogResult.Cancel)
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
				MaximumSize = new Size(width + 16, height + 39);
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
			caller.CloseFileState();
		}

		private void ConvertButton_Click(object sender, EventArgs e)
		{			
			bw.DoWork += DoWork;
			bw.RunWorkerCompleted += WorkCompleted;
			bw.RunWorkerAsync();
			convertButton.Enabled = false;
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
				//MessageBox.Show("File is successfully converted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			bw.DoWork -= DoWork;
			bw.RunWorkerCompleted -= WorkCompleted;
		}

		private void DoWork(object sender, DoWorkEventArgs e)
		{
			if (template == DocTemplate.BankReceipt)
			{
				using var reader = new StreamReader(
					Path.Combine(Assembly.GetExecutingAssembly().Location, "..", Resources.BANK_RECEIPT_TEMPLATE_PATH));
				var jsonString = reader.ReadToEnd();
				JObject obj = JObject.Parse(jsonString);
				var jsonRow = JArray.Parse(obj["row4"].ToString()).ToArray();
				foreach (var t in jsonRow)
				{
					var locationString = t["location"].ToString().Replace("\r\n", string.Empty);
					var locX = int.Parse(locationString.Substring(locationString.IndexOf(" ") + 2, locationString.IndexOf(",") - locationString.IndexOf(" ") - 2));
					var locY = int.Parse(locationString.Substring(locationString.LastIndexOf(" ") + 1, locationString.IndexOf("]") - locationString.LastIndexOf(" ") - 1));
					var sizeString = t["size"].ToString().Replace("\r\n", string.Empty);
					var sizeX = int.Parse(sizeString.Substring(sizeString.IndexOf(" ") + 2, sizeString.IndexOf(",") - sizeString.IndexOf(" ") - 2));
					var sizeY = int.Parse(sizeString.Substring(sizeString.LastIndexOf(" ") + 1, sizeString.IndexOf("]") - sizeString.LastIndexOf(" ") - 1));
					var type = t["type"].ToString().Trim();
					Replace(type, new Rectangle(new Point(locX, locY), new Size(sizeX, sizeY)));
				}
			}
			else
				throw new Exception("No template implemented");
			documentWrapper.Image = convertedImage;
			Invalidate();
		}

		private void Replace(string type, Rectangle replacementArea)
		{
			string output = null;
			Bitmap bmp = Resources.cell;
			using var g = Graphics.FromImage(bmp);
			g.DrawImage(documentWrapper.Image, new Rectangle(new Point(2, 2), new Size(28, 28)), replacementArea, GraphicsUnit.Pixel);
			if (type == "digit")
				output = ModelConsumer.PredictDigit(ImageProcessor.ConvertImageToData(bmp)).ToString();
			if (type == "letter")
				output = ModelConsumer.PredictLetter(ImageProcessor.ConvertImageToData(bmp)).ToString();
			ImageProcessor.ReplacePrediction(output, convertedImage, replacementArea);
			bmp.Dispose();
		}     
    }
}
