using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OCR
{
	public partial class MainForm : Form
	{
		[DllImport("user32")]
		public static extern bool HideCaret(IntPtr hWnd);

		InputDataView inputDataView = null;
		ManagementView managementView = null;
		FileView fileView = null;
		bool isFileOpened = false;

		public MainForm()
		{
			InitializeComponent();
		}

		public void CloseFileState()
        {
			isFileOpened = false;
        }

		public void DeleteSelfReference(Form f)
		{
			if (f == inputDataView)
				inputDataView = null;
			if (f == managementView)
				managementView = null;
			if (f == fileView)
				fileView = null;
		}

		private void FileButton_Click(object sender, EventArgs e)
		{ 
			fileMenuStrip.Show(Left + topToolStrip.Left + 8, Top + topToolStrip.Top + 2 * topToolStrip.Height + 6);
		}

		private void OpenFileButton_Click(object sender, EventArgs e)
        {
			if (!isFileOpened)
			{
				using var ofd = new OpenFileDialog()
				{
					InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
					RestoreDirectory = true,
					Multiselect = false,
					CheckFileExists = true,
					CheckPathExists = true,
					Filter = "PDF|*.pdf|All Files|*.*",
					DefaultExt = "*.pdf",
					FilterIndex = 0
				};
				var result = ofd.ShowDialog();
				if (result == DialogResult.OK)
				{
					if (fileView == null)
					{
						fileView = new FileView(this, ofd.FileName)
						{
							TopLevel = false,
							Text = Path.GetFileNameWithoutExtension(ofd.FileName)
						};
						fileView.MdiParent = this;
						fileView.Show();
						isFileOpened = true;
					}
				}
			}
        }

		private void ModelButton_Click(object sender, EventArgs e)
		{
			modelMenuStrip.Show(fileButton.Size.Width + Left + topToolStrip.Left + 8, Top + topToolStrip.Top + 2 * topToolStrip.Height + 6);
		}

		private void InputDataButton_Click(object sender, EventArgs e)
		{
			if (inputDataView == null)
			{
				inputDataView = new InputDataView(this)
				{
					TopLevel = false,
				};
				inputDataView.MdiParent = this;				
				inputDataView.Show();
			}
		}

		private void ManagementButton_Click(object sender, EventArgs e)
		{
			if (managementView == null)
			{
				managementView = new ManagementView(this)
				{
					TopLevel = false
				};
				managementView.MdiParent = this;
				managementView.Show();
			}
		}

        private void MainForm_Resize(object sender, EventArgs e)
        {
			if (fileView != null)
				fileView.SetMaximumSize();
		}
    }
}
