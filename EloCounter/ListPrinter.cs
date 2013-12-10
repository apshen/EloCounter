using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EloCounter
{
    public class ListPrinter
    {
        const int maxPlayersInOneRow = 11;

        int printedPages;
        int printedLines;
        int linesOnCurrentPage;
        bool printInOneRow = false;
        int linesToPrint;

        private Font printFont;
        private Font headerFont;

        private float nameBoxWidth;
        private PrintPageSettings pageSettings;

        private float headerHeight;
        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        private PrintPreviewControl previewControl;

        List<Player> players;
        GameType type;

        public ListPrinter(PrintPageSettings ps, PrintPreviewControl pc = null)
        {
            pageSettings = ps;
            printFont = ps.Font;
            headerFont = ps.HeaderFont;
            nameBoxWidth = ps.NameBoxWidth;
            Margins margins = new Margins
            {
                Left = ps.LeftMargin,
                Right = ps.RightMargin,
                Top = ps.TopMargin,
                Bottom = ps.BottomMargin
            };

            doc.DefaultPageSettings.Margins = margins;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            previewControl = pc;
        }

        public void Print(List<Player> pl, GameType t)
        {
            players = pl;
            type = t;

            if (players.Count <= maxPlayersInOneRow)
            {
                printInOneRow = true;
                linesToPrint = players.Count;
            }
            else
            {
                printInOneRow = false;
                linesToPrint = (players.Count + 1) / 2;
            }

            if (previewControl != null)
            {
                previewControl.Document = doc;
                previewControl.InvalidatePreview();
            }
            else
            {
                previewDialog.Width = 600;
                previewDialog.Height = 800;
                previewDialog.Document = doc;
                previewDialog.ShowDialog();
            }
        }

        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string p in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = p;
                if (settings.IsDefaultPrinter)
                    return p;
            }

            return "";
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            linesOnCurrentPage = 0;
            double linesPerPage = 0;
            if (printedPages == 0)
            {
                DrawHeader(e);
                linesPerPage = Math.Floor((e.MarginBounds.Height - headerHeight - pageSettings.HeaderMargin) 
                                / printFont.GetHeight(e.Graphics));
            }
            else
            {
                linesPerPage = Math.Floor(e.MarginBounds.Height / printFont.GetHeight(e.Graphics));
            }

            
            while (linesOnCurrentPage < linesPerPage && printedLines < linesToPrint)
            {
                DrawNextLine(e);
                ++printedLines;
                ++linesOnCurrentPage;
            }

            if (printedLines != linesToPrint)
            {
                e.HasMorePages = true;
                ++printedPages;
            }
            else
            {
                e.HasMorePages = false;
                Reset();
            }
        }

        private void DrawNextLine(PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            if (printedPages == 0) topMargin += headerHeight + pageSettings.HeaderMargin;
            float lineHeight = printFont.GetHeight(e.Graphics);
            float rightPos = e.MarginBounds.Right - nameBoxWidth;
            float yPos = topMargin + (linesOnCurrentPage * lineHeight);

            Player pl = players[printedLines];
            Player pr = (printedLines + linesToPrint < players.Count) ? players[printedLines + linesToPrint] : null;

            int indexLeft = printedLines + 1;
            int indexRight = printedLines + linesToPrint + 1;

            //left column
            RectangleF numberRec = new RectangleF(leftMargin, yPos, 0, lineHeight);
            e.Graphics.DrawString(indexLeft.ToString(), printFont, Brushes.Black, numberRec);

            RectangleF playerRec = new RectangleF(leftMargin + nameBoxWidth * 0.13f, yPos, 0, lineHeight);
            e.Graphics.DrawString(pl.Name, printFont, Brushes.Black, playerRec);

            RectangleF rateRec = new RectangleF(leftMargin + nameBoxWidth * 0.75f, yPos, 0, lineHeight);
            e.Graphics.DrawString(pl.GetRate(type).ToString(), printFont, Brushes.Black, rateRec);

            //right column
            if (pr != null && !printInOneRow)
            {
                numberRec = new RectangleF(rightPos, yPos, 0, lineHeight);
                e.Graphics.DrawString(indexRight.ToString(), printFont, Brushes.Black, numberRec);

                playerRec = new RectangleF(rightPos + nameBoxWidth * 0.13f, yPos, 0, lineHeight);
                e.Graphics.DrawString(pr.Name, printFont, Brushes.Black, playerRec);

                rateRec = new RectangleF(rightPos + nameBoxWidth * 0.75f, yPos, 0, lineHeight);
                e.Graphics.DrawString(pr.GetRate(type).ToString(), printFont, Brushes.Black, rateRec);
            }
        }

        private void DrawHeader(PrintPageEventArgs e)
        {
            string str = "Рейтинг - лист по " + GetGameTypeString(type);
            SizeF r = e.Graphics.MeasureString(str, headerFont);
            e.Graphics.DrawString(str, headerFont, Brushes.Black, (e.PageBounds.Width - r.Width) / 2, e.MarginBounds.Top);
            headerHeight += r.Height;

            str = "по состоянию на " + DateTime.Now.ToString("dd.MM.yyyy");
            r = e.Graphics.MeasureString(str, printFont);
            e.Graphics.DrawString(str, printFont, Brushes.Black, (e.PageBounds.Width - r.Width) / 2, e.MarginBounds.Top + headerHeight);
            headerHeight += r.Height;
        }

        string GetGameTypeString(GameType t)
        {
            switch (t)
            {
                case GameType.Blitz:
                    return "блицу";
                case GameType.Rapid:
                    return "быстрым шахматам";
                case GameType.Classic:
                    return "классическим шахматам";
            }
            return "";
        }

        private void Reset()
        {
            printedPages = 0;
            printedLines = 0;
            headerHeight = 0;
            linesOnCurrentPage = 0;
        }
    }
}