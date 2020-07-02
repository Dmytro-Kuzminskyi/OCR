using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace OCR
{
	public partial class ConvertedDocumentView : Form
	{
		readonly MainForm owner;
		readonly FileView caller;
		ToolStripButton convertBtn;
		string path = "";
		bool isSaved = false, isSaveInvoked = false;
		public ConvertedDocumentView(MainForm o, FileView c, ToolStripButton b, Bitmap img, string p)
		{
			owner = o;
			caller = c;
			convertBtn = b;
			path = p;
			InitializeComponent();
			documentWrapper.Size = new Size(img.Width, img.Height);
			documentWrapper.Image = img;
			int width = owner.ClientSize.Width > img.Width + 16 ? img.Width : owner.ClientSize.Width - 28;
			int height = owner.ClientSize.Height > img.Height + 67 ? img.Height + 28 : owner.ClientSize.Height - 75;
			ClientSize = new Size(width, height);
			MaximumSize = new Size(width + 16, height + 39);
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
			//double cmToUnits = 100 / 2.54;
			var img = documentWrapper.Image;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(img, e.MarginBounds);
			img.Dispose();
		}
	}
}
