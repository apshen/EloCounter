using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public partial class PrintPageSetupDialog : Form
    {
        List<Player> players;
        PrintPageSettings pageSettings;

        public PrintPageSetupDialog(PrintPageSettings ps, List<Player> pl)
        {
            InitializeComponent();
            
            players = pl;

            pageSettings = ps;

            
            SetFontText(pageSettings.Font);
            SetHeaderFontText(pageSettings.HeaderFont);
            numericTopMargin.Value = ps.TopMargin;
            numericBottomMargin.Value = ps.BottomMargin;
            numericLeftMargin.Value = ps.LeftMargin;
            numericRightMargin.Value = ps.RightMargin;
            numericHeaderMargin.Value = ps.HeaderMargin;
            numericNameBox.Value = ps.NameBoxWidth;

        }

        private void comboBoxFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SetFontText(fontDialog.Font);
                pageSettings.Font = fontDialog.Font;
            }
        }

        private void SetFontText(Font f)
        {
            comboBoxFont.Text = f.Name + ", " + ((int)Math.Round(f.Size, 0)).ToString();
            if (f.Style != FontStyle.Regular)
            {
                comboBoxFont.Text += ", " + f.Style.ToString();
            }
        }

        private void comboBoxFont_Enter(object sender, EventArgs e)
        {
            label1.Select();
        }

        private void comboBoxHeaderFont_Enter(object sender, EventArgs e)
        {
            label2.Select();
        }

        private void comboBoxHeaderFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SetHeaderFontText(fontDialog.Font);
                pageSettings.HeaderFont = fontDialog.Font;
            }
        }

        private void SetHeaderFontText(Font f)
        {
            comboBoxHeaderFont.Text = f.Name + ", " + ((int)Math.Round(f.Size, 0)).ToString();
            if (f.Style != FontStyle.Regular)
            {
                comboBoxHeaderFont.Text += ", " + f.Style.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RedrawPreview()
        {
            new ListPrinter(pageSettings, printPreviewControl).Print(players, GameType.Blitz);
        }

        private void comboBoxFont_TextChanged(object sender, EventArgs e)
        {
            RedrawPreview();
        }

        private void comboBoxHeaderFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawPreview();
        }

        private void numericTopMargin_ValueChanged(object sender, EventArgs e)
        {
            pageSettings.TopMargin = (int)numericTopMargin.Value;
            RedrawPreview();
        }

        private void numericLeftMargin_ValueChanged(object sender, EventArgs e)
        {
            pageSettings.LeftMargin = (int)numericLeftMargin.Value;
            RedrawPreview();
        }

        private void numericHeaderMargin_ValueChanged(object sender, EventArgs e)
        {
            pageSettings.HeaderMargin = (int)numericHeaderMargin.Value;
            RedrawPreview();
        }

        private void numericBottomMargin_ValueChanged(object sender, EventArgs e)
        {
            pageSettings.BottomMargin = (int)numericBottomMargin.Value;
            RedrawPreview();
        }

        private void numericRightMargin_ValueChanged(object sender, EventArgs e)
        {
            pageSettings.RightMargin = (int)numericRightMargin.Value;
            RedrawPreview();
        }

        private void numericNameBox_ValueChanged(object sender, EventArgs e)
        {
            pageSettings.NameBoxWidth = (int)numericNameBox.Value;
            RedrawPreview();
        }
    }
}
