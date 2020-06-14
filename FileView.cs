using Spire.Pdf;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.ComponentModel;

namespace OCR
{
	public partial class FileView : Form
	{
		readonly MainForm caller;
		readonly BackgroundWorker bw;

		public FileView(MainForm f, string path)
		{
			caller = f;
			InitializeComponent();
			RenderDocument(path);
			bw = new BackgroundWorker();
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
			var output = ModelConsumer.PredictDigit(ImageProcessor.ConvertImageToData(@"E:\2.bmp"));
			MessageBox.Show(output.Prediction.ToString());
		}
	}
}
