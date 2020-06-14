using OCR.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace OCR
{
	public partial class InputDataView : Form
	{
		readonly MainForm caller;
		readonly BackgroundWorker bw;
		string inputFolderPath;
		string outputFilePath;
		string extension;
		int width, height;
		public InputDataView(MainForm f)
		{
			caller = f;
			bw = new BackgroundWorker();
			InitializeComponent();
			pictureBox1.Image = Resources.categories;
			inputTextBox.GotFocus += (s, e) => { MainForm.HideCaret((s as TextBox).Handle); };
			outputTextBox.GotFocus += (s, e) => { MainForm.HideCaret((s as TextBox).Handle); };
		}

		private void InputDataView_FormClosing(object sender, FormClosingEventArgs e)
		{
			caller.DeleteSelfReference(this);
			Dispose();
		}

		private void InputButton_Click(object sender, EventArgs e)
		{
            using var fbd = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop
            };
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                inputTextBox.Text = fbd.SelectedPath;

            }
            else
            {
                inputTextBox.Text = "Select root folder...";
            }
        }

		private void OutputButton_Click(object sender, EventArgs e)
		{
            using var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                RestoreDirectory = true,
                Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true
            };
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputTextBox.Text = ofd.FileName;
            }
            else
            {
                outputTextBox.Text = "Select output file...";
            }
        }

		private void DimensionTextBox_Enter(object sender, EventArgs e)
		{
			var caller = sender as TextBox;
			caller.MaxLength = 2;
			caller.Text = "";
		}

		private void DimensionTextBox_Leave(object sender, EventArgs e)
		{
			var caller = sender as TextBox;
			caller.MaxLength = 5;
			if (caller.Text.Length != 0)
				caller.Text += " px";
			else
				caller.Text += "32 px";
		}

		private void ValidationTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
				e.Handled = true;
			if (e.KeyChar == (char)Keys.Enter)
				groupBox1.Focus();
		}

		private void ExtensionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			groupBox1.Focus();
		}

		private void ConvertDataButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (convertDataButton.Text == "Convert data")
				{
					inputFolderPath = inputTextBox.Text;
					outputFilePath = outputTextBox.Text;
					extension = extensionComboBox.Text.ToString();
					width = int.Parse(widthTextBox.Text.Substring(0, widthTextBox.Text.IndexOf(" ")));
					height = int.Parse(heightTextBox.Text.Substring(0, heightTextBox.Text.IndexOf(" ")));
					if (inputFolderPath.Equals("Select root folder..."))
					{
						MessageBox.Show("Select input data folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else if (outputFilePath.Equals("Select output file..."))
					{
						MessageBox.Show("Select output data file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else if (extension.Equals("..."))
					{
						MessageBox.Show("Select output files extension!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else if (!bw.IsBusy)
					{
						bw.DoWork += DoWork;
						bw.ProgressChanged += ProgressChanged;
						bw.RunWorkerCompleted += WorkCompleted;
						bw.WorkerSupportsCancellation = true;
						bw.WorkerReportsProgress = true;
						bw.RunWorkerAsync();
						convertDataButton.Text = "Cancel";
						inputButton.Enabled = false;
						outputButton.Enabled = false;
						extensionComboBox.Enabled = false;
						widthTextBox.Enabled = false;
						heightTextBox.Enabled = false;
					}
				}
				else
				{
					bw.CancelAsync();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.StackTrace);
			}
		}

		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			inputProgressBar.Value = e.ProgressPercentage;
		}

		private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			convertDataButton.Text = "Convert data";
			inputButton.Enabled = true;
			outputButton.Enabled = true;
			extensionComboBox.Enabled = true;
			widthTextBox.Enabled = true;
			heightTextBox.Enabled = true;
			var error = e.Error;
			if (error != null)
			{
				MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (e.Cancelled)
			{
				inputProgressBar.Value = 0;
				MessageBox.Show("Action was cancelled by user!", "Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else
			{
				MessageBox.Show("Input data is successfully converted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				inputProgressBar.Value = 0;
			}
			bw.DoWork -= DoWork;
			bw.ProgressChanged -= ProgressChanged;
			bw.RunWorkerCompleted -= WorkCompleted;
		}

		private void DoWork(object sender, DoWorkEventArgs e)
		{
			var currentProgress = inputProgressBar.Value;
			var filesProcessed = 0;
			var totalFilesCount = 0;
			var inputDirectories = Directory.GetDirectories(inputFolderPath);
			if (inputDirectories.Length == 0)
				throw new Exception("No categories was found!");
			var labels = new string[inputDirectories.Length];
			for (var i = 0; i < inputDirectories.Length; i++)
				labels[i] = inputDirectories[i].Substring(inputFolderPath.Length + 1);
			for (var i = 0; i < inputDirectories.Length; i++)
			{
				if (bw.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				var inputFilePaths = Directory.GetFiles(inputDirectories[i] + "\\", "*." + extension);
				if (inputFilePaths.Length == 0)
					throw new Exception("No files in category was found!");
				else
					totalFilesCount += inputFilePaths.Length;
			}
			totalFilesCount *= 2;
			for (var k = 0; k < inputDirectories.Length; k++)
			{
				var inputFilePaths = Directory.GetFiles(inputDirectories[k] + "\\", "*." + extension);
				foreach (var inputFP in inputFilePaths)
				{
					if (bw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					if (!ImageProcessor.CutImage(inputFP, width, height))
					{
						throw new Exception("Error processing the image!");
					}
					filesProcessed += 1;
					var progress = 100 * filesProcessed / totalFilesCount;
					if (progress > currentProgress)
						bw.ReportProgress(progress);
				}
			}
			for (int k = 0; k < inputDirectories.Length; k++)
			{
				var inputFilePaths = Directory.GetFiles(inputDirectories[k] + "\\", "*." + extension);
                using var fileStream = File.Open(outputFilePath, FileMode.Append, FileAccess.Write);
                using StreamWriter sw = new StreamWriter(fileStream);
                foreach (var inputFP in inputFilePaths)
                {
                    if (bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    var output = "";
                    var image = new Bitmap(inputFP);
                    var imageWidth = image.Width;
                    var imageHeight = image.Height;
                    var partWidth = imageWidth / 8;
                    var partHeight = imageHeight / 8;
                    for (var j = 0; j < 8; j++)
                    {
                        for (var i = 0; i < 8; i++)
                        {
                            var pixels = ImageProcessor.CountPixels(image, i * partWidth, j * partHeight, (i + 1) * partWidth - 1, (j + 1) * partHeight - 1);
                            output += pixels + ",";
                        }
                    }
                    output += labels[k];
                    sw.WriteLine(output);
                    filesProcessed += 1;
                    var progress = 100 * filesProcessed / totalFilesCount;
                    if (progress > currentProgress)
                        bw.ReportProgress(progress);
                }
            }
		}
	}
}
