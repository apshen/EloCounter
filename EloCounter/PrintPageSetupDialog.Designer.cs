namespace EloCounter
{
    partial class PrintPageSetupDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPageSetupDialog));
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.numericNameBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericHeaderMargin = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericRightMargin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericLeftMargin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericBottomMargin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericTopMargin = new System.Windows.Forms.NumericUpDown();
            this.comboBoxHeaderFont = new System.Windows.Forms.ComboBox();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.printPreviewControl = new System.Windows.Forms.PrintPreviewControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeaderMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottomMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopMargin)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.numericNameBox);
            this.groupBoxSettings.Controls.Add(this.label8);
            this.groupBoxSettings.Controls.Add(this.numericHeaderMargin);
            this.groupBoxSettings.Controls.Add(this.label7);
            this.groupBoxSettings.Controls.Add(this.numericRightMargin);
            this.groupBoxSettings.Controls.Add(this.label6);
            this.groupBoxSettings.Controls.Add(this.numericLeftMargin);
            this.groupBoxSettings.Controls.Add(this.label5);
            this.groupBoxSettings.Controls.Add(this.numericBottomMargin);
            this.groupBoxSettings.Controls.Add(this.label4);
            this.groupBoxSettings.Controls.Add(this.label3);
            this.groupBoxSettings.Controls.Add(this.numericTopMargin);
            this.groupBoxSettings.Controls.Add(this.comboBoxHeaderFont);
            this.groupBoxSettings.Controls.Add(this.comboBoxFont);
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBoxSettings, "groupBoxSettings");
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // numericNameBox
            // 
            resources.ApplyResources(this.numericNameBox, "numericNameBox");
            this.numericNameBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericNameBox.Name = "numericNameBox";
            this.numericNameBox.ValueChanged += new System.EventHandler(this.numericNameBox_ValueChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numericHeaderMargin
            // 
            resources.ApplyResources(this.numericHeaderMargin, "numericHeaderMargin");
            this.numericHeaderMargin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericHeaderMargin.Name = "numericHeaderMargin";
            this.numericHeaderMargin.ValueChanged += new System.EventHandler(this.numericHeaderMargin_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numericRightMargin
            // 
            resources.ApplyResources(this.numericRightMargin, "numericRightMargin");
            this.numericRightMargin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericRightMargin.Name = "numericRightMargin";
            this.numericRightMargin.ValueChanged += new System.EventHandler(this.numericRightMargin_ValueChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // numericLeftMargin
            // 
            resources.ApplyResources(this.numericLeftMargin, "numericLeftMargin");
            this.numericLeftMargin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericLeftMargin.Name = "numericLeftMargin";
            this.numericLeftMargin.ValueChanged += new System.EventHandler(this.numericLeftMargin_ValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // numericBottomMargin
            // 
            resources.ApplyResources(this.numericBottomMargin, "numericBottomMargin");
            this.numericBottomMargin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericBottomMargin.Name = "numericBottomMargin";
            this.numericBottomMargin.ValueChanged += new System.EventHandler(this.numericBottomMargin_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numericTopMargin
            // 
            resources.ApplyResources(this.numericTopMargin, "numericTopMargin");
            this.numericTopMargin.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericTopMargin.Name = "numericTopMargin";
            this.numericTopMargin.ValueChanged += new System.EventHandler(this.numericTopMargin_ValueChanged);
            // 
            // comboBoxHeaderFont
            // 
            this.comboBoxHeaderFont.DropDownHeight = 1;
            this.comboBoxHeaderFont.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxHeaderFont, "comboBoxHeaderFont");
            this.comboBoxHeaderFont.Name = "comboBoxHeaderFont";
            this.comboBoxHeaderFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxHeaderFont_SelectedIndexChanged);
            this.comboBoxHeaderFont.Click += new System.EventHandler(this.comboBoxHeaderFont_Click);
            this.comboBoxHeaderFont.Enter += new System.EventHandler(this.comboBoxHeaderFont_Enter);
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownHeight = 1;
            this.comboBoxFont.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxFont, "comboBoxFont");
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.TextChanged += new System.EventHandler(this.comboBoxFont_TextChanged);
            this.comboBoxFont.Click += new System.EventHandler(this.comboBoxFont_Click);
            this.comboBoxFont.Enter += new System.EventHandler(this.comboBoxFont_Enter);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // printPreviewControl
            // 
            resources.ApplyResources(this.printPreviewControl, "printPreviewControl");
            this.printPreviewControl.Name = "printPreviewControl";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.printPreviewControl);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // PrintPageSetupDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PrintPageSetupDialog";
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeaderMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBottomMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopMargin)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.ComboBox comboBoxHeaderFont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericHeaderMargin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericRightMargin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericLeftMargin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericBottomMargin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericTopMargin;
        private System.Windows.Forms.NumericUpDown numericNameBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;

    }
}