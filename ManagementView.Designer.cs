namespace OCR
{
    partial class ManagementView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lettersRadioButton = new System.Windows.Forms.RadioButton();
            this.digitsRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.modelStatusLabel = new System.Windows.Forms.Label();
            this.modelSelectorGroupBox = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.testSetTextBox = new System.Windows.Forms.TextBox();
            this.testSetButton = new System.Windows.Forms.Button();
            this.trainerParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.numberOfLeavesLabel = new System.Windows.Forms.Label();
            this.numberOfLeavesTextBox = new System.Windows.Forms.TextBox();
            this.minimumExampleCountPerLeafLabel = new System.Windows.Forms.Label();
            this.minimumExampleCountPerLeafTextBox = new System.Windows.Forms.TextBox();
            this.learningRateLabel = new System.Windows.Forms.Label();
            this.learningRateTextBox = new System.Windows.Forms.TextBox();
            this.numberOfIterationsLabel = new System.Windows.Forms.Label();
            this.numberOfIterationsTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.trainProcessLabel = new System.Windows.Forms.Label();
            this.trainButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.modelMetricsTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.trainSetTextBox = new System.Windows.Forms.TextBox();
            this.trainSetButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.modelSelectorGroupBox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.trainerParametersGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lettersRadioButton
            // 
            this.lettersRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.lettersRadioButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lettersRadioButton.Location = new System.Drawing.Point(81, 17);
            this.lettersRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lettersRadioButton.Name = "lettersRadioButton";
            this.lettersRadioButton.Size = new System.Drawing.Size(67, 29);
            this.lettersRadioButton.TabIndex = 1;
            this.lettersRadioButton.Tag = "";
            this.lettersRadioButton.Text = "Letters";
            this.lettersRadioButton.UseVisualStyleBackColor = true;
            this.lettersRadioButton.CheckedChanged += new System.EventHandler(this.ModelSelectorChanged);
            // 
            // digitsRadioButton
            // 
            this.digitsRadioButton.Checked = true;
            this.digitsRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.digitsRadioButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.digitsRadioButton.Location = new System.Drawing.Point(14, 17);
            this.digitsRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.digitsRadioButton.Name = "digitsRadioButton";
            this.digitsRadioButton.Size = new System.Drawing.Size(67, 29);
            this.digitsRadioButton.TabIndex = 2;
            this.digitsRadioButton.TabStop = true;
            this.digitsRadioButton.Tag = "";
            this.digitsRadioButton.Text = "Digits";
            this.digitsRadioButton.UseVisualStyleBackColor = true;
            this.digitsRadioButton.CheckedChanged += new System.EventHandler(this.ModelSelectorChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.modelStatusLabel);
            this.panel1.Controls.Add(this.modelSelectorGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 48);
            this.panel1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(353, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 48);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // modelStatusLabel
            // 
            this.modelStatusLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.modelStatusLabel.Location = new System.Drawing.Point(156, 0);
            this.modelStatusLabel.MaximumSize = new System.Drawing.Size(197, 48);
            this.modelStatusLabel.MinimumSize = new System.Drawing.Size(197, 48);
            this.modelStatusLabel.Name = "modelStatusLabel";
            this.modelStatusLabel.Padding = new System.Windows.Forms.Padding(14, 14, 0, 0);
            this.modelStatusLabel.Size = new System.Drawing.Size(197, 48);
            this.modelStatusLabel.TabIndex = 1;
            this.modelStatusLabel.Text = "Model status";
            this.modelStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // modelSelectorGroupBox
            // 
            this.modelSelectorGroupBox.Controls.Add(this.lettersRadioButton);
            this.modelSelectorGroupBox.Controls.Add(this.digitsRadioButton);
            this.modelSelectorGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.modelSelectorGroupBox.Location = new System.Drawing.Point(0, 0);
            this.modelSelectorGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modelSelectorGroupBox.MaximumSize = new System.Drawing.Size(156, 48);
            this.modelSelectorGroupBox.MinimumSize = new System.Drawing.Size(156, 48);
            this.modelSelectorGroupBox.Name = "modelSelectorGroupBox";
            this.modelSelectorGroupBox.Padding = new System.Windows.Forms.Padding(14, 2, 3, 2);
            this.modelSelectorGroupBox.Size = new System.Drawing.Size(156, 48);
            this.modelSelectorGroupBox.TabIndex = 0;
            this.modelSelectorGroupBox.TabStop = false;
            this.modelSelectorGroupBox.Text = "Select model";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Controls.Add(this.testSetButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(8, 102);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.MinimumSize = new System.Drawing.Size(505, 39);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 7, 6);
            this.panel5.Size = new System.Drawing.Size(505, 39);
            this.panel5.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.testSetTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(111, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 33);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // testSetTextBox
            // 
            this.testSetTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.testSetTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.testSetTextBox.Location = new System.Drawing.Point(10, 6);
            this.testSetTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testSetTextBox.Name = "testSetTextBox";
            this.testSetTextBox.ReadOnly = true;
            this.testSetTextBox.Size = new System.Drawing.Size(367, 22);
            this.testSetTextBox.TabIndex = 0;
            this.testSetTextBox.Text = "Define testset to see train metrics...";
            // 
            // testSetButton
            // 
            this.testSetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.testSetButton.Location = new System.Drawing.Point(0, 0);
            this.testSetButton.Margin = new System.Windows.Forms.Padding(0);
            this.testSetButton.Name = "testSetButton";
            this.testSetButton.Size = new System.Drawing.Size(111, 33);
            this.testSetButton.TabIndex = 2;
            this.testSetButton.Text = "Select test set";
            this.testSetButton.UseVisualStyleBackColor = true;
            this.testSetButton.Click += new System.EventHandler(this.DatasetButton_Click);
            // 
            // trainerParametersGroupBox
            // 
            this.trainerParametersGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.trainerParametersGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.trainerParametersGroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.trainerParametersGroupBox.Location = new System.Drawing.Point(8, 141);
            this.trainerParametersGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainerParametersGroupBox.MaximumSize = new System.Drawing.Size(505, 84);
            this.trainerParametersGroupBox.Name = "trainerParametersGroupBox";
            this.trainerParametersGroupBox.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.trainerParametersGroupBox.Size = new System.Drawing.Size(488, 84);
            this.trainerParametersGroupBox.TabIndex = 8;
            this.trainerParametersGroupBox.TabStop = false;
            this.trainerParametersGroupBox.Text = "Trainer Parameters";
            this.trainerParametersGroupBox.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numberOfLeavesLabel);
            this.flowLayoutPanel1.Controls.Add(this.numberOfLeavesTextBox);
            this.flowLayoutPanel1.Controls.Add(this.minimumExampleCountPerLeafLabel);
            this.flowLayoutPanel1.Controls.Add(this.minimumExampleCountPerLeafTextBox);
            this.flowLayoutPanel1.Controls.Add(this.learningRateLabel);
            this.flowLayoutPanel1.Controls.Add(this.learningRateTextBox);
            this.flowLayoutPanel1.Controls.Add(this.numberOfIterationsLabel);
            this.flowLayoutPanel1.Controls.Add(this.numberOfIterationsTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 21);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(474, 57);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // numberOfLeavesLabel
            // 
            this.numberOfLeavesLabel.AutoSize = true;
            this.numberOfLeavesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberOfLeavesLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numberOfLeavesLabel.Location = new System.Drawing.Point(3, 5);
            this.numberOfLeavesLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.numberOfLeavesLabel.Name = "numberOfLeavesLabel";
            this.numberOfLeavesLabel.Size = new System.Drawing.Size(116, 16);
            this.numberOfLeavesLabel.TabIndex = 0;
            this.numberOfLeavesLabel.Text = "Number of leaves:";
            // 
            // numberOfLeavesTextBox
            // 
            this.numberOfLeavesTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberOfLeavesTextBox.Location = new System.Drawing.Point(122, 2);
            this.numberOfLeavesTextBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.numberOfLeavesTextBox.MaxLength = 3;
            this.numberOfLeavesTextBox.Name = "numberOfLeavesTextBox";
            this.numberOfLeavesTextBox.Size = new System.Drawing.Size(36, 22);
            this.numberOfLeavesTextBox.TabIndex = 1;
            this.numberOfLeavesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrainerParameters_KeyPress);
            // 
            // minimumExampleCountPerLeafLabel
            // 
            this.minimumExampleCountPerLeafLabel.AutoSize = true;
            this.minimumExampleCountPerLeafLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.minimumExampleCountPerLeafLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.minimumExampleCountPerLeafLabel.Location = new System.Drawing.Point(161, 5);
            this.minimumExampleCountPerLeafLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.minimumExampleCountPerLeafLabel.Name = "minimumExampleCountPerLeafLabel";
            this.minimumExampleCountPerLeafLabel.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.minimumExampleCountPerLeafLabel.Size = new System.Drawing.Size(268, 16);
            this.minimumExampleCountPerLeafLabel.TabIndex = 2;
            this.minimumExampleCountPerLeafLabel.Text = "Minimum example count per leaf:";
            this.minimumExampleCountPerLeafLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minimumExampleCountPerLeafTextBox
            // 
            this.minimumExampleCountPerLeafTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.minimumExampleCountPerLeafTextBox.Location = new System.Drawing.Point(432, 2);
            this.minimumExampleCountPerLeafTextBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.minimumExampleCountPerLeafTextBox.MaxLength = 3;
            this.minimumExampleCountPerLeafTextBox.Name = "minimumExampleCountPerLeafTextBox";
            this.minimumExampleCountPerLeafTextBox.Size = new System.Drawing.Size(36, 22);
            this.minimumExampleCountPerLeafTextBox.TabIndex = 3;
            this.minimumExampleCountPerLeafTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrainerParameters_KeyPress);
            // 
            // learningRateLabel
            // 
            this.learningRateLabel.AutoSize = true;
            this.learningRateLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.learningRateLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.learningRateLabel.Location = new System.Drawing.Point(3, 37);
            this.learningRateLabel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.learningRateLabel.Name = "learningRateLabel";
            this.learningRateLabel.Size = new System.Drawing.Size(88, 16);
            this.learningRateLabel.TabIndex = 4;
            this.learningRateLabel.Text = "Learning rate:";
            // 
            // learningRateTextBox
            // 
            this.learningRateTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.learningRateTextBox.Location = new System.Drawing.Point(122, 34);
            this.learningRateTextBox.Margin = new System.Windows.Forms.Padding(28, 10, 0, 0);
            this.learningRateTextBox.MaxLength = 4;
            this.learningRateTextBox.Name = "learningRateTextBox";
            this.learningRateTextBox.Size = new System.Drawing.Size(36, 22);
            this.learningRateTextBox.TabIndex = 5;
            this.learningRateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrainerParameters_KeyPress);
            // 
            // numberOfIterationsLabel
            // 
            this.numberOfIterationsLabel.AutoSize = true;
            this.numberOfIterationsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberOfIterationsLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numberOfIterationsLabel.Location = new System.Drawing.Point(161, 37);
            this.numberOfIterationsLabel.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.numberOfIterationsLabel.Name = "numberOfIterationsLabel";
            this.numberOfIterationsLabel.Padding = new System.Windows.Forms.Padding(67, 0, 0, 0);
            this.numberOfIterationsLabel.Size = new System.Drawing.Size(196, 16);
            this.numberOfIterationsLabel.TabIndex = 6;
            this.numberOfIterationsLabel.Text = "Number of iterations:";
            this.numberOfIterationsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numberOfIterationsTextBox
            // 
            this.numberOfIterationsTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.numberOfIterationsTextBox.Location = new System.Drawing.Point(432, 34);
            this.numberOfIterationsTextBox.Margin = new System.Windows.Forms.Padding(72, 10, 0, 0);
            this.numberOfIterationsTextBox.MaxLength = 3;
            this.numberOfIterationsTextBox.Name = "numberOfIterationsTextBox";
            this.numberOfIterationsTextBox.Size = new System.Drawing.Size(36, 22);
            this.numberOfIterationsTextBox.TabIndex = 7;
            this.numberOfIterationsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrainerParameters_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.trainButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(8, 225);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel3.Size = new System.Drawing.Size(488, 40);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.loadingImage);
            this.panel4.Controls.Add(this.trainProcessLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(111, 6);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.panel4.Size = new System.Drawing.Size(255, 34);
            this.panel4.TabIndex = 1;
            // 
            // loadingImage
            // 
            this.loadingImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.loadingImage.InitialImage = null;
            this.loadingImage.Location = new System.Drawing.Point(90, 0);
            this.loadingImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.loadingImage.Size = new System.Drawing.Size(37, 34);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingImage.TabIndex = 2;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // trainProcessLabel
            // 
            this.trainProcessLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.trainProcessLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.trainProcessLabel.Location = new System.Drawing.Point(14, 0);
            this.trainProcessLabel.Name = "trainProcessLabel";
            this.trainProcessLabel.Size = new System.Drawing.Size(76, 34);
            this.trainProcessLabel.TabIndex = 1;
            this.trainProcessLabel.Text = "Training in progress";
            this.trainProcessLabel.Visible = false;
            // 
            // trainButton
            // 
            this.trainButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.trainButton.Location = new System.Drawing.Point(0, 6);
            this.trainButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(111, 34);
            this.trainButton.TabIndex = 0;
            this.trainButton.Text = "Train model";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Visible = false;
            this.trainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.modelMetricsTextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(8, 265);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel6.Size = new System.Drawing.Size(488, 188);
            this.panel6.TabIndex = 10;
            // 
            // modelMetricsTextBox
            // 
            this.modelMetricsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.modelMetricsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelMetricsTextBox.Location = new System.Drawing.Point(0, 6);
            this.modelMetricsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modelMetricsTextBox.Multiline = true;
            this.modelMetricsTextBox.Name = "modelMetricsTextBox";
            this.modelMetricsTextBox.ReadOnly = true;
            this.modelMetricsTextBox.Size = new System.Drawing.Size(488, 182);
            this.modelMetricsTextBox.TabIndex = 0;
            this.modelMetricsTextBox.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Controls.Add(this.trainSetButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(8, 56);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.MinimumSize = new System.Drawing.Size(505, 46);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 7, 6);
            this.panel2.Size = new System.Drawing.Size(505, 46);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.trainSetTextBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(111, 6);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(394, 34);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // trainSetTextBox
            // 
            this.trainSetTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.trainSetTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.trainSetTextBox.Location = new System.Drawing.Point(10, 6);
            this.trainSetTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainSetTextBox.Name = "trainSetTextBox";
            this.trainSetTextBox.ReadOnly = true;
            this.trainSetTextBox.Size = new System.Drawing.Size(367, 22);
            this.trainSetTextBox.TabIndex = 0;
            this.trainSetTextBox.Text = "Select trainset...";
            this.trainSetTextBox.TextChanged += new System.EventHandler(this.TrainsetTextBox_TextChanged);
            // 
            // trainSetButton
            // 
            this.trainSetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.trainSetButton.Location = new System.Drawing.Point(0, 6);
            this.trainSetButton.Margin = new System.Windows.Forms.Padding(0);
            this.trainSetButton.Name = "trainSetButton";
            this.trainSetButton.Size = new System.Drawing.Size(111, 34);
            this.trainSetButton.TabIndex = 2;
            this.trainSetButton.Text = "Select train set";
            this.trainSetButton.UseVisualStyleBackColor = true;
            this.trainSetButton.Click += new System.EventHandler(this.DatasetButton_Click);
            // 
            // ManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(504, 461);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.trainerParametersGroupBox);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(524, 504);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(524, 504);
            this.Name = "ManagementView";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Management";
            this.panel1.ResumeLayout(false);
            this.modelSelectorGroupBox.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.trainerParametersGroupBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton digitsRadioButton;
        private System.Windows.Forms.RadioButton lettersRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox modelSelectorGroupBox;
        private System.Windows.Forms.Label modelStatusLabel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox testSetTextBox;
        private System.Windows.Forms.GroupBox trainerParametersGroupBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.Label trainProcessLabel;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox modelMetricsTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label numberOfLeavesLabel;
        private System.Windows.Forms.TextBox numberOfLeavesTextBox;
        private System.Windows.Forms.Label minimumExampleCountPerLeafLabel;
        private System.Windows.Forms.TextBox minimumExampleCountPerLeafTextBox;
        private System.Windows.Forms.Label learningRateLabel;
        private System.Windows.Forms.TextBox learningRateTextBox;
        private System.Windows.Forms.Label numberOfIterationsLabel;
        private System.Windows.Forms.TextBox numberOfIterationsTextBox;
        private System.Windows.Forms.Button testSetButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox trainSetTextBox;
        private System.Windows.Forms.Button trainSetButton;
    }
}
