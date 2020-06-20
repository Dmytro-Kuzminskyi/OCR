namespace OCR
{
    partial class FileView
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileView));
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.convertButton = new System.Windows.Forms.ToolStripButton();
            this.workspace = new System.Windows.Forms.Panel();
            this.documentWrapper = new System.Windows.Forms.PictureBox();
            this.fileToolStrip.SuspendLayout();
            this.workspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentWrapper)).BeginInit();
            this.SuspendLayout();
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.fileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.fileToolStrip.Size = new System.Drawing.Size(584, 28);
            this.fileToolStrip.TabIndex = 0;
            // 
            // convertButton
            // 
            this.convertButton.AutoSize = false;
            this.convertButton.AutoToolTip = false;
            this.convertButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.convertButton.Image = ((System.Drawing.Image)(resources.GetObject("convertButton.Image")));
            this.convertButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(60, 25);
            this.convertButton.Text = "Convert";
            this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // workspace
            // 
            this.workspace.AutoScroll = true;
            this.workspace.Controls.Add(this.documentWrapper);
            this.workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspace.Location = new System.Drawing.Point(0, 28);
            this.workspace.Margin = new System.Windows.Forms.Padding(0);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(584, 533);
            this.workspace.TabIndex = 1;
            // 
            // documentWrapper
            // 
            this.documentWrapper.Location = new System.Drawing.Point(0, 0);
            this.documentWrapper.Margin = new System.Windows.Forms.Padding(0);
            this.documentWrapper.Name = "documentWrapper";
            this.documentWrapper.Size = new System.Drawing.Size(0, 0);
            this.documentWrapper.TabIndex = 0;
            this.documentWrapper.TabStop = false;
            // 
            // FileView
            // 
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.fileToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Unnamed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileView_FormClosing);
            this.Load += new System.EventHandler(this.FileView_Load);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.workspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentWrapper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.ToolStripButton convertButton;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.PictureBox documentWrapper;
    }
}
