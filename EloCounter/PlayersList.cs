using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class PlayersList : UserControl
    {
        public delegate void MouseDoubleClickEvent(ListViewItem item);
        public event MouseDoubleClickEvent OnItemDoubleClick;

        public delegate void MouseRightClickEvent(ListViewItem item);
        public event MouseRightClickEvent OnItemMouseRightClick;

        public delegate void ColumnHeadertClickEvent(PlayerSortType type);
        public event ColumnHeadertClickEvent OnColumnHeaderClick;

        public PlayersList()
        {
            InitializeComponent();
        }

        private void listPlayersView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = listPlayersView.HitTest(e.Location);
            if (hit.Item != null)
            {
                OnItemDoubleClick(hit.Item);
            }
        }

        private void listPlayersView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listPlayersView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    OnItemMouseRightClick(listPlayersView.FocusedItem);
                }
            }
        }

        public void HiglightSortedColumn(PlayerSortType type)
        {
            int index = GetColumnIndexBySortType(type);
            if (index >= 0)
            {
                foreach (ListViewItem item in listPlayersView.Items)
                {
                    item.SubItems[index].BackColor = System.Drawing.SystemColors.ControlLight;
                }
            }
        }

        public void UpdateColumnHeaders(GameType t)
        {
            rateColumnHeader.Text = "Рейтинг (" + GetRateTypeString(t) + ")";
        }

        private string GetRateTypeString(GameType t)
        {
            switch (t)
            {
                case GameType.Blitz:
                    return "блиц";
                case GameType.Rapid:
                    return "быстрые";
                case GameType.Classic:
                    return "классика";
            }

            return "";
        }

        private void listPlayersView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader column = this.listPlayersView.Columns[e.Column];
            OnColumnHeaderClick(GetSortTypeByColumn(column));
        }

        public List<Player> GetSelectedPlayers()
        {
            List<Player> selectedPlayers = new List<Player>();
            for (int i = 0; i < listPlayersView.SelectedItems.Count; ++i)
            {
                selectedPlayers.Add((Player)listPlayersView.SelectedItems[i].Tag);
            }

            return selectedPlayers;
        }

        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get
            {
                return listPlayersView.SelectedItems;
            }
        }

        public ListView.ListViewItemCollection Items
        {
            get
            {
                return listPlayersView.Items;
            }
        }

        public void Clear()
        {
            listPlayersView.Items.Clear();
        }

        public void InsertItem(ListViewItem item)
        {
            listPlayersView.Items.Add(item);
        }

        private PlayerSortType GetSortTypeByColumn(ColumnHeader ch)
        {
            PlayerSortType ret = PlayerSortType.Undefined;
            if (ch == this.lastNameColumnHeader)
            {
                ret = PlayerSortType.ByName;
            }
            else if (ch == this.rateColumnHeader)
            {
                ret = PlayerSortType.ByRate;
            }

            return ret;
        }

        private int GetColumnIndexBySortType(PlayerSortType type)
        {
            int index = -1;
            ColumnHeader ch = null;
            switch (type)
            {
                case PlayerSortType.ByRate:
                    ch = this.rateColumnHeader;
                    break;
                case PlayerSortType.ByName:
                    ch = this.lastNameColumnHeader;
                    break;
            }

            if (ch != null)
            {
                index = ch.Index;
            }

            return index;
        }

        private void listPlayersView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnItemDoubleClick(listPlayersView.FocusedItem);
            }
        }

        public ListViewItem FocusedItem
        {
            get
            {
                return listPlayersView.FocusedItem;
            }
            set
            {
                listPlayersView.FocusedItem = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return listPlayersView.SelectedIndices.Count > 0 ? listPlayersView.SelectedIndices[0]: -1;
            }
        }

        public ListViewItem this[int index]
        {
            get
            {
                return listPlayersView.Items[index];
            }
            set
            {
                listPlayersView.Items[index] = value;
            }
        }
    }
}
