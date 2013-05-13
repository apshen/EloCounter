namespace EloCounter
{
    partial class RateChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateChangeForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.listPlayersView = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rateOld = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rateNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rateDiff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            resources.ApplyResources(this.toolStripButtonSave, "toolStripButtonSave");
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCancel
            // 
            resources.ApplyResources(this.toolStripButtonCancel, "toolStripButtonCancel");
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // listPlayersView
            // 
            this.listPlayersView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.listPlayersView, "listPlayersView");
            this.listPlayersView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listPlayersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.lastName,
            this.rateOld,
            this.rateNew,
            this.rateDiff});
            this.listPlayersView.FullRowSelect = true;
            this.listPlayersView.GridLines = true;
            this.listPlayersView.HideSelection = false;
            this.listPlayersView.Name = "listPlayersView";
            this.listPlayersView.UseCompatibleStateImageBehavior = false;
            this.listPlayersView.View = System.Windows.Forms.View.Details;
            // 
            // number
            // 
            resources.ApplyResources(this.number, "number");
            // 
            // lastName
            // 
            resources.ApplyResources(this.lastName, "lastName");
            // 
            // rateOld
            // 
            resources.ApplyResources(this.rateOld, "rateOld");
            // 
            // rateNew
            // 
            resources.ApplyResources(this.rateNew, "rateNew");
            // 
            // rateDiff
            // 
            resources.ApplyResources(this.rateDiff, "rateDiff");
            // 
            // RateChangeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listPlayersView);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "RateChangeForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RateChangeForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ListView listPlayersView;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader lastName;
        private System.Windows.Forms.ColumnHeader rateOld;
        private System.Windows.Forms.ColumnHeader rateNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.ColumnHeader rateDiff;



    }
}