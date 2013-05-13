using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class CreateDbDialog : Form
    {
        public CreateDbDialog()
        {
            InitializeComponent();
            textBoxFolder.Text = Application.StartupPath;
        }

        private void buttonSearchFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Application.StartupPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFolder.Text = dialog.SelectedPath;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string GetFullDBFileName()
        {
            string ret = "";
            if (textBoxFolder.Text.Length > 0)
            {
                if (textBoxFolder.Text[textBoxFolder.Text.Length - 1] != '\\')
                {
                    ret = textBoxFolder.Text + "\\";
                }
            }
            ret += textBoxDbName.Text;

            return ret;
        }

        public bool AutoLoadDB
        {
            get
            {
                return checkBoxLoadDB.CheckState == CheckState.Checked;
            }
        }
    }
}
