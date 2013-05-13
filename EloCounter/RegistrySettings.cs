using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;


namespace EloCounter
{
    public class RegistrySettings
    {
        private static RegistryKey rkRoot = Registry.CurrentUser;
        private static RegistryKey rkOptions = OpenOptionsKey();

        private static string latestDBKeyName          = @"LatestOpenedDB";
        private static string sortTypeKeyName          = @"SortType";
        private static string showInactiveKeyName      = @"ShowInactivePlayers";
        private static string gameTypeKeyName          = @"GameType";
        private static string pageMarginsKeyName        = @"PageMargins";
        private static string pageFontKeyName          = @"Font";
        private static string pageHeaderFontKeyName    = @"HeaderFont";

        private static List<string> latestDbPaths = LoadLatestPaths();

        private static RegistryKey OpenOptionsKey()
        {
            RegistryKey k = null;
            try
            {
                k = rkRoot.OpenSubKey(@"Software\EloCounter", true);
                if (k == null)
                {
                    k = rkRoot.OpenSubKey(@"Software", true);
                    k = k.CreateSubKey(@"EloCounter");
                }
            }
            catch
            {
            }

            return k;
        }

        private static List<string> LoadLatestPaths()
        {
            List<string> l = new List<string>();
            try
            {
                if (rkOptions != null)
                {
                    string p = (string)rkOptions.GetValue(latestDBKeyName + "0");
                    if (p != null) l.Add(p);

                    p = (string)rkOptions.GetValue(latestDBKeyName + "1");
                    if (p != null) l.Add(p);

                    p = (string)rkOptions.GetValue(latestDBKeyName + "2");
                    if (p != null) l.Add(p);

                    p = (string)rkOptions.GetValue(latestDBKeyName + "3");
                    if (p != null) l.Add(p);

                    p = (string)rkOptions.GetValue(latestDBKeyName + "4");
                    if (p != null) l.Add(p);
                }
            }
            catch
            { 
            }

            return l;
        }

        public static string GetLatestOpenedDatabase()
        {
            if (latestDbPaths != null)
            {
                if (latestDbPaths.Count > 0)
                {
                    return latestDbPaths[0];
                }
            }

            return null;
        }

        public static List<string> GetLatestOpenedDatabaseList()
        {
            return latestDbPaths;
        }

        public static void SetLatestOpenedDatabase(string dbPath)
        {
            latestDbPaths.Remove(dbPath);
            latestDbPaths.Insert(0, dbPath);
            if (latestDbPaths.Count > 5)
            {
                latestDbPaths.RemoveRange(5, latestDbPaths.Count - 5);
            }
            SaveLatestPaths();
        }

        private static void SaveLatestPaths()
        {
            try
            {
                if (rkOptions != null)
                {
                    for (int i = 0; i < latestDbPaths.Count; ++i)
                    {
                        rkOptions.SetValue(latestDBKeyName + i.ToString(), latestDbPaths[i]);
                    }
                }
            }
            catch
            {
            }
        }

        public static PlayerSortType GetSortType()
        {
            PlayerSortType ret = PlayerSortType.ByRate;
            try
            {
                if (rkOptions != null)
                {
                    string p = (string)rkOptions.GetValue(sortTypeKeyName);
                    if (p != null)
                    {
                        Object o = Enum.Parse(typeof(PlayerSortType), p, true);
                        ret = (PlayerSortType)o;
                    }
                }
            }
            catch
            {
            }

            return ret;
        }

        public static void SetSortType(PlayerSortType type)
        {
            try
            {
                if (rkOptions != null)
                {
                    rkOptions.SetValue(sortTypeKeyName, type.ToString());
                }
            }
            catch
            {
            }
        }

        public static GameType GetGameType()
        {
            GameType ret = GameType.Blitz;
            try
            {
                if (rkOptions != null)
                {
                    string p = (string)rkOptions.GetValue(gameTypeKeyName);
                    if (p != null)
                    {
                        Object o = Enum.Parse(typeof(GameType), p, true);
                        ret = (GameType)o;
                    }
                }
            }
            catch
            {
            }

            return ret;
        }

        public static void SetGameType(GameType type)
        {
            try
            {
                if (rkOptions != null)
                {
                    rkOptions.SetValue(gameTypeKeyName, type.ToString());
                }
            }
            catch
            {
            }
        }

        public static bool GetShowInactivePlayersOption()
        {
            return GetBoolValue(showInactiveKeyName);
        }

        public static void SetShowInactivePlayersOption(bool value)
        {
            SetBoolValue(showInactiveKeyName, value);
        }

