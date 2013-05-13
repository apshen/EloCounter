namespace EloCounter
{
    partial class TournamentTable
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.table = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unknownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.resultContextMenu.SuspendLayout();
            this.editGameContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            this.table.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table.ColumnHeadersHeight = 30;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colPlayers,
            this.colPoints,
            this.colPlace});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table.DefaultCellStyle = dataGridViewCellStyle2;
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.MinimumSize = new System.Drawing.Size(0, 24);
            this.table.Name = "table";
            this.table.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.table.RowHeadersVisible = false;
            this.table.RowTemplate.Height = 47;
            this.table.Size = new System.Drawing.Size(577, 438);
            this.table.TabIndex = 1;
            this.table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellClick);
            this.table.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentDoubleClick);
            this.table.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.table_CellMouseClick);
            this.table.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.table_CellMouseDown);
            this.table.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.table_CellMouseUp);
            this.table.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.table_CellStateChanged);
            // 
            // colNumber
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNumber.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNumber.HeaderText = "№";
            this.colNumber.MinimumWidth = 50;
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colNumber.Width = 50;
            // 
            // colPlayers
            // 
            this.colPlayers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPlayers.HeaderText = "Участники";
            this.colPlayers.Name = "colPlayers";
            this.colPlayers.ReadOnly = true;
            this.colPlayers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPlayers.Width = 86;
            // 
            // colPoints
            // 
            this.colPoints.HeaderText = "Очки";
            this.colPoints.MinimumWidth = 50;
            this.colPoints.Name = "colPoints";
            this.colPoints.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPoints.Width = 50;
            // 
            // colPlace
            // 
            this.colPlace.HeaderText = "Место";
            this.colPlace.MinimumWidth = 50;
            this.colPlace.Name = "colPlace";
            this.colPlace.ReadOnly = true;
            this.colPlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colPlace.Width = 50;
            // 
            // resultContextMenu
            // 
            this.resultContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zeroToolStripMenuItem,
            this.oneToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.unknownToolStripMenuItem});
            this.resultContextMenu.Name = "contextMenuStrip1";
            this.resultContextMenu.ShowCheckMargin = true;
            this.resultContextMenu.ShowImageMargin = false;
            this.resultContextMenu.Size = new System.Drawing.Size(92, 92);
            // 
            // zeroToolStripMenuItem
            // 
            this.zeroToolStripMenuItem.AutoSize = false;
            this.zeroToolStripMenuItem.Name = "zeroToolStripMenuItem";
            this.zeroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zeroToolStripMenuItem.Text = "0";
            this.zeroToolStripMenuItem.Click += new System.EventHandler(this.zeroToolStripMenuItem_Click);
            // 
            // oneToolStripMenuItem
            // 
            this.oneToolStripMenuItem.AutoSize = false;
            this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            this.oneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oneToolStripMenuItem.Text = "1";
            this.oneToolStripMenuItem.Click += new System.EventHandler(this.oneToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.AutoSize = false;
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.drawToolStripMenuItem.Text = "1/2";
            this.drawToolStripMenuItem.Click += new System.EventHandler(this.drawToolStripMenuItem_Click);
            // 
            // unknownToolStripMenuItem
            // 
            this.unknownToolStripMenuItem.Name = "unknownToolStripMenuItem";
            this.unknownToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.unknownToolStripMenuItem.Text = "-";
            this.unknownToolStripMenuItem.Click += new System.EventHandler(this.unknownToolStripMenuItem_Click);
            // 
            // editGameContextMenuStrip
            // 
            this.editGameContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editGameToolStripMenuItem});
            this.editGameContextMenuStrip.Name = "editGameContextMenuStrip";
            this.editGameContextMenuStrip.Size = new System.Drawing.Size(183, 26);
            // 
            // editGameToolStripMenuItem
            // 
            this.editGameToolStripMenuItem.Enabled = false;
            this.editGameToolStripMenuItem.Name = "editGameToolStripMenuItem";
            this.editGameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.editGameToolStripMenuItem.Text = "Редактировать игру";
            // 
            // TournamentTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.table);
            this.DoubleBuffered = true;
            this.Name = "TournamentTable";
            this.Size = new System.Drawing.Size(577, 438);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.resultContextMenu.ResumeLayout(false);
            this.editGameContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlace;
        private System.Windows.Forms.ContextMenuStrip resultContextMenu;
        private System.Windows.Forms.ToolStripMenuItem zeroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unknownToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip editGameContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editGameToolStripMenuItem;
    }
}
