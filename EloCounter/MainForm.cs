using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing.Printing;

namespace EloCounter
{
    public partial class MainForm : Form
    {
        private DBManager dbMgr = new DBManager();
        private List<Player> allPlayers = new List<Player>();
        private PlayerSortType currentSortType;
        private GameType currentRateType;
        private bool showInactivePlayers;
        PlayersList playersListRight = new PlayersList();
        PlayersList playersListLeft = new PlayersList();
        PrintPageSettings printPageSettings;

        public MainForm()
        {
            InitializeComponent();
            string dbPath = RegistrySettings.GetLatestOpenedDatabase();

            currentSortType = RegistrySettings.GetSortType();
            UpdateSortTypeButtons();

            currentRateType = RegistrySettings.GetGameType();
            UpdateRateTypeButtons();

            showInactivePlayers = RegistrySettings.GetShowInactivePlayersOption();
            UpdateShowInactivePlayersMenuItem();

            playersListRight.Dock = DockStyle.Fill;
            playersListRight.OnItemDoubleClick += new PlayersList.MouseDoubleClickEvent(this.OnPlayerDoubleClick);
            playersListRight.OnItemMouseRightClick += new PlayersList.MouseRightClickEvent(this.OnPlayerMouseRightClick);
            playersListRight.OnColumnHeaderClick += new PlayersList.ColumnHeadertClickEvent(this.OnSortTypeChange);

            playersListLeft.Dock  = DockStyle.Fill;
            playersListLeft.OnItemDoubleClick += new PlayersList.MouseDoubleClickEvent(this.OnPlayerDoubleClick);
            playersListLeft.OnItemMouseRightClick += new PlayersList.MouseRightClickEvent(this.OnPlayerMouseRightClick);
            playersListLeft.OnColumnHeaderClick += new PlayersList.ColumnHeadertClickEvent(this.OnSortTypeChange);

            this.splitContainer.Panel1.Controls.Add(playersListLeft);
            this.splitContainer.Panel2.Controls.Add(playersListRight);

            printPageSettings = RegistrySettings.GetPageSettings();

            if(dbPath != null && dbPath.Length != 0)
            {
                InitListView(dbPath);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DbNotLoadedAlert())
            {
                return;
            }

            EditPlayerDialog addDialog = new EditPlayerDialog();
            if(addDialog.ShowDialog() == DialogResult.OK)
            {
                dbMgr.InsertPlayer(addDialog.GetPlayer());
                ReloadPlayersAndView(); //TODO just add to the in-memory list, do not load entire DB
            }
        }

        private void deletePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playersListRight.SelectedItems.Count == 0 && playersListLeft.SelectedItems.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("После удаление игрока данные не могут быть востановлены! Продолжить?",
                   "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Player p = null;
                if (playersListLeft.SelectedItems.Count != 0)
                {
                    p = (Player)playersListLeft.SelectedItems[0].Tag;
                }
                else
                {
                    p = (Player)playersListRight.SelectedItems[0].Tag;
                }

                dbMgr.RemovePlayer(p);
                ReloadPlayersAndView(); //TODO just update the item
            }
        }

