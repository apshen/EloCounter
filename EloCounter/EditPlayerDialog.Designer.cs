namespace EloCounter
{
    partial class EditPlayerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPlayerDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.rateBlitz = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rapidDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.blitzDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.rateRapid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lastName
            // 
            this.lastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "Name", true));
            resources.ApplyResources(this.lastName, "lastName");
            this.lastName.Name = "lastName";
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(EloCounter.Player);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // rateBlitz
            // 
            this.rateBlitz.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "BlitzRate", true));
            resources.ApplyResources(this.rateBlitz, "rateBlitz");
            this.rateBlitz.Name = "rateBlitz";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lastName);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rapidDateTimePicker);
            this.groupBox2.Controls.Add(this.blitzDateTimePicker);
            this.groupBox2.Controls.Add(this.rateRapid);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rateBlitz);
            this.groupBox2.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rapidDateTimePicker
            // 
            resources.ApplyResources(this.rapidDateTimePicker, "rapidDateTimePicker");
            this.rapidDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "RapidLastUpdate", true));
            this.rapidDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.rapidDateTimePicker.Name = "rapidDateTimePicker";
            // 
            // blitzDateTimePicker
            // 
            this.blitzDateTimePicker.Checked = false;
            resources.ApplyResources(this.blitzDateTimePicker, "blitzDateTimePicker");
            this.blitzDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerBindingSource, "BlitzLastUpdate", true));
            this.blitzDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.blitzDateTimePicker.Name = "blitzDateTimePicker";
            // 
            // rateRapid
            // 
            this.rateRapid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerBindingSource, "RapidRate", true));
            resources.ApplyResources(this.rateRapid, "rateRapid");
            this.rateRapid.Name = "rateRapid";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // EditPlayerDialog
            // 
            this.AcceptButton = this.buttonSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditPlayerDialog";
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.TextBox lastName;
        public System.Windows.Forms.TextBox rateBlitz;
        public System.Windows.Forms.TextBox rateRapid;
        private System.Windows.Forms.BindingSource playerBindingSource;
        public System.Windows.Forms.DateTimePicker blitzDateTimePicker;
        public System.Windows.Forms.DateTimePicker rapidDateTimePicker;
    }
}