namespace War
{
    partial class WarMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarMainForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonClearOutput = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBoxDisplay = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownNGames = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonMultiRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSleep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSingleRun = new System.Windows.Forms.Button();
            this.checkBoxShuffleAll = new System.Windows.Forms.CheckBox();
            this.checkBoxShuffleResult = new System.Windows.Forms.CheckBox();
            this.buttonThrow = new System.Windows.Forms.Button();
            this.buttonDeal = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxDeck = new System.Windows.Forms.RichTextBox();
            this.richTextBoxPlayer1 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxPlayer2 = new System.Windows.Forms.RichTextBox();
            this.workerSingleAutoRun = new System.ComponentModel.BackgroundWorker();
            this.workerMultiAutoRun = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxCounts = new System.Windows.Forms.TextBox();
            this.richTextBoxPot = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNGames)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleep)).BeginInit();
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
            this.splitContainer2.Panel1.Controls.Add(this.richTextBoxPot);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxCounts);
            this.splitContainer2.Panel1.Controls.Add(this.buttonClearOutput);
            this.splitContainer2.Panel1.Controls.Add(this.buttonCancel);
            this.splitContainer2.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxDisplay);
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1.Controls.Add(this.buttonMultiRun);
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel1.Controls.Add(this.buttonSingleRun);
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxShuffleAll);
            this.splitContainer2.Panel1.Controls.Add(this.checkBoxShuffleResult);
            this.splitContainer2.Panel1.Controls.Add(this.buttonThrow);
            this.splitContainer2.Panel1.Controls.Add(this.buttonDeal);
            this.splitContainer2.Panel1.Controls.Add(this.buttonShuffle);
            this.splitContainer2.Panel1.Controls.Add(this.buttonRestart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(897, 781);
            this.splitContainer2.SplitterDistance = 183;
            this.splitContainer2.TabIndex = 30;
            // 
            // buttonClearOutput
            // 
            this.buttonClearOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonClearOutput.Location = new System.Drawing.Point(0, 758);
            this.buttonClearOutput.Name = "buttonClearOutput";
            this.buttonClearOutput.Size = new System.Drawing.Size(183, 23);
            this.buttonClearOutput.TabIndex = 40;
            this.buttonClearOutput.Text = "Clear Output";
            this.buttonClearOutput.UseVisualStyleBackColor = true;
            this.buttonClearOutput.Click += new System.EventHandler(this.buttonClearOutput_Click);
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
            this.textBoxOutput.Size = new System.Drawing.Size(308, 781);
            this.textBoxOutput.TabIndex = 39;
            this.textBoxOutput.Text = "****************************************";
            this.textBoxOutput.WordWrap = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCancel.Location = new System.Drawing.Point(0, 264);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(183, 23);
            this.buttonCancel.TabIndex = 30;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 243);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(183, 21);
            this.progressBar1.TabIndex = 29;
            // 
            // checkBoxDisplay
            // 
            this.checkBoxDisplay.AutoSize = true;
            this.checkBoxDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxDisplay.Location = new System.Drawing.Point(0, 226);
            this.checkBoxDisplay.Name = "checkBoxDisplay";
            this.checkBoxDisplay.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkBoxDisplay.Size = new System.Drawing.Size(183, 17);
            this.checkBoxDisplay.TabIndex = 35;
            this.checkBoxDisplay.Text = "Display on Multi Auto-Run?";
            this.checkBoxDisplay.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel2.Controls.Add(this.numericUpDownNGames, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 199);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 27);
            this.tableLayoutPanel2.TabIndex = 38;
            // 
            // numericUpDownNGames
            // 
            this.numericUpDownNGames.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownNGames.Maximum = new decimal(new int[] {
            1000000,
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
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 26);
            this.label6.TabIndex = 33;
            this.label6.Text = "# of Games to Play";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMultiRun
            // 
            this.buttonMultiRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMultiRun.Location = new System.Drawing.Point(0, 176);
            this.buttonMultiRun.Name = "buttonMultiRun";
            this.buttonMultiRun.Size = new System.Drawing.Size(183, 23);
            this.buttonMultiRun.TabIndex = 19;
            this.buttonMultiRun.Text = "Multi Auto-Run";
            this.buttonMultiRun.UseVisualStyleBackColor = true;
            this.buttonMultiRun.Click += new System.EventHandler(this.AutoRunMultipleClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09091F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownSleep, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 149);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(183, 27);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // numericUpDownSleep
            // 
            this.numericUpDownSleep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSleep.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownSleep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSleep.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSleep.Name = "numericUpDownSleep";
            this.numericUpDownSleep.Size = new System.Drawing.Size(93, 20);
            this.numericUpDownSleep.TabIndex = 36;
            this.numericUpDownSleep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSleep.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Auto-Run Sleep (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSingleRun
            // 
            this.buttonSingleRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSingleRun.Location = new System.Drawing.Point(0, 126);
            this.buttonSingleRun.Name = "buttonSingleRun";
            this.buttonSingleRun.Size = new System.Drawing.Size(183, 23);
            this.buttonSingleRun.TabIndex = 18;
            this.buttonSingleRun.Text = "Auto-Throw";
            this.buttonSingleRun.UseVisualStyleBackColor = true;
            this.buttonSingleRun.Click += new System.EventHandler(this.AutoRunClicked);
            // 
            // checkBoxShuffleAll
            // 
            this.checkBoxShuffleAll.AutoSize = true;
            this.checkBoxShuffleAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxShuffleAll.Location = new System.Drawing.Point(0, 109);
            this.checkBoxShuffleAll.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxShuffleAll.Name = "checkBoxShuffleAll";
            this.checkBoxShuffleAll.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkBoxShuffleAll.Size = new System.Drawing.Size(183, 17);
            this.checkBoxShuffleAll.TabIndex = 27;
            this.checkBoxShuffleAll.Text = "Shuffle All Every Throw";
            this.checkBoxShuffleAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxShuffleResult
            // 
            this.checkBoxShuffleResult.AutoSize = true;
            this.checkBoxShuffleResult.Checked = true;
            this.checkBoxShuffleResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShuffleResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxShuffleResult.Location = new System.Drawing.Point(0, 92);
            this.checkBoxShuffleResult.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxShuffleResult.Name = "checkBoxShuffleResult";
            this.checkBoxShuffleResult.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkBoxShuffleResult.Size = new System.Drawing.Size(183, 17);
            this.checkBoxShuffleResult.TabIndex = 12;
            this.checkBoxShuffleResult.Text = "Shuffle Winnings";
            this.checkBoxShuffleResult.UseVisualStyleBackColor = true;
            // 
            // buttonThrow
            // 
            this.buttonThrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonThrow.Location = new System.Drawing.Point(0, 69);
            this.buttonThrow.Name = "buttonThrow";
            this.buttonThrow.Size = new System.Drawing.Size(183, 23);
            this.buttonThrow.TabIndex = 8;
            this.buttonThrow.Text = "Throw";
            this.buttonThrow.UseVisualStyleBackColor = true;
            this.buttonThrow.Click += new System.EventHandler(this.buttonThrow_Click);
            // 
            // buttonDeal
            // 
            this.buttonDeal.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDeal.Location = new System.Drawing.Point(0, 46);
            this.buttonDeal.Name = "buttonDeal";
            this.buttonDeal.Size = new System.Drawing.Size(183, 23);
            this.buttonDeal.TabIndex = 2;
            this.buttonDeal.Text = "Deal";
            this.buttonDeal.UseVisualStyleBackColor = true;
            this.buttonDeal.Click += new System.EventHandler(this.buttonDeal_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonShuffle.Location = new System.Drawing.Point(0, 23);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(183, 23);
            this.buttonShuffle.TabIndex = 0;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRestart.Location = new System.Drawing.Point(0, 0);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(183, 23);
            this.buttonRestart.TabIndex = 10;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Deck";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(265, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(132, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Player 1";
            // 
            // richTextBoxDeck
            // 
            this.richTextBoxDeck.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDeck.Location = new System.Drawing.Point(3, 26);
            this.richTextBoxDeck.Name = "richTextBoxDeck";
            this.richTextBoxDeck.ReadOnly = true;
            this.richTextBoxDeck.Size = new System.Drawing.Size(127, 751);
            this.richTextBoxDeck.TabIndex = 15;
            this.richTextBoxDeck.Text = "";
            // 
            // richTextBoxPlayer1
            // 
            this.richTextBoxPlayer1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPlayer1.Location = new System.Drawing.Point(136, 26);
            this.richTextBoxPlayer1.Name = "richTextBoxPlayer1";
            this.richTextBoxPlayer1.ReadOnly = true;
            this.richTextBoxPlayer1.Size = new System.Drawing.Size(127, 751);
            this.richTextBoxPlayer1.TabIndex = 16;
            this.richTextBoxPlayer1.Text = "";
            // 
            // richTextBoxPlayer2
            // 
            this.richTextBoxPlayer2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPlayer2.Location = new System.Drawing.Point(269, 26);
            this.richTextBoxPlayer2.Name = "richTextBoxPlayer2";
            this.richTextBoxPlayer2.ReadOnly = true;
            this.richTextBoxPlayer2.Size = new System.Drawing.Size(127, 751);
            this.richTextBoxPlayer2.TabIndex = 17;
            this.richTextBoxPlayer2.Text = "";
            // 
            // workerSingleAutoRun
            // 
            this.workerSingleAutoRun.WorkerReportsProgress = true;
            this.workerSingleAutoRun.WorkerSupportsCancellation = true;
            this.workerSingleAutoRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerSingleAutoRun_DoWork);
            this.workerSingleAutoRun.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.workerSingleAutoRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerSingleAutoRun_RunWorkerCompleted);
            // 
            // workerMultiAutoRun
            // 
            this.workerMultiAutoRun.WorkerReportsProgress = true;
            this.workerMultiAutoRun.WorkerSupportsCancellation = true;
            this.workerMultiAutoRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerMultiAutoRun_DoWork);
            this.workerMultiAutoRun.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerMultiAutoRun_ProgressChanged);
            this.workerMultiAutoRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerMultiAutoRun_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxPlayer2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxPlayer1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.richTextBoxDeck);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxOutput);
            this.splitContainer1.Size = new System.Drawing.Size(710, 781);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 18;
            // 
            // textBoxCounts
            // 
            this.textBoxCounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCounts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCounts.Location = new System.Drawing.Point(0, 287);
            this.textBoxCounts.Multiline = true;
            this.textBoxCounts.Name = "textBoxCounts";
            this.textBoxCounts.ReadOnly = true;
            this.textBoxCounts.Size = new System.Drawing.Size(183, 161);
            this.textBoxCounts.TabIndex = 41;
            this.textBoxCounts.Text = resources.GetString("textBoxCounts.Text");
            this.textBoxCounts.WordWrap = false;
            // 
            // richTextBoxPot
            // 
            this.richTextBoxPot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPot.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPot.Location = new System.Drawing.Point(0, 448);
            this.richTextBoxPot.Name = "richTextBoxPot";
            this.richTextBoxPot.ReadOnly = true;
            this.richTextBoxPot.Size = new System.Drawing.Size(183, 310);
            this.richTextBoxPot.TabIndex = 42;
            this.richTextBoxPot.Text = "";
            // 
            // WarMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 781);
            this.Controls.Add(this.splitContainer2);
            this.Name = "WarMainForm";
            this.Text = "WAR!!!     A simulation of the simple card game WAR.";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNGames)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleep)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericUpDownNGames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonMultiRun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownSleep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSingleRun;
        private System.Windows.Forms.CheckBox checkBoxShuffleAll;
        private System.Windows.Forms.CheckBox checkBoxShuffleResult;
        private System.Windows.Forms.Button buttonThrow;
        private System.Windows.Forms.Button buttonDeal;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxDeck;
        private System.Windows.Forms.RichTextBox richTextBoxPlayer1;
        private System.Windows.Forms.RichTextBox richTextBoxPlayer2;
        private System.ComponentModel.BackgroundWorker workerSingleAutoRun;
        private System.ComponentModel.BackgroundWorker workerMultiAutoRun;
        private System.Windows.Forms.Button buttonClearOutput;
        private System.Windows.Forms.RichTextBox richTextBoxPot;
        private System.Windows.Forms.TextBox textBoxCounts;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

