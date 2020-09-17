using OCR.Properties;

namespace OCR
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topToolStrip = new System.Windows.Forms.ToolStrip();
            this.fileButton = new System.Windows.Forms.ToolStripButton();
            this.modelButton = new System.Windows.Forms.ToolStripButton();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.fileMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.modelMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inputDataButton = new System.Windows.Forms.ToolStripMenuItem();
            this.managementButton = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStrip.SuspendLayout();
            this.fileMenuStrip.SuspendLayout();
            this.modelMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topToolStrip
            // 
            this.topToolStrip.CanOverflow = false;
            this.topToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.topToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.modelButton,
            this.aboutButton});
            this.topToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.topToolStrip.Location = new System.Drawing.Point(0, 0);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.topToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.topToolStrip.Size = new System.Drawing.Size(784, 25);
            this.topToolStrip.TabIndex = 1;
            // 
            // fileButton
            // 
            this.fileButton.AutoSize = false;
            this.fileButton.AutoToolTip = false;
            this.fileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileButton.Margin = new System.Windows.Forms.Padding(0);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(45, 25);
            this.fileButton.Text = "File";
            this.fileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // modelButton
            // 
            this.modelButton.AutoSize = false;
            this.modelButton.AutoToolTip = false;
            this.modelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.modelButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modelButton.Image = ((System.Drawing.Image)(resources.GetObject("modelButton.Image")));
            this.modelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modelButton.Margin = new System.Windows.Forms.Padding(0);
            this.modelButton.Name = "modelButton";
            this.modelButton.Size = new System.Drawing.Size(45, 25);
            this.modelButton.Text = "Model";
            this.modelButton.Click += new System.EventHandler(this.ModelButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.AutoSize = false;
            this.aboutButton.AutoToolTip = false;
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutButton.Margin = new System.Windows.Forms.Padding(0);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(45, 25);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // fileMenuStrip
            // 
            this.fileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileButton});
            this.fileMenuStrip.Name = "fileMenuStrip";
            this.fileMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // openFileButton
            // 
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openFileButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(107, 22);
            this.openFileButton.Text = "Open";
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // modelMenuStrip
            // 
            this.modelMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputDataButton,
            this.managementButton});
            this.modelMenuStrip.Name = "modelMenuStrip";
            this.modelMenuStrip.Size = new System.Drawing.Size(154, 48);
            // 
            // inputDataButton
            // 
            this.inputDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.inputDataButton.Name = "inputDataButton";
            this.inputDataButton.Size = new System.Drawing.Size(153, 22);
            this.inputDataButton.Text = "Input Data";
            this.inputDataButton.Click += new System.EventHandler(this.InputDataButton_Click);
            // 
            // managementButton
            // 
            this.managementButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.managementButton.Name = "managementButton";
            this.managementButton.Size = new System.Drawing.Size(153, 22);
            this.managementButton.Text = "Management";
            this.managementButton.Click += new System.EventHandler(this.ManagementButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.topToolStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "OCR";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.topToolStrip.ResumeLayout(false);
            this.topToolStrip.PerformLayout();
            this.fileMenuStrip.ResumeLayout(false);
            this.modelMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip topToolStrip;
		private System.Windows.Forms.ContextMenuStrip fileMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem openFileButton;
		private System.Windows.Forms.ToolStripButton fileButton;
		private System.Windows.Forms.ToolStripButton modelButton;
		private System.Windows.Forms.ContextMenuStrip modelMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem inputDataButton;
		private System.Windows.Forms.ToolStripMenuItem managementButton;
        private System.Windows.Forms.ToolStripButton aboutButton;
    }
}