        private void newTournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DbNotLoadedAlert())
            {
                return;
            }

            TournamentForm tournamentForm = new TournamentForm(allPlayers, GetSelectedPlayers(), currentRateType);
            if (tournamentForm.ShowDialog() == DialogResult.OK)
            {
                WriteTournamentToDB(tournamentForm.Table);
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                InitListView(openFileDialog.FileName);
            }

        }

        private void LoadPlayersFromDB()
        {
            allPlayers = dbMgr.LoadAllPlayers(currentSortType, currentRateType);
        }

        private void ReloadListView()
        {
            playersListRight.Clear();
            playersListLeft.Clear();

            List<Player> pl = GetDisplayedPlayers();
            Player p;
            for (int i = 0; i < pl.Count; ++i)
            {
                p = pl[i];
                InsertPlayerIntoViewList(p, i, pl.Count);
            }
            HiglightSortedColumn();
            UpdateColumnHeaders();
        }

        private void OnPlayerDoubleClick(ListViewItem item)
        {
            EditPlayer((Player)item.Tag);
        }

        private void OnPlayerMouseRightClick(ListViewItem item)
        {
            mainContextMenu.Show(Cursor.Position);
            mainContextMenu.Tag = item;
        }

        private void editPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = (ListViewItem)mainContextMenu.Tag;
            EditPlayer((Player)item.Tag);
        }

        private void EditPlayer(Player player)
        {
            EditPlayerDialog editDialog = new EditPlayerDialog(player);
            if(editDialog.ShowDialog() == DialogResult.OK)
            {
                dbMgr.UpdatePlayer(editDialog.GetPlayer());
                ReloadPlayersAndView(); //TODO just update the item
            }
        }

        private void removePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("После удаление игрока данные не могут быть востановлены! Продолжить?",
                            "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ListViewItem item = (ListViewItem)mainContextMenu.Tag;
                dbMgr.RemovePlayer((Player)item.Tag);
                ReloadPlayersAndView(); //TODO just update the item
            }
        }

        private bool DbNotLoadedAlert()
        {
            if (dbMgr.DbConnection == null)
            {
                MessageBox.Show("Необходимо сначала загрузить базу данных!", "Ошибка",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        private bool InitListView(string dbPath)
        {
            try
            {
                if (dbMgr.DbConnection != null)
                {
                    dbMgr.DbConnection.Close();
                }
                else
                {
                    dbMgr.DbConnection = new SQLiteConnection();
                }

                dbMgr.DbConnection.ConnectionString = @"Data Source=" + dbPath;
                dbMgr.DbConnection.Open();
                dbMgr.UpdateDB();
                ReloadPlayersAndView();
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(this, "$this");
                this.Text += " [" + dbPath + "]";
                RegistrySettings.SetLatestOpenedDatabase(dbPath);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Невозможно открыть файл. Возможно файл был удален или переименован. Пожалуйста загрузите файл базы данных заново",
                                "Ошибка", MessageBoxButtons.OK);
                RegistrySettings.SetLatestOpenedDatabase("");
                return false;
            }
        }

        private void ReloadPlayersAndView()
        {
            LoadPlayersFromDB();
            ReloadListView();
        }

        private void WriteTournamentToDB(ITournament table)
        {
            Tournament t = dbMgr.InsertTournament(table.GetTournament());

            foreach (Player p in table.GetPlayers())
            {
                TournamentResult res = table.GetResult(p);
                res.Event = t;
                dbMgr.InsertResult(res);

                int newRate = EloTable.GetNewRate(p.GetRate(table.GetGameType()), table.GetAverageRate(p), table.GetMaxPoints(p), table.GetResult(p).Points);
                Player tp = p.Clone();
                tp.SetRate(table.GetGameType(), newRate);
                tp.SetUpdateDate(t.Type, t.EndOn);
                dbMgr.UpdatePlayer(tp);
            }

            foreach (Game g in table.GetGames())
            {
                g.Tournament = t;
                dbMgr.InsertGame(g);
            }

            ReloadPlayersAndView();
        }

        private void blitzPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Player> listToPrint = GetDisplayedPlayers();
            listToPrint.Sort(ComparePlayersByBlitzRate);
            new ListPrinter(printPageSettings).Print(listToPrint, GameType.Blitz);
        }

        private void rapidPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Player> listToPrint = GetDisplayedPlayers();
            listToPrint.Sort(ComparePlayersByRapidRate);
            new ListPrinter(printPageSettings).Print(listToPrint, GameType.Rapid);
        }

        private void classicPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Player> listToPrint = GetDisplayedPlayers();
            listToPrint.Sort(ComparePlayersByClassicRate);
            new ListPrinter(printPageSettings).Print(listToPrint, GameType.Classic);
        }

        private List<Player> GetDisplayedPlayers()
        {
            return showInactivePlayers ? allPlayers : allPlayers.FindAll(IsPlayerActive);
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPageSetupDialog pageSetup = new PrintPageSetupDialog(printPageSettings, GetDisplayedPlayers());
            if(pageSetup.ShowDialog() == DialogResult.OK)
            {
                RegistrySettings.SetPageSettings(printPageSettings);
            }

            //PrintDocument docToPrint = new PrintDocument();
            //printDialog.AllowSomePages = true;
            //printDialog.ShowHelp = true;
            //printDialog.PrinterSettings = new PrinterSettings();


            //DialogResult result = printDialog.ShowDialog();
        }

        private void UpdateSortTypeButtons()
        {
            foreach (ToolStripMenuItem i in sortToolStripMenuItem.DropDownItems)
            {
                i.CheckState = CheckState.Unchecked;
            }

            switch (currentSortType)
            {
                case PlayerSortType.ByRate:
                    rateSortToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
                case PlayerSortType.ByName:
                    lexSortToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
            }
            RegistrySettings.SetSortType(currentSortType);
        }

        private void UpdateRateTypeButtons()
        {
            foreach (ToolStripMenuItem i in rateStripMenuItem.DropDownItems)
            {
                i.CheckState = CheckState.Unchecked;
            }

            switch (currentRateType)
            {
                case GameType.Blitz:
                    blitzToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
                case GameType.Rapid:
                    rapidToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
                case GameType.Classic:
                    break;
            }
            RegistrySettings.SetGameType(currentRateType);
        }

        private void rateSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentSortType(PlayerSortType.ByRate);
        }

        private void lexSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentSortType(PlayerSortType.ByName);
        }

        private void SetCurrentSortType(PlayerSortType type)
        {
            if(currentSortType == type)
            {
                return;
            }

            currentSortType = type;
            UpdateSortTypeButtons();
            switch (currentSortType)
            {
                case PlayerSortType.ByRate:
                    switch (currentRateType)
                    {
                        case GameType.Blitz:
                            allPlayers.Sort(ComparePlayersByBlitzRate);
                            break;
                        case GameType.Rapid:
                            allPlayers.Sort(ComparePlayersByRapidRate);
                            break;
                        case GameType.Classic:
                            allPlayers.Sort(ComparePlayersByClassicRate);
                            break;
                    }
                    break;
                case PlayerSortType.ByName:
                    allPlayers.Sort(ComparePlayersByName);
                    break;
            }
            ReloadListView();
        }

        private void SetCurrentRateType(GameType type)
        {
            if (currentRateType == type)
            {
                return;
            }

            currentRateType = type;
            UpdateRateTypeButtons();
            switch (currentRateType)
            {
                case GameType.Blitz:
                    allPlayers.Sort(ComparePlayersByBlitzRate);
                    break;
                case GameType.Rapid:
                    allPlayers.Sort(ComparePlayersByRapidRate);
                    break;
                case GameType.Classic:
                    allPlayers.Sort(ComparePlayersByClassicRate);
                    break;
            }
            ReloadListView();
        }

        private void HiglightSortedColumn()
        {
            playersListRight.HiglightSortedColumn(currentSortType);
            playersListLeft.HiglightSortedColumn(currentSortType);
        }

        private void UpdateColumnHeaders()
        {
            playersListRight.UpdateColumnHeaders(currentRateType);
            playersListLeft.UpdateColumnHeaders(currentRateType);
        }

        private static int ComparePlayersByName(Player x, Player y)
        {
            return x.Name.CompareTo(y.Name);
        }

        private static int ComparePlayersByBlitzRate(Player x, Player y)
        {
            return y.BlitzRate - x.BlitzRate;
        }

        private static int ComparePlayersByRapidRate(Player x, Player y)
        {
            return y.RapidRate - x.RapidRate;
        }

        private static int ComparePlayersByClassicRate(Player x, Player y)
        {
            return y.ClassicRate - x.ClassicRate;
        }



        private void OnSortTypeChange(PlayerSortType st)
        {
            if(st != PlayerSortType.Undefined)
            {
                SetCurrentSortType(st);
            }
       }

        private void createDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDbDialog dialog = new CreateDbDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string dbPath = dialog.GetFullDBFileName();
                    if (File.Exists(dbPath))
                    {
                        if (MessageBox.Show("Файл '" + dbPath + "' существует, хотите перезаписать?",
                        "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, 
                        MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    dbMgr.CreateDB(dbPath);
                    if (dialog.AutoLoadDB)
                    {
                        InitListView(dialog.GetFullDBFileName());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно создать базу '" + dialog.GetFullDBFileName() + "' Ошибка: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void showInactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showInactivePlayers = (showInactiveToolStripMenuItem.CheckState == CheckState.Checked);
            RegistrySettings.SetShowInactivePlayersOption(showInactivePlayers);
            ReloadListView();
        }

        private void UpdateShowInactivePlayersMenuItem()
        {
            if (showInactivePlayers)
            {
                showInactiveToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                showInactiveToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void InsertPlayerIntoViewList(Player p, int index, int count)
        {
            ListViewItem item = new ListViewItem(new[] {(index + 1).ToString(), 
                                                             p.Name,
                                                             p.GetRate(currentRateType).ToString(),
                                                             p.GetUpdateDate(currentRateType).ToString("dd.MM.yyyy HH:mm")
                                                            });

            item.Tag = p;
            item.UseItemStyleForSubItems = false;
            if (index < (count + 1) / 2)
            {
                playersListLeft.InsertItem(item);
            }
            else
            {
                playersListRight.InsertItem(item);
            }

            HighlightOldPlayer(item);
        }

        private bool IsPlayerActive(Player p)
        {
            return p.IsActive(currentRateType);
        }

        private void HighlightOldPlayer(ListViewItem item)
        {
            Player p = (Player)item.Tag;
            if (!IsPlayerActive(p))
            {
                item.ForeColor = System.Drawing.SystemColors.ControlDark;
                foreach (ListViewItem.ListViewSubItem i in item.SubItems)
                {
                    i.ForeColor = System.Drawing.SystemColors.ControlDark;
                }
            }
        }

        private List<Player> GetSelectedPlayers()
        {
            List<Player> selectedPlayers = new List<Player>();
            for (int i = 0; i < playersListLeft.SelectedItems.Count; ++i)
            {
                selectedPlayers.Add((Player)playersListLeft.SelectedItems[i].Tag);
            }

            for (int i = 0; i < playersListRight.SelectedItems.Count; ++i)
            {
                selectedPlayers.Add((Player)playersListRight.SelectedItems[i].Tag);
            }

            return selectedPlayers;
        }

        private void showAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog();
        }

        private void blitzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentRateType(GameType.Blitz);
        }

        private void rapidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentRateType(GameType.Rapid);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
        //        if (playersListLeft.SelectedIndex != -1)
        //        {
        //            int index = playersListLeft.SelectedIndex;
        //            if (index < playersListRight.Items.Count)
        //            {
        //                playersListRight[index].Selected = true;
        //                foreach (ListViewItem item in playersListLeft.SelectedItems)
        //                {
        //                    item.Selected = false;
        //                }
        //            }
        //        }

                playersListRight.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
        //        if (playersListRight.SelectedIndex != -1)
        //        {
        //            int index = playersListRight.SelectedIndex;
        //            if (index < playersListLeft.Items.Count)
        //            {
        //                playersListLeft[index].Selected = true;
        //                foreach (ListViewItem item in playersListRight.SelectedItems)
        //                {
        //                    item.Selected = false;
        //                }
        //            }
        //        }

                playersListLeft.Focus();
            }
        }
    }
}