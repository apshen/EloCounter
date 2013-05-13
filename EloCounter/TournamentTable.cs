using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class TournamentTable : UserControl, ITournamentTable//, UserControl//, ITournament
    {
        private const int playersStartIndex = 2;
        private const int playersEndIndex = 2;
        private int filledGames;
        private GameType gameType;
        private int swapRowIndex1 = 0;
        private int swapRowIndex2 = 0;

        public event PlayerDeleteEvent OnPlayerDelete;

        public TournamentTable()
        {
            InitializeComponent();
            OnPlayerDelete += new PlayerDeleteEvent(this.PlayerDeleteCallback);
        }

        public void AddPlayer(Player p)
        {
            int c = table.ColumnCount;
            int n = table.RowCount;
            int r = table.Rows.Add();

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
            {
                HeaderText = (n + 1).ToString(),
                Width = 50,
                SortMode = DataGridViewColumnSortMode.Programmatic,
                MaxInputLength = 3,
                ReadOnly = true,
                Name = "colPlayer" + n.ToString()
            };

            table.Columns.Insert(n + playersStartIndex, col);

            table.Rows[r].Cells[0].Value = (n + 1).ToString();
            table.Rows[r].Cells[1].Value = p.GetNameWithRate(Type);
            table.Rows[r].Tag = p;

            table[n + playersStartIndex, n].Style.BackColor = System.Drawing.SystemColors.WindowFrame;
            CountTable();
        }

        private void DeletePlayer(int rowIndex)
        {
            for (int i = rowIndex + 1; i < table.RowCount; ++i)
            {
                table.Rows[i].Cells[0].Value = i.ToString();
            }
            for (int i = playersStartIndex; i < table.ColumnCount - playersEndIndex; ++i)
            {
                table.Columns[i].HeaderText = (i - playersStartIndex + 1).ToString();
                table.Columns[i].Name = "colPlayer" + (i - playersStartIndex).ToString();
                DataGridViewCell c = table[i, rowIndex];
                if (c.Tag != null && (GameResult)c.Tag != GameResult.Unknown)
                {
                    --filledGames;
                }
            }

            table.Rows.RemoveAt(rowIndex);
            table.Columns.RemoveAt(rowIndex + playersStartIndex);
            CountTable();
        }

        private void table_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Player p = GetPlayer(e.RowIndex);
                DeletePlayer(e.RowIndex);
                OnPlayerDelete(p);
            }
        }

        private bool IsGameCell(int rowIndex, int colIndex)
        {
            return rowIndex >= 0 && colIndex >= 0 &&
                   colIndex >= playersStartIndex &&
                   colIndex - playersStartIndex < table.RowCount &&
                   colIndex - playersStartIndex != rowIndex;
        }

        private bool IsGameCell(DataGridViewCell c)
        {
            return IsGameCell(c.RowIndex, c.ColumnIndex);
        }

        private void table_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.Cell == null || e.StateChanged != DataGridViewElementStates.Selected)
            {
                return;
            }
            e.Cell.Selected = false;
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsGameCell(e.RowIndex, e.ColumnIndex))
            {
                DataGridViewCell c = table[e.ColumnIndex, e.RowIndex];
                Rectangle rec = table.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                foreach (ToolStripMenuItem item in resultContextMenu.Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }

                if (c.Tag != null)
                {
                    GameResult r = (GameResult)c.Tag;

                    switch (r)
                    {
                        case GameResult.Lose:
                            zeroToolStripMenuItem.CheckState = CheckState.Checked;
                            break;
                        case GameResult.Win:
                            oneToolStripMenuItem.CheckState = CheckState.Checked;
                            break;
                        case GameResult.Draw:
                            drawToolStripMenuItem.CheckState = CheckState.Checked;
                            break;
                        case GameResult.Unknown:
                            unknownToolStripMenuItem.CheckState = CheckState.Checked;
                            break;
                    }
                }
                else
                {
                    unknownToolStripMenuItem.CheckState = CheckState.Checked;
                    c.Tag = GameResult.Unknown;
                }

                resultContextMenu.Show(table, rec.Location);
                resultContextMenu.Tag = c;
            }
        }

        DataGridViewTextBoxCell GetOpponentCell(DataGridViewTextBoxCell c)
        {
            return (DataGridViewTextBoxCell)table[c.RowIndex + playersStartIndex, c.ColumnIndex - playersStartIndex];
        }

        private void CountTable()
        {
            if (IsComplete())
            {
                List<int> scores = new List<int>();
                for (int i = 0; i < table.RowCount; ++i)
                {
                    int playerScore = 0;
                    for (int j = 0; j < table.RowCount; ++j)
                    {
                        if (i != j)
                        {
                            GameResult r = (GameResult)table[j + playersStartIndex, i].Tag;
                            switch (r)
                            {
                                case GameResult.Win:
                                    playerScore += 2;
                                    break;
                                case GameResult.Draw:
                                    playerScore += 1;
                                    break;
                            }
                        }
                    }
                    table[colPoints.Index, i].Value = (playerScore / 2).ToString() +
                                                                (((playerScore % 2) != 0) ? " 1/2" : "");
                    table[colPoints.Index, i].Tag = playerScore;
                    scores.Add(playerScore);
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
                    table[colPoints.Index, i].Value = "";
                    table[colPlace.Index, i].Value = "";
                }
            }
        }

        public bool IsComplete()
        {
            return (table.Rows.Count > 1) && (filledGames == (table.Rows.Count * (table.Rows.Count - 1)) / 2);
        }

        private void SetGameresultAndUpdate(DataGridViewTextBoxCell c, GameResult r)
        {
            GameResult old = SetGameresult(c, r);
            if(r == GameResult.Unknown && old != GameResult.Unknown)
            {
                --filledGames;
            }
            else if (old == GameResult.Unknown && r != GameResult.Unknown)
            {
                ++filledGames;
            }

            CountTable();
        }

        private GameResult SetGameresult(DataGridViewTextBoxCell c, GameResult r)
        {
            DataGridViewTextBoxCell o = GetOpponentCell(c);
            GameResult oldR = (GameResult)c.Tag;
            switch (r)
            {
                case GameResult.Draw:
                    c.Tag = o.Tag = GameResult.Draw;
                    c.Value = o.Value = "1/2";
                    break;
                case GameResult.Lose:
                    c.Tag = GameResult.Lose;
                    c.Value = "0";
                    o.Tag = GameResult.Win;
                    o.Value = "1";
                    break;
                case GameResult.Win:
                    c.Tag = GameResult.Win;
                    c.Value = "1";
                    o.Tag = GameResult.Lose;
                    o.Value = "0";
                    break;
                case GameResult.Unknown:
                    c.Tag = o.Tag = GameResult.Unknown;
                    c.Value = o.Value = "";
                    break;
            }
            return oldR;
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

        private void table_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (IsGameCell(e.RowIndex, e.ColumnIndex))
                {
                    editGameContextMenuStrip.Show(e.Location);
                    DataGridViewCell c = table[e.ColumnIndex, e.RowIndex];
                    editGameContextMenuStrip.Tag = c;
                    editGameContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void zeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)resultContextMenu.Tag;
            SetGameresultAndUpdate(c, GameResult.Lose);
        }

        private void oneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)resultContextMenu.Tag;
            SetGameresultAndUpdate(c, GameResult.Win);
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)resultContextMenu.Tag;
            SetGameresultAndUpdate(c, GameResult.Draw);
        }

        private void unknownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)resultContextMenu.Tag;
            SetGameresultAndUpdate(c, GameResult.Unknown);
        }

        private void PlayerDeleteCallback(Player p)
        {
            return;
        }

        private Player GetPlayer(int index)
        {
            return (Player)table.Rows[index].Tag;
        }

        int GetWhitePlayerIndex(int p1, int p2)
        {
            ++p1;
            ++p2;
            int pWhite = p1;

            if (((table.RowCount & 1) == 0) && (p1 == table.RowCount || p2 == table.RowCount))
            {
                if (p1 == table.RowCount)
                {
                    pWhite = (p2 > table.RowCount / 2) ? p1 : p2;
                }
                else
                {
                    pWhite = (p1 > table.RowCount / 2) ? p2 : p1;
                }
            }
            else
            {
                if (((p1 + p2) & 1) == 0)
                {
                    pWhite = (p1 > p2) ? p1 : p2;
                }
                else
                {
                    pWhite = (p1 < p2) ? p1 : p2;
                }
            }

            return pWhite - 1;
        }

        Player GetWhitePlayer(int p1, int p2)
        {
            return GetPlayer(GetWhitePlayerIndex(p1, p2));
        }

        Player GetBlackPlayer(int p1, int p2)
        {
            return GetPlayer(GetWhitePlayerIndex(p1, p2) == p1 ? p2 : p1);  
        }

        private GameResult GetGameResult(int p1, int p2)
        {
            DataGridViewTextBoxCell c = (DataGridViewTextBoxCell)table[p2 + playersStartIndex, p1];
            if (c.Tag != null)
            {
                if (GetWhitePlayerIndex(p1, p2) != c.RowIndex)
                {
                    c = GetOpponentCell(c);
                }
                return (GameResult)c.Tag;
            }
            return GameResult.Unknown;
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

        private void SwapPlayers(int index1, int index2)
        {
            DataGridViewRow t1 = table.Rows[index1];
            DataGridViewRow t2 = table.Rows[index2];
            table.Rows[index1].Cells["colPlayer" + index1.ToString()].Style.BackColor = System.Drawing.SystemColors.Window;
            table.Rows[index2].Cells["colPlayer" + index2.ToString()].Style.BackColor = System.Drawing.SystemColors.Window;

            if (index1 < index2)
            {
                table.Rows.RemoveAt(index1);
                table.Rows.RemoveAt(index2 - 1);
                table.Rows.Insert(index2 - 1, t1);
                table.Rows.Insert(index1, t2);

            }
            else
            {
                table.Rows.RemoveAt(index2);
                table.Rows.RemoveAt(index1 - 1);
                table.Rows.Insert(index1 - 1, t2);
                table.Rows.Insert(index2, t1);
            }

            string temp = (string)table.Rows[index1].Cells["colNumber"].Value;

            table.Rows[index1].Cells["colNumber"].Value = table.Rows[index2].Cells["colNumber"].Value;
            table.Rows[index2].Cells["colNumber"].Value = temp;

            table.Rows[index1].Cells["colPlayer" + index1.ToString()].Style.BackColor = System.Drawing.SystemColors.WindowFrame;
            table.Rows[index2].Cells["colPlayer" + index2.ToString()].Style.BackColor = System.Drawing.SystemColors.WindowFrame;

            if (index1 > index2)
            {
                int t = index1;
                index1 = index2;
                index2 = t;
            }
            for (int i = 0; i < table.RowCount; ++i)
            {
                DataGridViewTextBoxCell c1 = (DataGridViewTextBoxCell)table[index1 + playersStartIndex, i];
                DataGridViewTextBoxCell c2 = (DataGridViewTextBoxCell)table[index2 + playersStartIndex, i];

                if (c1.Tag == null)
                {
                    c1.Tag = GameResult.Unknown;
                }
                if (c2.Tag == null)
                {
                    c2.Tag = GameResult.Unknown;
                }
                if (index2 != i)
                {
                    GameResult t = (GameResult)c2.Tag;
                    SetGameresult(c2, (GameResult)c1.Tag);
                    if (index1 != i)
                    {
                        SetGameresult(c1, t);
                    }
                    else
                    {
                        SetGameresult(c1, GameResult.Unknown);
                    }
                }
                else
                {
                    SetGameresult(c2, GameResult.Unknown);
                }
            }
            CountTable();
        }

        private void table_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            swapRowIndex1 = e.RowIndex;
        }

        private void table_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            swapRowIndex2 = e.RowIndex;
            if (swapRowIndex1 != swapRowIndex2 && swapRowIndex1 >= 0 && swapRowIndex2 >= 0)
            {
                SwapPlayers(swapRowIndex1, swapRowIndex2);
            }
        }

        //ITournament

        public int Rounds { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

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
            List<Game> ret = new List<Game>();
            for (int i = 0; i < table.RowCount; ++i)
            {
                for (int j = i + 1; j < table.RowCount; ++j)
                {
                    GameResult res = GetGameResult(i, j);
                    if (res != GameResult.Unknown)
                    {
                        Game g = new Game()
                        {
                            WhitePlayer = GetWhitePlayer(i, j),
                            BlackPlayer = GetBlackPlayer(i, j),
                            Result = res,
                            PlayedOn = BeginDate,
                        };
                        ret.Add(g);
                    }
                }
            }
            return ret;
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
                Rounds = 1, //TODO
                Type = gameType,
                Name = this.Name,
                BeginOn = BeginDate,
                EndOn = EndDate 
            };
        }

        public int GetMaxPoints(Player p)
        {
            return 2 * (table.RowCount - 1); //TODO many rounds
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