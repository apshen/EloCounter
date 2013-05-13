namespace EloCounter
{
    partial class TournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentForm));
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.splitPanels = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonShowActive = new System.Windows.Forms.RadioButton();
            this.radioButtonShowAll = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonFull = new System.Windows.Forms.RadioButton();
            this.radioButtonShort = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonRapid = new System.Windows.Forms.RadioButton();
            this.radioButtonBlitz = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownRounds = new System.Windows.Forms.NumericUpDown();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.textBoxTournamentName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listPlayers = new System.Windows.Forms.ListBox();
            this.searchPlayer = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.splitPanels.Panel1.SuspendLayout();
            this.splitPanels.Panel2.SuspendLayout();
            this.splitPanels.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRounds)).BeginInit();
            this.groupBox.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colNumber
            // 
            this.colNumber.Name = "colNumber";
            // 
            // colPlayers
            // 
            this.colPlayers.Name = "colPlayers";
            // 
            // colPoints
            // 
            this.colPoints.Name = "colPoints";
            // 
            // colPlace
            // 
            this.colPlace.Name = "colPlace";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // splitPanels
            // 
            resources.ApplyResources(this.splitPanels, "splitPanels");
            this.splitPanels.Name = "splitPanels";
            // 
            // splitPanels.Panel1
            // 
            this.splitPanels.Panel1.Controls.Add(this.groupBox3);
            this.splitPanels.Panel1.Controls.Add(this.groupBox5);
            this.splitPanels.Panel1.Controls.Add(this.groupBox4);
            this.splitPanels.Panel1.Controls.Add(this.groupBox2);
            this.splitPanels.Panel1.Controls.Add(this.groupBox1);
            this.splitPanels.Panel1.Controls.Add(this.groupBox);
            // 
            // splitPanels.Panel2
            // 
            this.splitPanels.Panel2.Controls.Add(this.splitContainer1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePicker);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonShowActive);
            this.groupBox5.Controls.Add(this.radioButtonShowAll);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // radioButtonShowActive
            // 
            resources.ApplyResources(this.radioButtonShowActive, "radioButtonShowActive");
            this.radioButtonShowActive.Checked = true;
            this.radioButtonShowActive.Name = "radioButtonShowActive";
            this.radioButtonShowActive.TabStop = true;
            this.radioButtonShowActive.UseVisualStyleBackColor = true;
            this.radioButtonShowActive.CheckedChanged += new System.EventHandler(this.radioButtonShowActive_CheckedChanged);
            // 
            // radioButtonShowAll
            // 
            resources.ApplyResources(this.radioButtonShowAll, "radioButtonShowAll");
            this.radioButtonShowAll.Name = "radioButtonShowAll";
            this.radioButtonShowAll.UseVisualStyleBackColor = true;
            this.radioButtonShowAll.CheckedChanged += new System.EventHandler(this.radioButtonShowAll_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonFull);
            this.groupBox4.Controls.Add(this.radioButtonShort);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // radioButtonFull
            // 
            resources.ApplyResources(this.radioButtonFull, "radioButtonFull");
            this.radioButtonFull.Name = "radioButtonFull";
            this.radioButtonFull.UseVisualStyleBackColor = true;
            this.radioButtonFull.CheckedChanged += new System.EventHandler(this.radioButtonFull_CheckedChanged);
            // 
            // radioButtonShort
            // 
            resources.ApplyResources(this.radioButtonShort, "radioButtonShort");
            this.radioButtonShort.Checked = true;
            this.radioButtonShort.Name = "radioButtonShort";
            this.radioButtonShort.TabStop = true;
            this.radioButtonShort.UseVisualStyleBackColor = true;
            this.radioButtonShort.CheckedChanged += new System.EventHandler(this.radioButtonShort_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonRapid);
            this.groupBox2.Controls.Add(this.radioButtonBlitz);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // radioButtonRapid
            // 
            resources.ApplyResources(this.radioButtonRapid, "radioButtonRapid");
            this.radioButtonRapid.Name = "radioButtonRapid";
            this.radioButtonRapid.UseVisualStyleBackColor = true;
            this.radioButtonRapid.CheckedChanged += new System.EventHandler(this.radioButtonRapid_CheckedChanged);
            // 
            // radioButtonBlitz
            // 
            resources.ApplyResources(this.radioButtonBlitz, "radioButtonBlitz");
            this.radioButtonBlitz.Checked = true;
            this.radioButtonBlitz.Name = "radioButtonBlitz";
            this.radioButtonBlitz.TabStop = true;
            this.radioButtonBlitz.UseVisualStyleBackColor = true;
            this.radioButtonBlitz.CheckedChanged += new System.EventHandler(this.radioButtonBlitz_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownRounds);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numericUpDownRounds
            // 
            resources.ApplyResources(this.numericUpDownRounds, "numericUpDownRounds");
            this.numericUpDownRounds.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRounds.Name = "numericUpDownRounds";
            this.numericUpDownRounds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRounds.ValueChanged += new System.EventHandler(this.numericUpDownRounds_ValueChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.textBoxTournamentName);
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // textBoxTournamentName
            // 
            resources.ApplyResources(this.textBoxTournamentName, "textBoxTournamentName");
            this.textBoxTournamentName.Name = "textBoxTournamentName";
            this.textBoxTournamentName.TextChanged += new System.EventHandler(this.textBoxTournamentName_TextChanged);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listPlayers);
            this.splitContainer1.Panel2.Controls.Add(this.searchPlayer);
            // 
            // listPlayers
            // 
            this.listPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.listPlayers, "listPlayers");
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listPlayers_KeyDown);
            this.listPlayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPlayers_MouseDoubleClick);
            // 
            // searchPlayer
            // 
            resources.ApplyResources(this.searchPlayer, "searchPlayer");
            this.searchPlayer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.searchPlayer.Name = "searchPlayer";
            this.searchPlayer.TextChanged += new System.EventHandler(this.searchPlayer_TextChanged);
            this.searchPlayer.Enter += new System.EventHandler(this.searchPlayer_Enter);
            this.searchPlayer.Leave += new System.EventHandler(this.searchPlayer_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCount,
            this.toolStripButtonCancel});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonCount
            // 
            resources.ApplyResources(this.toolStripButtonCount, "toolStripButtonCount");
            this.toolStripButtonCount.Name = "toolStripButtonCount";
            this.toolStripButtonCount.Click += new System.EventHandler(this.toolStripButtonCount_Click);
            // 
            // toolStripButtonCancel
            // 
            resources.ApplyResources(this.toolStripButtonCancel, "toolStripButtonCancel");
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // TournamentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitPanels);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "TournamentForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TournamentForm_KeyDown);
            this.splitPanels.Panel1.ResumeLayout(false);
            this.splitPanels.Panel2.ResumeLayout(false);
            this.splitPanels.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRounds)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlace;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.SplitContainer splitPanels;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxTournamentName;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.TextBox searchPlayer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonShowActive;
        private System.Windows.Forms.RadioButton radioButtonShowAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonFull;
        private System.Windows.Forms.RadioButton radioButtonShort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonRapid;
        private System.Windows.Forms.RadioButton radioButtonBlitz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownRounds;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
    }
}