using System;
using System.Windows.Forms;

namespace OCR
{
	public partial class TemplateDialog : Form
	{
		public DocTemplate docTemplate;
		public TemplateDialog()
		{
			InitializeComponent();
			templateComboBox.SelectedIndex = 0;
			okButton.DialogResult = DialogResult.OK;
		}

        private void okButton_Click(object sender, EventArgs e)
        {
			if (templateComboBox.SelectedItem.ToString() == "Person Evidence")
				docTemplate = DocTemplate.PersonEvidence;
        }

        private void TemplateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
			e.Handled = true;
        }
    }
}
