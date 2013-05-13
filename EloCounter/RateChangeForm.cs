using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class RateChangeForm : Form
    {
        private ITournamentTable table;

        public RateChangeForm()
        {
            InitializeComponent();
        }

        public RateChangeForm(ITournamentTable tournamentTable) : this()
        {
            table = tournamentTable;
            InitListView();
            InitTitle();
        }

        private void InitListView()
        {
            List<Player> l = table.GetPlayers();
            List<Game> games = table.GetGames();
            int counter = 1;
            foreach (Player p in l)
            {

                int newRate = EloTable.GetNewRate(p.GetRate(table.GetGameType()), table.GetAverageRate(p), table.GetMaxPoints(p), table.GetResult(p).Points);
                ListViewItem item = new ListViewItem(new[] 
                                                            { 
                                                              counter.ToString(), 
                                                              p.ToString(), 
                                                              p.GetRate(table.GetGameType()).ToString(),
                                                              newRate.ToString(),
                                                              (newRate - p.GetRate(table.GetGameType())).ToString()
                                                            }
                                                    );
                listPlayersView.Items.Add(item);
                ++counter;
            }
        }

        private void InitTitle()
        {
            this.Text += " [" + table.GetTournament().Name + "]";
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RateChangeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
