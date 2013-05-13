namespace EloCounter
{
    partial class PlayersList
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
            this.listPlayersView = new System.Windows.Forms.ListView();
            this.numberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updatedOnColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listPlayersView
            // 
            this.listPlayersView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listPlayersView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listPlayersView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listPlayersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumnHeader,
            this.lastNameColumnHeader,
            this.rateColumnHeader,
            this.updatedOnColumnHeader});
            this.listPlayersView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPlayersView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listPlayersView.FullRowSelect = true;
            this.listPlayersView.GridLines = true;
            this.listPlayersView.HideSelection = false;
            this.listPlayersView.Location = new System.Drawing.Point(0, 0);
            this.listPlayersView.Name = "listPlayersView";
            this.listPlayersView.Size = new System.Drawing.Size(409, 388);
            this.listPlayersView.TabIndex = 2;
            this.listPlayersView.UseCompatibleStateImageBehavior = false;
            this.listPlayersView.View = System.Windows.Forms.View.Details;
            this.listPlayersView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listPlayersView_ColumnClick);
            this.listPlayersView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listPlayersView_KeyDown);
            this.listPlayersView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listPlayersView_MouseClick);
            this.listPlayersView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listPlayersView_MouseDoubleClick);
            // 
            // numberColumnHeader
            // 
            this.numberColumnHeader.Text = "№";
            this.numberColumnHeader.Width = 30;
            // 
            // lastNameColumnHeader
            // 
            this.lastNameColumnHeader.Text = "Фамилия, инициалы";
            this.lastNameColumnHeader.Width = 121;
            // 
            // rateColumnHeader
            // 
            this.rateColumnHeader.Text = "Рейтинг";
            this.rateColumnHeader.Width = 104;
            // 
            // updatedOnColumnHeader
            // 
            this.updatedOnColumnHeader.Text = "Последнее обновление";
            this.updatedOnColumnHeader.Width = 135;
            // 
            // PlayersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listPlayersView);
            this.Name = "PlayersList";
            this.Size = new System.Drawing.Size(409, 388);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listPlayersView;
        private System.Windows.Forms.ColumnHeader numberColumnHeader;
        private System.Windows.Forms.ColumnHeader lastNameColumnHeader;
        private System.Windows.Forms.ColumnHeader rateColumnHeader;
        private System.Windows.Forms.ColumnHeader updatedOnColumnHeader;
    }
}