        public static PrintPageSettings GetPageSettings()
        {
            PrintPageSettings ps = new PrintPageSettings();
            ps.Font = GetFont();
            ps.HeaderFont = GetHeaderFont();
            int [] margins = GetPageMargins();
            ps.TopMargin = margins[0];
            ps.BottomMargin = margins[1];
            ps.LeftMargin = margins[2];
            ps.RightMargin = margins[3];
            ps.HeaderMargin = margins[4];
            ps.NameBoxWidth = margins[5];

            return ps;
        }

        public static void SetPageSettings(PrintPageSettings ps)
        {
            SetFont(ps.Font);
            SetHeaderFont(ps.HeaderFont);
            SetMargins(new int[]
                        {
                            ps.TopMargin,
                            ps.BottomMargin,
                            ps.LeftMargin,
                            ps.RightMargin,
                            ps.HeaderMargin,
                            ps.NameBoxWidth
                        }
                      );
        }

        private static Font GetFont()
        {
            Font ret = new Font("Times New Roman", 14);
            try
            {
                if (rkOptions != null)
                {
                    string p = (string)rkOptions.GetValue(pageFontKeyName);
                    if (p != null)
                    {
                        string[] fontStrings = p.Split(new char[] { ',' });
                        ret = new Font(fontStrings[0], Convert.ToInt32(fontStrings[1]),(FontStyle) Enum.Parse(typeof(FontStyle), fontStrings[2], true));
                    }
                }
            }
            catch
            {
            }

            return ret;
        }

        private static void SetFont(Font f)
        {
            try
            {
                if (rkOptions != null)
                {
                    rkOptions.SetValue(pageFontKeyName, 
                        f.Name + "," + ((int)Math.Round(f.Size, 0)).ToString() + "," + f.Style.ToString());
                }
            }
            catch
            {
            }
        }

        private static Font GetHeaderFont()
        {
            Font ret = new Font("Times New Roman", 16, FontStyle.Bold);
            try
            {
                if (rkOptions != null)
                {
                    string p = (string)rkOptions.GetValue(pageHeaderFontKeyName);
                    if (p != null)
                    {
                        string[] fontStrings = p.Split(new char[] { ',' });
                        ret = new Font(fontStrings[0], Convert.ToInt32(fontStrings[1]), (FontStyle)Enum.Parse(typeof(FontStyle), fontStrings[2], true));
                    }
                }
            }
            catch
            {
            }

            return ret;
        }

        private static void SetHeaderFont(Font f)
        {
            try
            {
                if (rkOptions != null)
                {
                    rkOptions.SetValue(pageHeaderFontKeyName,
                        f.Name + "," + ((int)Math.Round(f.Size, 0)).ToString() + "," + f.Style.ToString());
                }
            }
            catch
            {
            }
        }

        private static int [] GetPageMargins()
        {
            int [] ret = new int [] {90, 100, 40, 40, 20, 300};
            try
            {
                if (rkOptions != null)
                {
                    string p = (string)rkOptions.GetValue(pageMarginsKeyName);
                    if (p != null)
                    {
                        string[] marginStrings = p.Split(new char[] { ' ' });
                        ret = new int [6]{
                                            Convert.ToInt32(marginStrings[0]),
                                            Convert.ToInt32(marginStrings[1]),
                                            Convert.ToInt32(marginStrings[2]),
                                            Convert.ToInt32(marginStrings[3]),
                                            Convert.ToInt32(marginStrings[4]),
                                            Convert.ToInt32(marginStrings[5])
                                        };
                    }
                }
            }
            catch
            {
            }

            return ret;

        }

        private static void SetMargins(int [] margins)
        {
            try
            {
                if (rkOptions != null)
                {
                    rkOptions.SetValue(pageMarginsKeyName,
                                       margins[0].ToString() + " " +
                                       margins[1].ToString() + " " +
                                       margins[2].ToString() + " " +
                                       margins[3].ToString() + " " +
                                       margins[4].ToString() + " " +
                                       margins[5].ToString()
                                       );
                }
            }
            catch
            {
            }
        }

        private static bool GetBoolValue(string keyName, bool defValue = false)
        {
            string str = bool.FalseString;
            bool ret = false;
            try
            {
                if (rkOptions != null)
                {
                    str = (String)rkOptions.GetValue(keyName);
                    if (str == null)
                    {
                        str = defValue.ToString();
                    }
                }
                ret = bool.Parse(str);
            }
            catch
            {
                ret = defValue;
            }

            return ret;
        }

        private static void SetBoolValue(string keyName, bool value)
        {
            try
            {
                if (rkOptions != null)
                {
                    rkOptions.SetValue(keyName, value);
                }
            }
            catch
            {
            }
        }


    }
}