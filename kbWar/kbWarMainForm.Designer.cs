namespace kbWar
{
    partial class kbWarMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kbWarMainForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBoxPot = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxCounts = new System.Windows.Forms.TextBox();
            this.buttonClearOutput = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxVerbose = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputFiles = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownNThreads = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownNGames = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonRunManyGames = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSleep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAutoThrow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxShowOnlyActivePlayers = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxShuffleResult = new System.Windows.Forms.CheckBox();
            this.buttonThrow = new System.Windows.Forms.Button();
            this.buttonDeal = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownNPlayers = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.workerAutoThrow = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNThreads)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNGames)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleep)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer2.Panel1.Controls.Add(this.buttonClearOutput);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(541, 781);
            this.splitContainer2.SplitterDistance = 188;
            this.splitContainer2.TabIndex = 30;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBoxPot);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 610);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(188, 148);
            this.groupBox5.TabIndex = 51;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Most Recently Won Cards";
            // 
            // richTextBoxPot
            // 
            this.richTextBoxPot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPot.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPot.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxPot.Name = "richTextBoxPot";
            this.richTextBoxPot.ReadOnly = true;
            this.richTextBoxPot.Size = new System.Drawing.Size(182, 129);
            this.richTextBoxPot.TabIndex = 42;
            this.richTextBoxPot.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxCounts);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 417);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(188, 193);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Counters";
            // 
            // textBoxCounts
            // 
            this.textBoxCounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCounts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCounts.Location = new System.Drawing.Point(3, 16);
            this.textBoxCounts.Multiline = true;
            this.textBoxCounts.Name = "textBoxCounts";
            this.textBoxCounts.ReadOnly = true;
            this.textBoxCounts.Size = new System.Drawing.Size(182, 174);
            this.textBoxCounts.TabIndex = 42;
            this.textBoxCounts.Text = resources.GetString("textBoxCounts.Text");
            this.textBoxCounts.WordWrap = false;
            // 
            // buttonClearOutput
            // 
            this.buttonClearOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonClearOutput.Location = new System.Drawing.Point(0, 758);
            this.buttonClearOutput.Name = "buttonClearOutput";
            this.buttonClearOutput.Size = new System.Drawing.Size(188, 23);
            this.buttonClearOutput.TabIndex = 40;
            this.buttonClearOutput.Text = "Clear Output";
            this.buttonClearOutput.UseVisualStyleBackColor = true;
            this.buttonClearOutput.Click += new System.EventHandler(this.buttonClearOutput_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Controls.Add(this.buttonRunManyGames);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 165);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monte-Carlo Simulation";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCancel.Location = new System.Drawing.Point(3, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 23);
            this.buttonCancel.TabIndex = 48;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(3, 113);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(182, 21);
            this.progressBar1.TabIndex = 47;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.32203F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.67797F));
            this.tableLayoutPanel3.Controls.Add(this.checkBoxVerbose, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxOutputFiles, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 91);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(182, 22);
            this.tableLayoutPanel3.TabIndex = 50;
            // 
            // checkBoxVerbose
            // 
            this.checkBoxVerbose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxVerbose.AutoSize = true;
            this.checkBoxVerbose.Location = new System.Drawing.Point(112, 3);
            this.checkBoxVerbose.Name = "checkBoxVerbose";
            this.checkBoxVerbose.Size = new System.Drawing.Size(65, 16);
            this.checkBoxVerbose.TabIndex = 44;
            this.checkBoxVerbose.Text = "Verbose";
            this.checkBoxVerbose.UseVisualStyleBackColor = true;
            // 
            // checkBoxOutputFiles
            // 
            this.checkBoxOutputFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxOutputFiles.AutoSize = true;
            this.checkBoxOutputFiles.Location = new System.Drawing.Point(9, 3);
            this.checkBoxOutputFiles.Name = "checkBoxOutputFiles";
            this.checkBoxOutputFiles.Size = new System.Drawing.Size(88, 16);
            this.checkBoxOutputFiles.TabIndex = 45;
            this.checkBoxOutputFiles.Text = "Output Files?";
            this.checkBoxOutputFiles.UseVisualStyleBackColor = true;
            this.checkBoxOutputFiles.CheckedChanged += new System.EventHandler(this.checkBoxOutputFiles_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownNThreads, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(182, 26);
            this.tableLayoutPanel4.TabIndex = 51;
            // 
            // numericUpDownNThreads
            // 
            this.numericUpDownNThreads.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownNThreads.Location = new System.Drawing.Point(7, 3);
            this.numericUpDownNThreads.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownNThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNThreads.Name = "numericUpDownNThreads";
            this.numericUpDownNThreads.Size = new System.Drawing.Size(93, 20);
            this.numericUpDownNThreads.TabIndex = 36;
            this.numericUpDownNThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNThreads.ThousandsSeparator = true;
            this.numericUpDownNThreads.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "# of Threads";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownNGames, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(182, 26);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // numericUpDownNGames
            // 
            this.numericUpDownNGames.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownNGames.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNGames.Location = new System.Drawing.Point(7, 3);
            this.numericUpDownNGames.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownNGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNGames.Name = "numericUpDownNGames";
            this.numericUpDownNGames.Size = new System.Drawing.Size(93, 20);
            this.numericUpDownNGames.TabIndex = 36;
            this.numericUpDownNGames.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNGames.ThousandsSeparator = true;
            this.numericUpDownNGames.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 26);
            this.label6.TabIndex = 33;
            this.label6.Text = "# of Games to Play";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRunManyGames
            // 
            this.buttonRunManyGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRunManyGames.Location = new System.Drawing.Point(3, 16);
            this.buttonRunManyGames.Name = "buttonRunManyGames";
            this.buttonRunManyGames.Size = new System.Drawing.Size(182, 23);
            this.buttonRunManyGames.TabIndex = 46;
            this.buttonRunManyGames.Text = "Run Monte-Carlo Simulation";
            this.buttonRunManyGames.UseVisualStyleBackColor = true;
            this.buttonRunManyGames.Click += new System.EventHandler(this.StartMonteCarloSimulation);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Controls.Add(this.buttonAutoThrow);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 67);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Throw";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownSleep, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(182, 26);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // numericUpDownSleep
            // 
            this.numericUpDownSleep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownSleep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSleep.Location = new System.Drawing.Point(7, 3);
            this.numericUpDownSleep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSleep.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSleep.Name = "numericUpDownSleep";
            this.numericUpDownSleep.Size = new System.Drawing.Size(93, 20);
            this.numericUpDownSleep.TabIndex = 36;
            this.numericUpDownSleep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSleep.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Auto-Throw Sleep (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAutoThrow
            // 
            this.buttonAutoThrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAutoThrow.Location = new System.Drawing.Point(3, 16);
            this.buttonAutoThrow.Name = "buttonAutoThrow";
            this.buttonAutoThrow.Size = new System.Drawing.Size(182, 23);
            this.buttonAutoThrow.TabIndex = 38;
            this.buttonAutoThrow.Text = "Auto-Throw";
            this.buttonAutoThrow.UseVisualStyleBackColor = true;
            this.buttonAutoThrow.Click += new System.EventHandler(this.buttonAutoThrow_Clicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel7);
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Controls.Add(this.buttonThrow);
            this.groupBox1.Controls.Add(this.buttonDeal);
            this.groupBox1.Controls.Add(this.buttonShuffle);
            this.groupBox1.Controls.Add(this.buttonRestart);
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 185);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interactive Controls";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.checkBoxShowOnlyActivePlayers, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 157);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(182, 25);
            this.tableLayoutPanel7.TabIndex = 49;
            // 
            // checkBoxShowOnlyActivePlayers
            // 
            this.checkBoxShowOnlyActivePlayers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxShowOnlyActivePlayers.AutoSize = true;
            this.checkBoxShowOnlyActivePlayers.Location = new System.Drawing.Point(28, 4);
            this.checkBoxShowOnlyActivePlayers.Name = "checkBoxShowOnlyActivePlayers";
            this.checkBoxShowOnlyActivePlayers.Size = new System.Drawing.Size(125, 17);
            this.checkBoxShowOnlyActivePlayers.TabIndex = 16;
            this.checkBoxShowOnlyActivePlayers.Text = "Show Empty Hands?";
            this.checkBoxShowOnlyActivePlayers.UseVisualStyleBackColor = true;
            this.checkBoxShowOnlyActivePlayers.CheckedChanged += new System.EventHandler(this.checkBoxShowOnlyActivePlayers_CheckedChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.checkBoxShuffleResult, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 132);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(182, 25);
            this.tableLayoutPanel6.TabIndex = 48;
            // 
            // checkBoxShuffleResult
            // 
            this.checkBoxShuffleResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxShuffleResult.AutoSize = true;
            this.checkBoxShuffleResult.Checked = true;
            this.checkBoxShuffleResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShuffleResult.Location = new System.Drawing.Point(41, 4);
            this.checkBoxShuffleResult.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxShuffleResult.Name = "checkBoxShuffleResult";
            this.checkBoxShuffleResult.Size = new System.Drawing.Size(106, 17);
            this.checkBoxShuffleResult.TabIndex = 31;
            this.checkBoxShuffleResult.Text = "Shuffle Winnings";
            this.checkBoxShuffleResult.UseVisualStyleBackColor = true;
            // 
            // buttonThrow
            // 
            this.buttonThrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonThrow.Location = new System.Drawing.Point(3, 109);
            this.buttonThrow.Name = "buttonThrow";
            this.buttonThrow.Size = new System.Drawing.Size(182, 23);
            this.buttonThrow.TabIndex = 29;
            this.buttonThrow.Text = "Throw";
            this.buttonThrow.UseVisualStyleBackColor = true;
            this.buttonThrow.Click += new System.EventHandler(this.buttonThrow_Click);
            // 
            // buttonDeal
            // 
            this.buttonDeal.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDeal.Location = new System.Drawing.Point(3, 88);
            this.buttonDeal.Name = "buttonDeal";
            this.buttonDeal.Size = new System.Drawing.Size(182, 21);
            this.buttonDeal.TabIndex = 37;
            this.buttonDeal.Text = "Deal";
            this.buttonDeal.UseVisualStyleBackColor = true;
            this.buttonDeal.Click += new System.EventHandler(this.buttonDeal_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonShuffle.Location = new System.Drawing.Point(3, 65);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(182, 23);
            this.buttonShuffle.TabIndex = 28;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRestart.Location = new System.Drawing.Point(3, 42);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(182, 23);
            this.buttonRestart.TabIndex = 30;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel5.Controls.Add(this.numericUpDownNPlayers, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(182, 26);
            this.tableLayoutPanel5.TabIndex = 47;
            // 
            // numericUpDownNPlayers
            // 
            this.numericUpDownNPlayers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownNPlayers.Location = new System.Drawing.Point(7, 3);
            this.numericUpDownNPlayers.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownNPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNPlayers.Name = "numericUpDownNPlayers";
            this.numericUpDownNPlayers.Size = new System.Drawing.Size(93, 20);
            this.numericUpDownNPlayers.TabIndex = 36;
            this.numericUpDownNPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownNPlayers.ThousandsSeparator = true;
            this.numericUpDownNPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNPlayers.ValueChanged += new System.EventHandler(this.numericUpDownNPlayers_ValueChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(119, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "# Players";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panelLabels);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxOutput);
            this.splitContainer1.Size = new System.Drawing.Size(349, 781);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.TabIndex = 18;
            // 
            // panelLabels
            // 
            this.panelLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabels.Location = new System.Drawing.Point(0, 0);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(30, 25);
            this.panelLabels.TabIndex = 0;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(315, 781);
            this.textBoxOutput.TabIndex = 39;
            this.textBoxOutput.Text = "****************************************";
            this.textBoxOutput.WordWrap = false;
            // 
            // workerAutoThrow
            // 
            this.workerAutoThrow.WorkerReportsProgress = true;
            this.workerAutoThrow.WorkerSupportsCancellation = true;
            this.workerAutoThrow.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerAutoThrow_DoWork);
            this.workerAutoThrow.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerAutoThrow_ProgressChanged);
            this.workerAutoThrow.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerAutoThrow_RunWorkerCompleted);
            // 
            // kbWarMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(541, 781);
            this.Controls.Add(this.splitContainer2);
            this.Name = "kbWarMainForm";
            this.Text = "kbWar!!!     A simulation of the simple card game WAR.";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNThreads)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNGames)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleep)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNPlayers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.ComponentModel.BackgroundWorker workerAutoThrow;
        private System.Windows.Forms.Button buttonClearOutput;
        private System.Windows.Forms.RichTextBox richTextBoxPot;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxCounts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBoxVerbose;
        private System.Windows.Forms.CheckBox checkBoxOutputFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.NumericUpDown numericUpDownNThreads;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericUpDownNGames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonRunManyGames;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownSleep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAutoThrow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.NumericUpDown numericUpDownNPlayers;
        private System.Windows.Forms.Button buttonDeal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonThrow;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.CheckBox checkBoxShowOnlyActivePlayers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox checkBoxShuffleResult;
        private System.Windows.Forms.Panel panelLabels;
    }
}

