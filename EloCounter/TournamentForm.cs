using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace EloCounter
{
    public partial class TournamentForm : Form
    {
        private StringComparison ignoreCase= StringComparison.CurrentCultureIgnoreCase;

        private List<Player> inactivePlayers = new List<Player>();
        private List<Player> availablePlayers;
        private List<Player> noResult = new List<Player>();
        private List<Player> searchResult = new List<Player>();
        private List<Player> currentDataSource;

        private ITournamentTable table = new ShortTournamentTable();
        private string currentSearchText = "";
        private bool suppressTextChangeEvent = false;
        private bool supressNameChangeEvent = false;
        GameType currentRateType = GameType.Blitz;
        private bool showInactivePlayers = false;
        private bool nameWasChanged = false;

        public ITournamentTable Table
        {
            get
            {
                return table;
            }
        }

        public TournamentForm(List<Player> players, List<Player> preselectedPlayers, GameType gt)
        {
            InitializeComponent();

            availablePlayers = GetDisplayedPlayers(players, inactivePlayers);

            table.Rounds = (int)numericUpDownRounds.Value;
            ReloadTableView(table);
            if (preselectedPlayers.Count > 1)
            {
                for (int i = 0; i < preselectedPlayers.Count; ++i)
                {
                    RemoveByPlayerId(preselectedPlayers[i].Id);
                    table.AddPlayer(preselectedPlayers[i]);
                }
            }

            UpdateNameTextBox();
            UpdateTypeButtons(gt);
            SetDataSource(availablePlayers);
        }

        private void ReloadTableView(ITournamentTable newTable)
        {
            splitContainer1.Panel1.Controls.Remove((UserControl)table);
            table = newTable;
            ((UserControl)table).Dock = DockStyle.Fill;
            table.OnPlayerDelete += new PlayerDeleteEvent(this.OnTablePlayerDeleted);
            splitContainer1.Panel1.Controls.Add(((UserControl)table));
        }

        private void SetDataSource(List<Player> dataSrc)
        {
            listPlayers.DataSource = null;
            listPlayers.DataSource = dataSrc;
            currentDataSource = dataSrc;
        }

        private void searchPlayer_TextChanged(object sender, EventArgs e)
        {
            if (suppressTextChangeEvent)
            {
                suppressTextChangeEvent = false;
                return;
            }
            currentSearchText = searchPlayer.Text;

            UpdateListBox();
        }

        private void UpdateListBox()
        {
            if (currentSearchText.Length != 0)
            {
                searchResult.Clear();
                foreach (Player p in availablePlayers)
                {
                    if (p.Name.StartsWith(currentSearchText, StringComparison.CurrentCultureIgnoreCase))
                    {
                        searchResult.Add(p);
                    }
                }
                if (searchResult.Count != 0)
                {
                    SetDataSource(searchResult);
                }
                else
                {
                    SetDataSource(noResult);
                }
            }
            else
            {
                SetDataSource(availablePlayers);
            }
        }

        private void UpdateTypeButtons(GameType gt)
        {
            if (gt == GameType.Blitz)
            {
                radioButtonBlitz.Checked = true;
            }
            else
            {
                radioButtonRapid.Checked = true;
            }
        }

        private void UpdateNameTextBox()
        {
            if (!nameWasChanged)
            {
                supressNameChangeEvent = true;
                textBoxTournamentName.Text = GetTournamentString(currentRateType) + " "
                                             + dateTimePicker.Value.ToString("dd.MM.yyyy-HH:mm");
            }


        }

        private String GetTournamentString(GameType gt)
        {
            if (gt == GameType.Blitz)
            {
                return "Блиц-турнир";
            }
            else if (gt == GameType.Rapid)
            {
                return "Рапид-турнир";
            }
            return "Турнир";
        }

        private void listPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MovePlayerToTable(listPlayers.IndexFromPoint(e.Location));
        }

        private void listPlayers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MovePlayerToTable(listPlayers.SelectedIndex);
            }
        }

        private void MovePlayerToTable(int index)
        {
            if (index != ListBox.NoMatches)
            {
                if (currentDataSource == searchResult)
                {
                    Player p = searchResult[index];
                    searchResult.RemoveAt(index);
                    RemoveByPlayerId(p.Id);
                    table.AddPlayer(p);
                    SetDataSource(searchResult);

                    if (searchResult.Count == 0)
                    {
                        SetDataSource(noResult);
                    }
                }
                else if (currentDataSource == availablePlayers)
                {
                    Player p = availablePlayers[index];
                    availablePlayers.RemoveAt(index);
                    table.AddPlayer(p);
                    SetDataSource(availablePlayers);
                }
            }       
        }

        private bool RemoveByPlayerId(long id)
        {
            for(int i = 0; i < availablePlayers.Count; ++i)
            {
                if (availablePlayers[i].Id == id)
                {
                    availablePlayers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        private GameType Index2GameType(int index)
        {
            if (index == 1)
            {
                return GameType.Rapid;
            }
            else if (index == 2)
            {
                return GameType.Classic;
            }

            return GameType.Blitz;
        }

        private void OnTablePlayerDeleted(Player p)
        {
            if (!showInactivePlayers && IsPlayerInactive(p))
            {
                inactivePlayers.Add(p);
                return;
            }

            availablePlayers.Insert(0, p);
            if (currentDataSource == searchResult)
            {
                if (p.Name.StartsWith(searchPlayer.Text, ignoreCase))
                {
                    searchResult.Insert(0, p);
                }
            }
            else if (currentDataSource == noResult)
            {
                if (p.Name.StartsWith(searchPlayer.Text, ignoreCase))
                {
                    searchResult.Insert(0, p);
                    currentDataSource = searchResult;
                }
            }
            SetDataSource(currentDataSource);
        }

        private void TournamentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.F3)
            {
                CountTable();
            }
        }

        private void CountTable()
        {
            if (table.IsComplete())
            {
                table.BeginDate = table.EndDate = dateTimePicker.Value;
                table.Name = textBoxTournamentName.Text;
                RateChangeForm rateChangeForm = new RateChangeForm(table);
                if (rateChangeForm.ShowDialog() == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Таблица заполнена не до конца или заполнена неверно!",
                   "Невозможно произвести расчет", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool IsPlayerActive(Player p)
        {
            return p.IsActive(currentRateType);
        }

        private bool IsPlayerInactive(Player p)
        {
            return !p.IsActive(currentRateType);
        }


        private List<Player> GetDisplayedPlayers(List<Player> allPlayers, List<Player> inactivePlayers)
        {
            if(showInactivePlayers)
            {
                return new List<Player>(allPlayers);
            }

            List<Player> res = new List<Player>();
            for (int i = 0; i < allPlayers.Count; ++i)
            {
                Player p = allPlayers[i];
                if (IsPlayerActive(p))
                {
                    res.Add(p);
                }
                else
                {
                    inactivePlayers.Add(p);
                }
            }
            return res;
        }

        private void ArrangeActiveInactiveLists()
        {
            availablePlayers.AddRange(inactivePlayers);
            inactivePlayers.Clear();
            availablePlayers  = GetDisplayedPlayers(availablePlayers, inactivePlayers);

            UpdateListBox();
        }

        private void searchPlayer_Enter(object sender, EventArgs e)
        {
            if (currentSearchText.Length == 0)
            {
                suppressTextChangeEvent = true;
                searchPlayer.ForeColor = System.Drawing.SystemColors.WindowText;
                searchPlayer.Text = currentSearchText;
            }
        }

        private void searchPlayer_Leave(object sender, EventArgs e)
        {
            if (currentSearchText.Length == 0)
            {
                suppressTextChangeEvent = true;
                searchPlayer.ForeColor = System.Drawing.SystemColors.ControlDark;
                searchPlayer.Text = "Введите имя для поиска";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void radioButtonShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowAll.Checked)
            {
                for (int i = 0; i < inactivePlayers.Count; ++i)
                {
                    availablePlayers.Add(inactivePlayers[i]);
                }

                inactivePlayers.Clear();

                UpdateListBox();
                showInactivePlayers = true;
            }
        }

        private void radioButtonShowActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowActive.Checked)
            {
                for (int i = 0; i < availablePlayers.Count; ++i)
                {
                    Player p = availablePlayers[i];
                    if (IsPlayerInactive(p))
                    {
                        inactivePlayers.Add(p);
                    }
                }

                availablePlayers.RemoveAll(IsPlayerInactive);
            }
            UpdateListBox();
            showInactivePlayers = false;
        }

        private void UpdatePlayerLists()
        {
        }
        private void radioButtonShort_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShort.Checked)
            {
                ITournamentTable newTable = new ShortTournamentTable();
                foreach (Player p in table.GetPlayers())
                {
                    newTable.AddPlayer(p);
                }
                newTable.Rounds = (int)numericUpDownRounds.Value;
                ReloadTableView(newTable);
                numericUpDownRounds.Enabled = true;
                //TODO move results to the new table
            }
        }

        private void radioButtonFull_CheckedChanged(object sender, EventArgs e)
        {
            ITournamentTable newTable = new TournamentTable();
            foreach (Player p in table.GetPlayers())
            {
                newTable.AddPlayer(p);
            }
            newTable.Rounds = (int)numericUpDownRounds.Value;
            ReloadTableView(newTable);
            numericUpDownRounds.Enabled = false;
        }

        private void toolStripButtonCount_Click(object sender, EventArgs e)
        {
            CountTable();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numericUpDownRounds_ValueChanged(object sender, EventArgs e)
        {
            table.Rounds = (int)numericUpDownRounds.Value;
        }

        private void radioButtonBlitz_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBlitz.Checked)
            {
                table.Type = GameType.Blitz;
            }
            currentRateType = GameType.Blitz;
            ArrangeActiveInactiveLists();
            UpdateNameTextBox();
        }

        private void radioButtonRapid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRapid.Checked)
            {
                table.Type = GameType.Rapid;
            }
            currentRateType = GameType.Rapid;
            ArrangeActiveInactiveLists();
            UpdateNameTextBox();
        }

        private void textBoxTournamentName_TextChanged(object sender, EventArgs e)
        {
            if (!supressNameChangeEvent)
            {
                nameWasChanged = true;
            }
            else
            {
                supressNameChangeEvent = false;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateNameTextBox();
        }
    }
}
