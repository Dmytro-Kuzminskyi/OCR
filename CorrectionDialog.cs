using System;
using System.Windows.Forms;

namespace OCR
{
	public partial class CorrectionDialog : Form
	{
		public string value;
		readonly object[] selectors = new object[] { "false", "true" };
		readonly object[] digits = new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "empty" };
		readonly object[] letters = new object[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
		"n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "empty" };

		public CorrectionDialog(string type, string value)
		{
			InitializeComponent();
			okButton.DialogResult = DialogResult.OK;
			replacementLabel.Text += @"'" + value + @"' with:";
			if (type == "digit")
				replacementComboBox.Items.AddRange(digits);
			else if (type == "letter")
				replacementComboBox.Items.AddRange(letters);
			else if (type == "selector")
				replacementComboBox.Items.AddRange(selectors);
			if (replacementComboBox.Items.Count > 0)
				replacementComboBox.SelectedIndex = 0;
		}

        private void ReplacementComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
			e.Handled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
			value = replacementComboBox.Text != "empty" ? replacementComboBox.Text : null; 
		}
    }
}
