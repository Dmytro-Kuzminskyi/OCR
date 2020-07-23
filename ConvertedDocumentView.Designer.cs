namespace OCR
{
	partial class ConvertedDocumentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConvertedDocumentView));
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.convertedDocumentToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.correctButton = new System.Windows.Forms.ToolStripButton();
            this.documentWrapper = new System.Windows.Forms.PictureBox();
            this.workspace = new System.Windows.Forms.Panel();
            this.convertedDocumentToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentWrapper)).BeginInit();
            this.workspace.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 25);
            this.toolStripButton1.Text = "Convert";
            // 
            // convertedDocumentToolStrip
            // 
            this.convertedDocumentToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.convertedDocumentToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.convertedDocumentToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.saveAsButton,
            this.printButton,
            this.correctButton});
            this.convertedDocumentToolStrip.Location = new System.Drawing.Point(0, 0);
            this.convertedDocumentToolStrip.Name = "convertedDocumentToolStrip";
            this.convertedDocumentToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.convertedDocumentToolStrip.Size = new System.Drawing.Size(584, 25);
            this.convertedDocumentToolStrip.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.AutoToolTip = false;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(35, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.AutoToolTip = false;
            this.saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("saveAsButton.Image")));
            this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(58, 22);
            this.saveAsButton.Text = "Save as...";
            this.saveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // printButton
            // 
            this.printButton.AutoToolTip = false;
            this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(36, 22);
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // correctButton
            // 
            this.correctButton.AutoToolTip = false;
            this.correctButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.correctButton.Image = ((System.Drawing.Image)(resources.GetObject("correctButton.Image")));
            this.correctButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.correctButton.Name = "correctButton";
            this.correctButton.Size = new System.Drawing.Size(50, 22);
            this.correctButton.Text = "Correct";
            this.correctButton.Click += new System.EventHandler(this.CorrectButton_Click);
            // 
            // documentWrapper
            // 
            this.documentWrapper.Location = new System.Drawing.Point(0, 0);
            this.documentWrapper.Margin = new System.Windows.Forms.Padding(0);
            this.documentWrapper.Name = "documentWrapper";
            this.documentWrapper.Size = new System.Drawing.Size(0, 0);
            this.documentWrapper.TabIndex = 0;
            this.documentWrapper.TabStop = false;
            this.documentWrapper.Click += new System.EventHandler(this.DocumentWrapper_Click);
            this.documentWrapper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DocumentWrapper_MouseMove);
            // 
            // workspace
            // 
            this.workspace.AutoScroll = true;
            this.workspace.Controls.Add(this.documentWrapper);
            this.workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspace.Location = new System.Drawing.Point(0, 25);
            this.workspace.Margin = new System.Windows.Forms.Padding(0);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(584, 536);
            this.workspace.TabIndex = 1;
            // 
            // ConvertedDocumentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.convertedDocumentToolStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertedDocumentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Unnamed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConvertedDocumentView_FormClosing);
            this.Load += new System.EventHandler(this.ConvertedDocumentView_Load);
            this.convertedDocumentToolStrip.ResumeLayout(false);
            this.convertedDocumentToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentWrapper)).EndInit();
            this.workspace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip convertedDocumentToolStrip;
        private System.Windows.Forms.PictureBox documentWrapper;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton saveAsButton;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.ToolStripButton correctButton;
    }
}