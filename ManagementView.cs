using OCR.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;

namespace OCR
{
	public partial class ManagementView : Form
	{       
        delegate void SetControlPropertyDelegate(Control control, string propertyName, object propertyValue);
        readonly BackgroundWorker bw;
        readonly string rootDir;
        readonly MainForm caller;

		public ManagementView(MainForm f)
		{
			caller = f;
			InitializeComponent();
            loadingImage.Image = Resources.loading;
            bw = new BackgroundWorker();
            rootDir = Directory.GetCurrentDirectory() + @"\";
            CheckModelAccessability("Digits", Resources.DIGITS_MODEL_PATH);
            trainSetTextBox.GotFocus += (s, e) => { MainForm.HideCaret((s as TextBox).Handle); };
            testSetTextBox.GotFocus += (s, e) => { MainForm.HideCaret((s as TextBox).Handle); };
            modelMetricsTextBox.GotFocus += (s, e) => { MainForm.HideCaret((s as TextBox).Handle); };
            trainSetTextBox.MouseMove += (s, e) => { (s as TextBox).SelectionLength = 0; };
            testSetTextBox.MouseMove += (s, e) => { (s as TextBox).SelectionLength = 0; };
            modelMetricsTextBox.MouseMove += (s, e) => { (s as TextBox).SelectionLength = 0; };
        }

		private void ManagementView_FormClosing(object sender, FormClosingEventArgs e)
		{
			caller.DeleteSelfReference(this);
			Dispose();
		}

        public static void SetControlProperty(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyDelegate
                (SetControlProperty),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        private void ModelSelectorChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton) == digitsRadioButton)
                if ((sender as RadioButton).Checked)
                    CheckModelAccessability("Digits", Resources.DIGITS_MODEL_PATH);
            if ((sender as RadioButton) == lettersRadioButton)
                if ((sender as RadioButton).Checked)
                    CheckModelAccessability("Letters", Resources.LETTERS_MODEL_PATH);
        }

        private void CheckModelAccessability(string modelClass, string modelPath)
        {
            var path = rootDir + modelPath;
            if (!File.Exists(path))
            {
                modelStatusLabel.Text = modelClass + " model was not fould!";
                modelStatusLabel.ForeColor = Color.Red;
            }
            else
            {
                modelStatusLabel.Text = modelClass + " model was fould!";
                modelStatusLabel.ForeColor = Color.Green;
            }
        }

        private void DatasetButton_Click(object sender, EventArgs e)
        {
            var element = sender as Button;
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
                if (element == trainSetButton)
                    trainSetTextBox.Text = ofd.FileName;
                else
                    testSetTextBox.Text = ofd.FileName;
            }
            else
            {
                if (element == trainSetButton)
                    trainSetTextBox.Text = "Select trainset...";
                else
                    testSetTextBox.Text = "Define testset to see train metrics...";
            }
            if (trainSetTextBox.Text == testSetTextBox.Text)
            {
                testSetTextBox.Text = "Define testset to see train metrics...";
                MessageBox.Show("Testset must differs from trainset!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrainsetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (trainSetTextBox.Text != "Select trainset...")
            {
                trainerParametersGroupBox.Show();
                trainButton.Show();
            }
            else
            {
                trainerParametersGroupBox.Hide();
                trainButton.Hide();
            }
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bw.IsBusy)
                {
                    if (testSetTextBox.Text == "Define testset to see train metrics...")
                    {
                        modelMetricsTextBox.ScrollBars = ScrollBars.None;
                        modelMetricsTextBox.Visible = false;
                    }
                    else
                    {
                        modelMetricsTextBox.Text = "Wait for model evaluating...";
                        modelMetricsTextBox.Select(0, 0);
                        modelMetricsTextBox.ScrollBars = ScrollBars.None;
                        modelMetricsTextBox.Visible = true;
                    }
                    bw.DoWork += DoWork;
                    bw.RunWorkerCompleted += WorkCompleted;
                    bw.RunWorkerAsync();
                    trainButton.Enabled = false;
                    trainSetButton.Enabled = false;
                    testSetButton.Enabled = false;
                    trainProcessLabel.Show();
                    loadingImage.Show();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trainButton.Enabled = true;
            trainSetButton.Enabled = true;
            testSetButton.Enabled = true;
            trainProcessLabel.Hide();
            loadingImage.Hide();
            var error = e.Error;
            if (error != null)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                modelMetricsTextBox.ScrollBars = ScrollBars.Vertical;
                MessageBox.Show("Model is successfully trained!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modelMetricsTextBox.Select(0, 0);
            }
            bw.DoWork -= DoWork;
            bw.RunWorkerCompleted -= WorkCompleted;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            int? nol = null;
            int? mecpl = null;
            int noi = 100;
            double? lr = null;
            if (numberOfLeavesTextBox.Text != "")
                nol = int.Parse(numberOfLeavesTextBox.Text);
            if (minimumExampleCountPerLeafTextBox.Text != "")
                mecpl = int.Parse(minimumExampleCountPerLeafTextBox.Text);
            if (numberOfIterationsTextBox.Text != "")
                noi = int.Parse(numberOfIterationsTextBox.Text);
            if (learningRateTextBox.Text != "")
            {
                var value = learningRateTextBox.Text;
                if (value.IndexOf('.') == 3)
                    value += '0';
                lr = double.Parse(value);
            }
            var outputPath = rootDir + (digitsRadioButton.Checked ? Resources.DIGITS_MODEL_PATH : Resources.LETTERS_MODEL_PATH);
            if (testSetTextBox.Text == "Define testset to see train metrics...")
                ModelBuilder.CreateModel(trainSetTextBox.Text, outputPath, nol, mecpl, lr, noi);
            else
                ModelBuilder.CreateModel(trainSetTextBox.Text, testSetTextBox.Text, outputPath, 
                    modelMetricsTextBox, nol, mecpl, lr, noi);
        }

        private void TrainerParameters_KeyPress(object sender, KeyPressEventArgs e)
        {
            var s = sender as TextBox;
            if (s != learningRateTextBox)
            {
                if (!char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
                    e.Handled = true;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar && (e.KeyChar != '.'))
                    e.Handled = true;
                if ((e.KeyChar == '.') && (s.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
