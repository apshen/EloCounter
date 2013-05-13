using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class ShortTournamentTable : UserControl, ITournamentTable
    {
        private const int playersStartIndex = 2;
        private GameType gameType;
        private int nRounds = 1;

        public ShortTournamentTable()
        {
            InitializeComponent();
        }

        private void table_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.Cell == null || e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            e.Cell.Selected = false; 
        }

        private void table_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Player p = GetPlayer(e.RowIndex);
                DeletePlayer(e.RowIndex);
                OnPlayerDelete(p);
            }
        }

        private void DeletePlayer(int rowIndex)
        {
            for (int i = rowIndex + 1; i < table.RowCount; ++i)
            {
                table.Rows[i].Cells[0].Value = i.ToString();
            }

            table.Rows.RemoveAt(rowIndex);
            CountTable();
        }

        public GameType Type
        {
            get
            {
                return gameType;
            }
            set
            {
                gameType = value;
                for (int i = 0; i < table.RowCount; ++i)
                {
                    Player p = (Player)table.Rows[i].Tag;
                    table.Rows[i].Cells[1].Value = p.GetNameWithRate(gameType);
                }
            }
        }

        private Player GetPlayer(int index)
        {
            return (Player)table.Rows[index].Tag;
        }

        private int GetIndexByPlayer(Player p)
        {
            for (int i = 0; i < table.RowCount; ++i)
            {
                if (GetPlayer(i).Id == p.Id)
                {
                    return i;
                }
            }
            return -1;
        }
        private void table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)table[e.ColumnIndex, e.RowIndex];
            if (e.ColumnIndex == colPoints.Index && c.Value != null)
            {
                string input = (string)c.Value;
                input.Trim();
                int half = 0;
                if (input.EndsWith(".5") || input.EndsWith(",5"))
                {
                    half = 1;
                    input = input.Substring(0, input.Length - 2);
                }

                try
                {
                    int pts = Convert.ToInt32(input) * 2 + half;
                    c.Tag = pts;
                    CountTable();
                }
                catch
                {
                    MessageBox.Show("Введено недопустимое значение!",
                                     "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    c.Value = "";
                }
            }
        }

        private void table_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
        }

        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (table.CurrentCell == table[colPoints.Index, table.RowCount - 1])
                {
                    table.CurrentCell = null;// table[colPoints.Index, 0];
                }
            }
        }

        //ITournamentTable
        public event PlayerDeleteEvent OnPlayerDelete;

        public void AddPlayer(Player p)
        {
            int n = table.RowCount;
            int r = table.Rows.Add();

            table.Rows[r].Cells[0].Value = (n + 1).ToString();
            table.Rows[r].Cells[1].Value = p.GetNameWithRate(Type);
            table.Rows[r].Tag = p;
            CountTable();
        }

        public bool IsComplete()
        {
            if (table.RowCount == 0)
            {
                return false;
            }

            int sumPoints = 0;
            for (int i = 0; i < table.RowCount; ++i)
            {
                object pts = table.Rows[i].Cells["colPoints"].Tag;
                if (pts != null)
                {
                    sumPoints += (int)pts;
                }
                else
                {
                    return false;
                }
            }
            return sumPoints == Rounds * table.RowCount * (table.RowCount - 1);
        }

        private void CountTable()
        {
            if (IsComplete())
            {
                List<int> scores = new List<int>();
                for (int i = 0; i < table.RowCount; ++i)
                {
                    scores.Add((int)table.Rows[i].Cells["colPoints"].Tag);
                }
                List<int> sortedScores = new List<int>(scores);
                sortedScores.Sort();
                for (int i = 0; i < table.RowCount; ++i)
                {
                    int ps = scores.Count - sortedScores.FindIndex(delegate(int x) { return x == scores[i]; });
                    int pe = scores.Count - sortedScores.FindLastIndex(delegate(int x) { return x == scores[i]; });
                    table[colPlace.Index, i].Value = ((ps == pe) ? ps.ToString() : pe.ToString() + "-" + ps.ToString());
                }
            }
            else
            {
                for (int i = 0; i < table.RowCount; ++i)
                {
                    table[colPlace.Index, i].Value = "";
                }
            }           
        }


        public int Rounds
        {
            get
            {
                return nRounds;
            }

            set
            {
                nRounds = value;
                CountTable();
            }
        }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        //ITournament

        public List<Player> GetPlayers()
        {
            List<Player> ret = new List<Player>();
            for (int i = 0; i < table.RowCount; ++i)
            {
                ret.Add(GetPlayer(i));
            }
            return ret;
        }

        public List<Game> GetGames()
        {
            return new List<Game>();
        }

        public int GetAverageRate(Player p)
        {
            int sum = 0;
            for (int i = 0; i < table.RowCount; ++i)
            {
                sum += GetPlayer(i).GetRate(Type);
            }

            return EloTable.DivideRound(sum, table.RowCount);
        }

        public Tournament GetTournament()
        {
            return new Tournament()
            {
                Rounds = this.Rounds,
                Type = gameType,
                Name = this.Name,
                BeginOn = BeginDate,
                EndOn = EndDate
            };
        }

        public int GetMaxPoints(Player p)
        {
            return 2 * (table.RowCount - 1) * Rounds;
        }

        public TournamentResult GetResult(Player p)
        {
            int index = GetIndexByPlayer(p);
            return new TournamentResult()
            {
                Participant = p,
                //Event = GetTournament(),
                Points = (int)table.Rows[index].Cells["colPoints"].Tag,
                SeqNumber = index + 1,
            };
        }

        public GameType GetGameType()
        {
            return Type;
        }
    }
}
