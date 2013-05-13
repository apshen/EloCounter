namespace EloCounter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newTournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rateStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blitzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rateSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showInactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blitzPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rapidPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.menuStripMain.SuspendLayout();
            this.mainContextMenu.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Name = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDBToolStripMenuItem,
            this.openDBToolStripMenuItem,
            this.toolStripSeparator2,
            this.addPlayerToolStripMenuItem,
            this.deletePlayerToolStripMenuItem,
            this.toolStripSeparator1,
            this.newTournamentToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // createDBToolStripMenuItem
            // 
            this.createDBToolStripMenuItem.Name = "createDBToolStripMenuItem";
            resources.ApplyResources(this.createDBToolStripMenuItem, "createDBToolStripMenuItem");
            this.createDBToolStripMenuItem.Click += new System.EventHandler(this.createDBToolStripMenuItem_Click);
            // 
            // openDBToolStripMenuItem
            // 
            this.openDBToolStripMenuItem.Name = "openDBToolStripMenuItem";
            resources.ApplyResources(this.openDBToolStripMenuItem, "openDBToolStripMenuItem");
            this.openDBToolStripMenuItem.Click += new System.EventHandler(this.openDBToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // addPlayerToolStripMenuItem
            // 
            this.addPlayerToolStripMenuItem.Name = "addPlayerToolStripMenuItem";
            resources.ApplyResources(this.addPlayerToolStripMenuItem, "addPlayerToolStripMenuItem");
            this.addPlayerToolStripMenuItem.Click += new System.EventHandler(this.addPlayerToolStripMenuItem_Click);
            // 
            // deletePlayerToolStripMenuItem
            // 
            this.deletePlayerToolStripMenuItem.Name = "deletePlayerToolStripMenuItem";
            resources.ApplyResources(this.deletePlayerToolStripMenuItem, "deletePlayerToolStripMenuItem");
            this.deletePlayerToolStripMenuItem.Click += new System.EventHandler(this.deletePlayerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // newTournamentToolStripMenuItem
            // 
            this.newTournamentToolStripMenuItem.Name = "newTournamentToolStripMenuItem";
            resources.ApplyResources(this.newTournamentToolStripMenuItem, "newTournamentToolStripMenuItem");
            this.newTournamentToolStripMenuItem.Click += new System.EventHandler(this.newTournamentToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.rateStripMenuItem,
            this.toolStripSeparator4,
            this.sortToolStripMenuItem,
            this.toolStripSeparator5,
            this.showInactiveToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // rateStripMenuItem
            // 
            this.rateStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blitzToolStripMenuItem,
            this.rapidToolStripMenuItem});
            this.rateStripMenuItem.Name = "rateStripMenuItem";
            resources.ApplyResources(this.rateStripMenuItem, "rateStripMenuItem");
            // 
            // blitzToolStripMenuItem
            // 
            this.blitzToolStripMenuItem.Checked = true;
            this.blitzToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blitzToolStripMenuItem.Name = "blitzToolStripMenuItem";
            resources.ApplyResources(this.blitzToolStripMenuItem, "blitzToolStripMenuItem");
            this.blitzToolStripMenuItem.Click += new System.EventHandler(this.blitzToolStripMenuItem_Click);
            // 
            // rapidToolStripMenuItem
            // 
            this.rapidToolStripMenuItem.Checked = true;
            this.rapidToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rapidToolStripMenuItem.Name = "rapidToolStripMenuItem";
            resources.ApplyResources(this.rapidToolStripMenuItem, "rapidToolStripMenuItem");
            this.rapidToolStripMenuItem.Click += new System.EventHandler(this.rapidToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexSortToolStripMenuItem,
            this.rateSortToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            resources.ApplyResources(this.sortToolStripMenuItem, "sortToolStripMenuItem");
            // 
            // lexSortToolStripMenuItem
            // 
            this.lexSortToolStripMenuItem.CheckOnClick = true;
            this.lexSortToolStripMenuItem.Name = "lexSortToolStripMenuItem";
            resources.ApplyResources(this.lexSortToolStripMenuItem, "lexSortToolStripMenuItem");
            this.lexSortToolStripMenuItem.Click += new System.EventHandler(this.lexSortToolStripMenuItem_Click);
            // 
            // rateSortToolStripMenuItem
            // 
            this.rateSortToolStripMenuItem.Checked = true;
            this.rateSortToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rateSortToolStripMenuItem.Name = "rateSortToolStripMenuItem";
            resources.ApplyResources(this.rateSortToolStripMenuItem, "rateSortToolStripMenuItem");
            this.rateSortToolStripMenuItem.Click += new System.EventHandler(this.rateSortToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // showInactiveToolStripMenuItem
            // 
            this.showInactiveToolStripMenuItem.Checked = true;
            this.showInactiveToolStripMenuItem.CheckOnClick = true;
            this.showInactiveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.showInactiveToolStripMenuItem.Name = "showInactiveToolStripMenuItem";
            resources.ApplyResources(this.showInactiveToolStripMenuItem, "showInactiveToolStripMenuItem");
            this.showInactiveToolStripMenuItem.Click += new System.EventHandler(this.showInactiveToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blitzPrintToolStripMenuItem,
            this.rapidPrintToolStripMenuItem,
            this.printSetupToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            // 
            // blitzPrintToolStripMenuItem
            // 
            this.blitzPrintToolStripMenuItem.Name = "blitzPrintToolStripMenuItem";
            resources.ApplyResources(this.blitzPrintToolStripMenuItem, "blitzPrintToolStripMenuItem");
            this.blitzPrintToolStripMenuItem.Click += new System.EventHandler(this.blitzPrintToolStripMenuItem_Click);
            // 
            // rapidPrintToolStripMenuItem
            // 
            this.rapidPrintToolStripMenuItem.Name = "rapidPrintToolStripMenuItem";
            resources.ApplyResources(this.rapidPrintToolStripMenuItem, "rapidPrintToolStripMenuItem");
            this.rapidPrintToolStripMenuItem.Click += new System.EventHandler(this.rapidPrintToolStripMenuItem_Click);
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            resources.ApplyResources(this.printSetupToolStripMenuItem, "printSetupToolStripMenuItem");
            this.printSetupToolStripMenuItem.Click += new System.EventHandler(this.printSetupToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAboutToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // showAboutToolStripMenuItem
            // 
            this.showAboutToolStripMenuItem.Name = "showAboutToolStripMenuItem";
            resources.ApplyResources(this.showAboutToolStripMenuItem, "showAboutToolStripMenuItem");
            this.showAboutToolStripMenuItem.Click += new System.EventHandler(this.showAboutToolStripMenuItem_Click);
            // 
            // mainContextMenu
            // 
            this.mainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPlayerToolStripMenuItem,
            this.removePlayerToolStripMenuItem});
            this.mainContextMenu.Name = "mainContextMenu";
            resources.ApplyResources(this.mainContextMenu, "mainContextMenu");
            // 
            // editPlayerToolStripMenuItem
            // 
            this.editPlayerToolStripMenuItem.Name = "editPlayerToolStripMenuItem";
            resources.ApplyResources(this.editPlayerToolStripMenuItem, "editPlayerToolStripMenuItem");
            this.editPlayerToolStripMenuItem.Click += new System.EventHandler(this.editPlayerToolStripMenuItem_Click);
            // 
            // removePlayerToolStripMenuItem
            // 
            this.removePlayerToolStripMenuItem.Name = "removePlayerToolStripMenuItem";
            resources.ApplyResources(this.removePlayerToolStripMenuItem, "removePlayerToolStripMenuItem");
            this.removePlayerToolStripMenuItem.Click += new System.EventHandler(this.removePlayerToolStripMenuItem_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStripMain);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.mainContextMenu.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTournamentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInactiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem lexSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rateSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blitzPrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapidPrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem createDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem rateStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blitzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rapidToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

