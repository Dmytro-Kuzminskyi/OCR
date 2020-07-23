using OCR.Properties;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace OCR
{
	public partial class ConvertedDocumentView : Form
	{
		readonly MainForm owner;
		readonly FileView caller;
		ToolStripButton convertBtn;
		List<KeyValuePair<string, string>> predictions;
		Image<Bgr, byte> inputImage = null;
		Image<Gray, byte> outputImage = null;
		DocTemplate template;
		List<int> partitions;
		List<Rectangle> BBoxes;
		List<Rectangle> BBoxesScaled;
		Point pointerPosition;
		Region correctArea;
		Size inputImageSize;
		float scaleX, scaleY;
		Bitmap initialImage;
		string path = "";
		bool isSaved = false, isSaveInvoked = false, isCorrectMode = false;
		public ConvertedDocumentView(MainForm o, FileView c, ToolStripButton b, List<KeyValuePair<string, string>> pred, 
			List<int> part, DocTemplate t, Size s, string p)
		{
			owner = o;
			caller = c;
			convertBtn = b;
			predictions = pred;
			partitions = part;
			template = t;
			inputImageSize = s;
			path = p;
			InitializeComponent();
			BBoxes = new List<Rectangle>();
		}

		private void ConvertedDocumentView_Load(object sender, EventArgs e)
		{
			List<Rectangle> tmp = new List<Rectangle>();
			if (template == DocTemplate.PersonEvidence)
            {
				initialImage = Resources.PEF;
			}
			documentWrapper.Size = inputImageSize;
			int width = owner.ClientSize.Width > inputImageSize.Width + 16 ? inputImageSize.Width : owner.ClientSize.Width - 28;
			int height = owner.ClientSize.Height > inputImageSize.Height + 67 ? inputImageSize.Height + 28 : owner.ClientSize.Height - 75;
			ClientSize = new Size(width, height);
			MaximumSize = new Size(width + 16, height + 39);
			inputImage = initialImage.ToImage<Bgr, byte>();
			outputImage = inputImage.Convert<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255));
			VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
			Mat hierarhy = new Mat();
			CvInvoke.FindContours(outputImage, contours, hierarhy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
			Dictionary<int, double> contoursDict = new Dictionary<int, double>();
			for (int i = 0; i < contours.Size; i++)
			{
				double area = CvInvoke.ContourArea(contours[i]);
				contoursDict.Add(i, area);
			}

			var items = contoursDict.OrderByDescending(i => i.Value).Skip(1).Take(predictions.Count);
			foreach (var item in items)
			{
				int key = int.Parse(item.Key.ToString());
				tmp.Add(CvInvoke.BoundingRectangle(contours[key]));
			}
			var skipItemsCount = 0;
			tmp.Sort((item1, item2) => item1.Y.CompareTo(item2.Y));
			partitions.ForEach(part => {
				var items = tmp.Skip(skipItemsCount).Take(part).ToList<Rectangle>();
				items.Sort((item1, item2) => item1.X.CompareTo(item2.X));
				skipItemsCount += part;
				foreach (var bbox in items)
				{
					int w = bbox.Width;
					int h = bbox.Height;
					int x = bbox.X + w / 10;
					int y = bbox.Y + h / 10;
					w -= 2 * w / 10;
					h -= 2 * h / 10;
					BBoxes.Add(new Rectangle(x, y, w, h));
				}
			});
			for (int i = 0; i < predictions.Count; i++)
				ImageProcessor.ReplacePrediction(predictions.ElementAt(i).Value, initialImage, BBoxes.ElementAt(i));
			scaleX = (float)inputImageSize.Width / initialImage.Size.Width;
			scaleY = (float)inputImageSize.Height / initialImage.Size.Height;
			documentWrapper.Image = new Bitmap(initialImage, inputImageSize);
			correctArea = new Region(new Rectangle(new Point(0, 0), documentWrapper.Image.Size));
			tmp = new List<Rectangle>();
			BBoxes.ForEach(bbox =>
			{
				var rect = new Rectangle((int)(bbox.X * scaleX), (int)(bbox.Y * scaleY),
					(int)(bbox.Width * scaleX), (int)(bbox.Height * scaleY));
				tmp.Add(rect);
				correctArea.Exclude(rect); 
			});
			BBoxesScaled = tmp;
		}

		public void InitiateClosing()
        {
			SaveOnClose(null);
			isSaveInvoked = true;
			Close();
        }

		private void ConvertedDocumentView_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!isSaveInvoked)
				SaveOnClose(e);
			if (!e.Cancel)
			{
				Dispose();
				caller.DeleteReference();
				convertBtn.Enabled = true;
			}
		}

		private void SaveOnClose(FormClosingEventArgs e)
        {
			if (!isSaved)
			{
				DialogResult result;
				if (e == null)
                {
					result = MessageBox.Show(null, "Do you want to save document?", "Document is not saved!", 
						MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}
                else
                {
					result = MessageBox.Show(null, "Do you want to save document?", "Document is not saved!", 
						MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				}
				if (result == DialogResult.Yes) {
					SaveAsButton_Click(null, null);
				}
				if (result == DialogResult.Cancel)
					e.Cancel = true;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
        {
			PdfDocument doc = new PdfDocument();
			PdfImage pdfImage = PdfImage.FromImage(documentWrapper.Image);
			PdfUnitConvertor uinit = new PdfUnitConvertor();
			SizeF pageSize = uinit.ConvertFromPixels(documentWrapper.Image.Size, PdfGraphicsUnit.Point);
			PdfPageBase page = doc.Pages.Add(pageSize, new PdfMargins(0f));
			page.Canvas.DrawImage(pdfImage, new PointF(0, 0));
			doc.SaveToFile(path.Insert(path.LastIndexOf(".pdf"), "_converted"));
			isSaved = true;
		}

		private void SaveAsButton_Click(object sender, EventArgs e)
		{
			PdfDocument doc = new PdfDocument();
			PdfImage pdfImage = PdfImage.FromImage(documentWrapper.Image);
			PdfUnitConvertor uinit = new PdfUnitConvertor();
			SizeF pageSize = uinit.ConvertFromPixels(documentWrapper.Image.Size, PdfGraphicsUnit.Point);
			PdfPageBase page = doc.Pages.Add(pageSize, new PdfMargins(0f));
			page.Canvas.DrawImage(pdfImage, new PointF(0, 0));
			using var sfd = new SaveFileDialog();
			sfd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
			sfd.RestoreDirectory = true;
			sfd.CheckPathExists = true;
			sfd.AddExtension = true;
			sfd.DefaultExt = "pdf";
			sfd.Filter = "PDF|*.pdf";
			var result = sfd.ShowDialog();
			if (result == DialogResult.OK)
            {
				doc.SaveToFile(sfd.FileName);
			}
			isSaved = true;
		}

		private void PrintButton_Click(object sender, EventArgs e)
		{
			using var pd = new PrintDialog();
			using var pdoc = new PrintDocument();
			pdoc.DocumentName = Text;
			pdoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
			pdoc.OriginAtMargins = false;
			pdoc.PrintPage += new PrintPageEventHandler(DD_Print);
			pd.Document = pdoc;
			pd.AllowPrintToFile = true;
			pd.AllowSomePages = false;			
			var result = pd.ShowDialog();
			if (result == DialogResult.OK)
			{
				pdoc.Print();
			}
		}

        private void DD_Print(object sender, PrintPageEventArgs e)
		{
			var img = documentWrapper.Image;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(img, e.MarginBounds);
			img.Dispose();
		}

		private void CorrectButton_Click(object sender, EventArgs e)
        {
			isCorrectMode = !isCorrectMode;
			if (correctButton.Text == "Correct")
				correctButton.Text = "Normal";
            else
				correctButton.Text = "Correct";
		}

		private void DocumentWrapper_MouseMove(object sender, MouseEventArgs e)
		{
			pointerPosition = e.Location;
			if (isCorrectMode)
			{
				if (!correctArea.IsVisible(pointerPosition))
					Cursor = Cursors.Hand;
				else
					Cursor = Cursors.Default;
			}
		}

		private void DocumentWrapper_Click(object sender, EventArgs e)
		{
			if (Cursor == Cursors.Hand)
            {				
				var bboxIndex = BBoxesScaled.FindIndex(0, bbox => bbox.Contains(pointerPosition));
				var bbox = BBoxes.ElementAt(bboxIndex);
				var predType = predictions.ElementAt(bboxIndex).Key;
				var predValue = predictions.ElementAt(bboxIndex).Value;
				using var correctionDialog = new CorrectionDialog(predType, predValue);
				var result = correctionDialog.ShowDialog();
				if (result == DialogResult.OK)
                {
					ImageProcessor.ReplacePrediction(correctionDialog.value, initialImage, bbox, true);
					documentWrapper.Image = new Bitmap(initialImage, inputImageSize);
					predictions.RemoveAt(bboxIndex);
					predictions.Insert(bboxIndex, new KeyValuePair<string, string>(predType, correctionDialog.value));
				}
            }
		}
	}
}
