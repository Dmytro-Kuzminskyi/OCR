﻿namespace OCR
{
    partial class CorrectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.replacementLabel = new System.Windows.Forms.Label();
            this.replacementComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // replacementLabel
            // 
            this.replacementLabel.AutoSize = true;
            this.replacementLabel.Location = new System.Drawing.Point(49, 32);
            this.replacementLabel.Name = "replacementLabel";
            this.replacementLabel.Size = new System.Drawing.Size(51, 15);
            this.replacementLabel.TabIndex = 0;
            this.replacementLabel.Text = "Replace ";
            // 
            // replacementComboBox
            // 
            this.replacementComboBox.FormattingEnabled = true;
            this.replacementComboBox.Location = new System.Drawing.Point(171, 29);
            this.replacementComboBox.Name = "replacementComboBox";
            this.replacementComboBox.Size = new System.Drawing.Size(60, 23);
            this.replacementComboBox.TabIndex = 1;
            this.replacementComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReplacementComboBox_KeyPress);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(49, 69);
            this.okButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(156, 69);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 40, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // CorrectionDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(280, 111);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.replacementComboBox);
            this.Controls.Add(this.replacementLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CorrectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correct prediction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label replacementLabel;
        private System.Windows.Forms.ComboBox replacementComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}