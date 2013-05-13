namespace EloCounter
{
    partial class CreateDbDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDbDialog));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonSearchFolder = new System.Windows.Forms.Button();
            this.checkBoxLoadDB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // labelFolder
            // 
            resources.ApplyResources(this.labelFolder, "labelFolder");
            this.labelFolder.Name = "labelFolder";
            // 
            // textBoxDbName
            // 
            resources.ApplyResources(this.textBoxDbName, "textBoxDbName");
            this.textBoxDbName.Name = "textBoxDbName";
            // 
            // textBoxFolder
            // 
            resources.ApplyResources(this.textBoxFolder, "textBoxFolder");
            this.textBoxFolder.Name = "textBoxFolder";
            // 
            // buttonSearchFolder
            // 
            resources.ApplyResources(this.buttonSearchFolder, "buttonSearchFolder");
            this.buttonSearchFolder.Name = "buttonSearchFolder";
            this.buttonSearchFolder.UseVisualStyleBackColor = true;
            this.buttonSearchFolder.Click += new System.EventHandler(this.buttonSearchFolder_Click);
            // 
            // checkBoxLoadDB
            // 
            resources.ApplyResources(this.checkBoxLoadDB, "checkBoxLoadDB");
            this.checkBoxLoadDB.Checked = true;
            this.checkBoxLoadDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLoadDB.Name = "checkBoxLoadDB";
            this.checkBoxLoadDB.UseVisualStyleBackColor = true;
            // 
            // CreateDbDialog
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.checkBoxLoadDB);
            this.Controls.Add(this.buttonSearchFolder);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.textBoxDbName);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateDbDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox textBoxDbName;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonSearchFolder;
        private System.Windows.Forms.CheckBox checkBoxLoadDB;
    }
}