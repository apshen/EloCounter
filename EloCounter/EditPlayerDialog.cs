using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class EditPlayerDialog : Form
    {
        private Player player;

        public EditPlayerDialog()
        {
            InitializeComponent();

            this.player = new Player();
            this.playerBindingSource.DataSource = player;
        }

        public EditPlayerDialog(Player p) : this()
        {
            this.Text = p.ToString();

            this.player = p.Clone();
            this.playerBindingSource.DataSource = player;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateFormData())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateFormData()
        {
            return true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
