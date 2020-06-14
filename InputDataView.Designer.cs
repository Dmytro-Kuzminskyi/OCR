namespace OCR
{
	partial class InputDataView
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.outputTextBox = new System.Windows.Forms.TextBox();
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.outputButton = new System.Windows.Forms.Button();
			this.inputButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.convertDataButton = new System.Windows.Forms.Button();
			this.extensionComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.heightTextBox = new System.Windows.Forms.TextBox();
			this.widthTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.inputProgressBar = new System.Windows.Forms.ProgressBar();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(418, 125);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(305, 8);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(105, 105);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 62);
			this.label2.Margin = new System.Windows.Forms.Padding(8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(223, 38);
			this.label2.TabIndex = 1;
			this.label2.Text = "Every category should contains files of the same extension.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(223, 38);
			this.label1.TabIndex = 0;
			this.label1.Text = "The input root folder should have the same structure as shown.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.outputTextBox);
			this.panel2.Controls.Add(this.inputTextBox);
			this.panel2.Controls.Add(this.outputButton);
			this.panel2.Controls.Add(this.inputButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(8, 133);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(418, 130);
			this.panel2.TabIndex = 1;
			// 
			// outputTextBox
			// 
			this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.outputTextBox.Location = new System.Drawing.Point(115, 80);
			this.outputTextBox.Margin = new System.Windows.Forms.Padding(8);
			this.outputTextBox.Name = "outputTextBox";
			this.outputTextBox.ReadOnly = true;
			this.outputTextBox.Size = new System.Drawing.Size(302, 22);
			this.outputTextBox.TabIndex = 3;
			this.outputTextBox.Text = "Select output file...";
			// 
			// inputTextBox
			// 
			this.inputTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.inputTextBox.Location = new System.Drawing.Point(115, 22);
			this.inputTextBox.Margin = new System.Windows.Forms.Padding(8);
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.ReadOnly = true;
			this.inputTextBox.Size = new System.Drawing.Size(302, 22);
			this.inputTextBox.TabIndex = 2;
			this.inputTextBox.Text = "Select root folder...";
			// 
			// outputButton
			// 
			this.outputButton.Location = new System.Drawing.Point(8, 66);
			this.outputButton.Margin = new System.Windows.Forms.Padding(8, 8, 0, 0);
			this.outputButton.Name = "outputButton";
			this.outputButton.Size = new System.Drawing.Size(90, 50);
			this.outputButton.TabIndex = 1;
			this.outputButton.Text = "Select output file";
			this.outputButton.UseVisualStyleBackColor = true;
			this.outputButton.Click += new System.EventHandler(this.OutputButton_Click);
			// 
			// inputButton
			// 
			this.inputButton.Location = new System.Drawing.Point(8, 8);
			this.inputButton.Margin = new System.Windows.Forms.Padding(8, 8, 0, 0);
			this.inputButton.Name = "inputButton";
			this.inputButton.Size = new System.Drawing.Size(90, 50);
			this.inputButton.TabIndex = 0;
			this.inputButton.Text = "Select input root folder";
			this.inputButton.UseVisualStyleBackColor = true;
			this.inputButton.Click += new System.EventHandler(this.InputButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.convertDataButton);
			this.groupBox1.Controls.Add(this.extensionComboBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.heightTextBox);
			this.groupBox1.Controls.Add(this.widthTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(8, 263);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(418, 90);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output parameters";
			// 
			// convertDataButton
			// 
			this.convertDataButton.Location = new System.Drawing.Point(192, 52);
			this.convertDataButton.Name = "convertDataButton";
			this.convertDataButton.Size = new System.Drawing.Size(100, 25);
			this.convertDataButton.TabIndex = 6;
			this.convertDataButton.Text = "Convert data";
			this.convertDataButton.UseVisualStyleBackColor = true;
			this.convertDataButton.Click += new System.EventHandler(this.ConvertDataButton_Click);
			// 
			// extensionComboBox
			// 
			this.extensionComboBox.FormattingEnabled = true;
			this.extensionComboBox.Items.AddRange(new object[] {
            "jpg",
            "png",
            "bmp",
            "gif"});
			this.extensionComboBox.Location = new System.Drawing.Point(242, 23);
			this.extensionComboBox.Name = "extensionComboBox";
			this.extensionComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.extensionComboBox.Size = new System.Drawing.Size(50, 24);
			this.extensionComboBox.TabIndex = 5;
			this.extensionComboBox.Text = "...";
			this.extensionComboBox.SelectionChangeCommitted += new System.EventHandler(this.ExtensionComboBox_SelectionChangeCommitted);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(162, 26);
			this.label5.Margin = new System.Windows.Forms.Padding(8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Extension:";
			// 
			// heightTextBox
			// 
			this.heightTextBox.Location = new System.Drawing.Point(66, 55);
			this.heightTextBox.Name = "heightTextBox";
			this.heightTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.heightTextBox.Size = new System.Drawing.Size(50, 22);
			this.heightTextBox.TabIndex = 3;
			this.heightTextBox.Text = "32 px";
			this.heightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.heightTextBox.Enter += new System.EventHandler(this.DimensionTextBox_Enter);
			this.heightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidationTextBox_KeyPress);
			this.heightTextBox.Leave += new System.EventHandler(this.DimensionTextBox_Leave);
			// 
			// widthTextBox
			// 
			this.widthTextBox.Location = new System.Drawing.Point(66, 23);
			this.widthTextBox.Name = "widthTextBox";
			this.widthTextBox.Size = new System.Drawing.Size(50, 22);
			this.widthTextBox.TabIndex = 2;
			this.widthTextBox.Text = "32 px";
			this.widthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.widthTextBox.Enter += new System.EventHandler(this.DimensionTextBox_Enter);
			this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidationTextBox_KeyPress);
			this.widthTextBox.Leave += new System.EventHandler(this.DimensionTextBox_Leave);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 58);
			this.label4.Margin = new System.Windows.Forms.Padding(8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Height:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 26);
			this.label3.Margin = new System.Windows.Forms.Padding(8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Width:";
			// 
			// inputProgressBar
			// 
			this.inputProgressBar.Location = new System.Drawing.Point(8, 359);
			this.inputProgressBar.Name = "inputProgressBar";
			this.inputProgressBar.Size = new System.Drawing.Size(418, 23);
			this.inputProgressBar.TabIndex = 7;
			// 
			// InputDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(434, 389);
			this.Controls.Add(this.inputProgressBar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(454, 432);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(454, 432);
			this.Name = "InputDataView";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Input Data";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputDataView_FormClosing);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox outputTextBox;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.Button outputButton;
		private System.Windows.Forms.Button inputButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox extensionComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox heightTextBox;
		private System.Windows.Forms.TextBox widthTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button convertDataButton;
		private System.Windows.Forms.ProgressBar inputProgressBar;
	}
}