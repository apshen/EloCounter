using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace EloCounter
{
    public class DBManager
    {
        private enum DBVersion
        {
            Version001,
            Version002,
            VersionUnknown
        }

        private SQLiteConnection dbConnection;
        private SQLiteCommand insertPlayerCmd = new SQLiteCommand();
        private SQLiteCommand editPlayerCmd   = new SQLiteCommand();
        private SQLiteCommand editPlayerUpdateTimeCmd = new SQLiteCommand();
        private SQLiteCommand selectAllCmdSortBlitz = new SQLiteCommand();
        private SQLiteCommand selectAllCmdSortRapid = new SQLiteCommand();
        private SQLiteCommand selectAllCmdSortClassic = new SQLiteCommand();
        private SQLiteCommand selectAllCmdSortName = new SQLiteCommand();
        private SQLiteCommand selectAllCmd = new SQLiteCommand();
        private SQLiteCommand removePlayerCmd = new SQLiteCommand();
        private SQLiteCommand createDbCmd  = new SQLiteCommand();
        private SQLiteCommand insertTournamentCmd = new SQLiteCommand();
        private SQLiteCommand insertResultCmd = new SQLiteCommand();
        private SQLiteCommand selectLatestTournamentCmd = new SQLiteCommand();
        private SQLiteCommand insertGameCmd = new SQLiteCommand();

        public DBManager()
        {
            string insertPlayerSQL = @"INSERT INTO players(name, blitz_rate, rapid_rate, classic_rate,
                                                           blitz_updatedon, rapid_updatedon, classic_updatedon)
                                       VALUES(@name, @rblitz, @rrapid, @rclassic, @blitzup, @rapidup, @classicup);";
            insertPlayerCmd.CommandText = insertPlayerSQL;

            string editPlayerSQL = @"UPDATE players SET 
                                          name=@name, blitz_rate=@rblitz, rapid_rate=@rrapid, classic_rate = @rclassic,
                                          blitz_updatedon=@blitzup, rapid_updatedon=@rapidup, classic_updatedon = @classicup
                                     WHERE id=@id;";
            editPlayerCmd.CommandText = editPlayerSQL;

            string selectAllSQLSortBlitz = @"SELECT name, blitz_rate, rapid_rate, classic_rate,
                                             blitz_updatedon, rapid_updatedon, classic_updatedon, id
                                 FROM players ORDER BY blitz_rate DESC;";
            selectAllCmdSortBlitz.CommandText = selectAllSQLSortBlitz;

            string selectAllSQLSortRapid = @"SELECT name, blitz_rate, rapid_rate, classic_rate,
                                             blitz_updatedon, rapid_updatedon, classic_updatedon, id
                                 FROM players ORDER BY rapid_rate DESC;";
            selectAllCmdSortRapid.CommandText = selectAllSQLSortRapid;


            string selectAllSQLSortClassic = @"SELECT name, blitz_rate, rapid_rate, classic_rate,
                                             blitz_updatedon, rapid_updatedon, classic_updatedon, id
                                 FROM players ORDER BY classic_rate DESC;";

            selectAllCmdSortClassic.CommandText = selectAllSQLSortClassic;

            string selectAllSQLSortName = @"SELECT name, blitz_rate, rapid_rate, classic_rate,
                                             blitz_updatedon, rapid_updatedon, classic_updatedon, id
                                 FROM players ORDER BY name;";
            selectAllCmdSortName.CommandText = selectAllSQLSortName;

            string selectAllSQL = @"SELECT name, blitz_rate, rapid_rate, classic_rate,
                                             blitz_updatedon, rapid_updatedon, classic_updatedon, id
                                 FROM players;";
            selectAllCmd.CommandText = selectAllSQL;

            string removePlayerSQL = @"DELETE FROM players WHERE id=@id;";
            removePlayerCmd.CommandText = removePlayerSQL;

            string createDbSQL = @"
                                  /*Enable foreign key constraint */
                                  PRAGMA foreign_keys = ON;

                                  /*create table to keep DB version*/
                                  CREATE TABLE version (ver INTEGER not NULL);
                                  INSERT INTO version values(2);

                                  /* Create players table */
                                  CREATE TABLE players (
                                    id                 INTEGER PRIMARY KEY AUTOINCREMENT,
                                    name               VARCHAR(25) NOT NULL,
                                    blitz_rate         INTEGER,
                                    rapid_rate         INTEGER,
                                    classic_rate       INTEGER,
                                    blitz_updatedon    DATE DEFAULT (datetime('now')),
                                    rapid_updatedon    DATE DEFAULT (datetime('now')),
                                    classic_updatedon  DATE DEFAULT (datetime('now'))
                                  );

                                  /* Create tournaments table */
                                  CREATE TABLE tournaments (
                                      id         INTEGER PRIMARY KEY AUTOINCREMENT,
                                      name       VARCHAR(255) DEFAULT (''),
                                      rounds     INTEGER DEFAULT 1,
                                      typeof     VARCHAR(16),                             /*'blitz' 'rapid' 'classic' */
                                      date_begin DATE DEFAULT (date('now')) NOT NULL,
                                      date_end   DATE DEFAULT (date('now')) NOT NULL
                                  );

                                  /* Create results table */
                                  CREATE TABLE results (
                                      id                         INTEGER PRIMARY KEY AUTOINCREMENT,
                                      player_id                  INTEGER,
                                      tournament_id              INTEGER,
                                      points                     INTEGER NOT NULL,
                                      seq_number                 INTEGER NOT NULL,
                                      player_rate                INTEGER NOT NULL, 
                                      FOREIGN KEY(player_id)     REFERENCES players(id),
                                      FOREIGN KEY(tournament_id) REFERENCES tournaments(id)
                                   );

                                  /* Create games table */
                                  CREATE TABLE games (
                                      id                         INTEGER PRIMARY KEY AUTOINCREMENT,
                                      id_white                   INTEGER,
                                      id_black                   INTEGER,
                                      points                     INTEGER NOT NULL,                       /* 0 - Draw, 1 - white wins, 2 - black wins */
                                      tournament_id              INTEGER,
                                      playedon                   DATE DEFAULT (date('now')) NOT NULL,
                                      pgn                        BLOB,                                  /* Game in PGN format */ 
                                      FOREIGN KEY(id_white)      REFERENCES players(id),
                                      FOREIGN KEY(id_black)      REFERENCES players(id),
                                      FOREIGN KEY(tournament_id) REFERENCES tournaments(id)
                                  );";
            createDbCmd.CommandText = createDbSQL;

            string insertTournamentSQL = @"INSERT INTO tournaments(name, rounds, typeof, date_begin, date_end)
                                         VALUES(@name, @rounds, @typeof, @date_begin, @date_end);";
            insertTournamentCmd.CommandText = insertTournamentSQL;

            string insertResultSQL = @"INSERT INTO results(player_id, tournament_id, points, seq_number, player_rate)
                                         VALUES(@player_id, @tournament_id, @points, @seq_number, @player_rate);";
            insertResultCmd.CommandText = insertResultSQL;

            string selectLatestTournamentSQL = @"SELECT id, name, rounds, typeof, date_begin, date_end 
                                                 FROM tournaments 
                                                 WHERE id = (SELECT max(id) FROM tournaments);";
            selectLatestTournamentCmd.CommandText = selectLatestTournamentSQL;

            string insertGameSQL = @"INSERT INTO games(id_white, id_black, points, tournament_id, playedon)
                                         VALUES(@id_white, @id_black, @points, @tournament_id, @playedon);";
            insertGameCmd.CommandText = insertGameSQL;

        }

        public void UpdateDB()
        {
            if(GetVersion() == DBVersion.Version001)
            {
                UpdateFromVersion001();
            }
        }

        private void UpdateFromVersion001()
        {
            string updateSQLCmd = @"BEGIN TRANSACTION;
                                /*Create temporary table to backup old player table*/
                                CREATE TEMPORARY TABLE players_backup
                                (
                                    id                 INTEGER NOT NULL,
                                    name               VARCHAR(25) NOT NULL,
                                    blitz_rate         INTEGER,
                                    rapid_rate         INTEGER,
                                    classic_rate       INTEGER,
                                    blitz_updatedon    DATE DEFAULT (datetime('now')),
                                    rapid_updatedon    DATE DEFAULT (datetime('now')),
                                    classic_updatedon  DATE DEFAULT (datetime('now'))
                                );

                                /*fill the table*/
                                INSERT INTO players_backup SELECT 
                                    id,
                                    last_name,
                                    rate_blitz,
                                    rate_rapid,
                                    rate_classic,
                                    updatedon,
                                    updatedon,
                                    updatedon 
                                FROM players;

                                /* Delete players table*/
                                DROP TABLE players;
                                /* And create a new one */
                                CREATE TABLE players (
                                    id                 INTEGER PRIMARY KEY AUTOINCREMENT,
                                    name               VARCHAR(25) NOT NULL,
                                    blitz_rate         INTEGER,
                                    rapid_rate         INTEGER,
                                    classic_rate       INTEGER,
                                    blitz_updatedon    DATE DEFAULT (datetime('now')),
                                    rapid_updatedon    DATE DEFAULT (datetime('now')),
                                    classic_updatedon  DATE DEFAULT (datetime('now'))
                                );

                                /*move data from temporary table*/
                                INSERT INTO players SELECT 
                                    id,
                                    name,
                                    blitz_rate,
                                    rapid_rate,
                                    classic_rate,
                                    blitz_updatedon || 'Z',
                                    rapid_updatedon || 'Z',
                                    classic_updatedon || 'Z'
                                FROM players_backup;

                                DROP TABLE players_backup;

                                /*create table to keep DB version*/
                                CREATE TABLE version (ver INTEGER not NULL);
                                INSERT INTO version values(2);

                                DROP TRIGGER IF EXISTS player_upd_trg;

                                DROP TABLE results;

                                /* Create results table */
                                CREATE TABLE results (
                                    id                         INTEGER PRIMARY KEY AUTOINCREMENT,
                                    player_id                  INTEGER,
                                    tournament_id              INTEGER,
                                    points                     INTEGER NOT NULL,
                                    seq_number                 INTEGER NOT NULL,
                                    player_rate                INTEGER NOT NULL, 
                                    FOREIGN KEY(player_id)     REFERENCES players(id),
                                    FOREIGN KEY(tournament_id) REFERENCES tournaments(id)
                                );

                                COMMIT;";

            SQLiteCommand updateDBFrom001Cmd = new SQLiteCommand();
            updateDBFrom001Cmd.CommandText = updateSQLCmd;
            updateDBFrom001Cmd.Connection = dbConnection;

            updateDBFrom001Cmd.ExecuteNonQuery();
        }


        private DBVersion GetVersion()
        {
            SQLiteCommand checkIfExistsCmd = new SQLiteCommand();
            checkIfExistsCmd.CommandText = @"SELECT CASE WHEN tbl_name = 'version' THEN 1 ELSE 0 END FROM sqlite_master WHERE tbl_name = 'version' AND type = 'table'";
            checkIfExistsCmd.Connection = dbConnection;
            SQLiteDataReader dataReader = checkIfExistsCmd.ExecuteReader();
            if (!dataReader.HasRows)
            {
                return DBVersion.Version001;
            }

            SQLiteCommand getVersionCmd = new SQLiteCommand();
            getVersionCmd.CommandText = @"SELECT ver FROM version WHERE rowid==1";
            getVersionCmd.Connection = dbConnection;

            dataReader = getVersionCmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                int ver = dataReader.GetInt32(0);
                if (ver == 2)
                {
                    return DBVersion.Version002;
                }
            }
            return DBVersion.VersionUnknown;
        }

        public SQLiteConnection DbConnection
        {
            get
            {
                return dbConnection;
            }
            set
            {
                dbConnection = value;
                insertPlayerCmd.Connection           = dbConnection;
                editPlayerCmd.Connection             = dbConnection;
                editPlayerUpdateTimeCmd.Connection   = dbConnection;
                removePlayerCmd.Connection           = dbConnection;
                selectAllCmdSortBlitz.Connection     = dbConnection;
                selectAllCmdSortRapid.Connection     = dbConnection;
                selectAllCmdSortClassic.Connection   = dbConnection;
                selectAllCmdSortName.Connection      = dbConnection;
                selectAllCmd.Connection              = dbConnection;
                createDbCmd.Connection               = dbConnection;
                insertTournamentCmd.Connection       = dbConnection;
                insertResultCmd.Connection           = dbConnection;
                selectLatestTournamentCmd.Connection = dbConnection;
                insertGameCmd.Connection             = dbConnection;
            }
        }

        public void InsertPlayer(Player p)
        {
            insertPlayerCmd.Parameters.AddWithValue("@name", p.Name);
            insertPlayerCmd.Parameters.AddWithValue("@rblitz", p.BlitzRate);
            insertPlayerCmd.Parameters.AddWithValue("@rrapid", p.RapidRate);
            insertPlayerCmd.Parameters.AddWithValue("@rclassic", p.ClassicRate);
            insertPlayerCmd.Parameters.AddWithValue("@blitzup", p.BlitzLastUpdate.ToUniversalTime());
            insertPlayerCmd.Parameters.AddWithValue("@rapidup", p.RapidLastUpdate.ToUniversalTime());
            insertPlayerCmd.Parameters.AddWithValue("@classicup", p.ClassicLastUpdate.ToUniversalTime());

            insertPlayerCmd.ExecuteNonQuery();
        }

        public List<Player> LoadAllPlayers(PlayerSortType st, GameType gt)
        {
            SQLiteCommand selectCmd = GetSelectCmd(st, gt);

            List<Player> players = new List<Player>();
            SQLiteDataReader dataReader = selectCmd.ExecuteReader();

            while (dataReader.Read())
            {
                Player p = new Player(dataReader.GetInt64(7))
                {
                    Name = dataReader.GetString(0),
                    BlitzRate = dataReader.GetInt32(1),
                    RapidRate = dataReader.GetInt32(2),
                    ClassicRate = dataReader.GetInt32(3),
                    BlitzLastUpdate = dataReader.GetDateTime(4),
                    RapidLastUpdate = dataReader.GetDateTime(5),
                    ClassicLastUpdate = dataReader.GetDateTime(6),
                };

                players.Add(p);
            }
            dataReader.Close();
            return players;
        }

        public void UpdatePlayer(Player p)
        {
            editPlayerCmd.Parameters.AddWithValue("@name", p.Name);
            editPlayerCmd.Parameters.AddWithValue("@rblitz", p.BlitzRate);
            editPlayerCmd.Parameters.AddWithValue("@rrapid", p.RapidRate);
            editPlayerCmd.Parameters.AddWithValue("@rclassic", p.ClassicRate);
            editPlayerCmd.Parameters.AddWithValue("@blitzup", p.BlitzLastUpdate.ToUniversalTime());
            editPlayerCmd.Parameters.AddWithValue("@rapidup", p.RapidLastUpdate.ToUniversalTime());
            editPlayerCmd.Parameters.AddWithValue("@classicup", p.ClassicLastUpdate.ToUniversalTime());
            editPlayerCmd.Parameters.AddWithValue("@id", p.Id);

            editPlayerCmd.ExecuteNonQuery();
        }

        public void RemovePlayer(Player p)
        {
            removePlayerCmd.Parameters.AddWithValue("@id", p.Id);

            removePlayerCmd.ExecuteNonQuery();
        }

        public void CreateDB(string path)
        {
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source=" + path;
            connection.Open();
            createDbCmd.Connection = connection;
            createDbCmd.ExecuteNonQuery();
            connection.Close();
        }

        public Tournament InsertTournament(Tournament t)
        {
            insertTournamentCmd.Parameters.AddWithValue("@name", t.Name);
            insertTournamentCmd.Parameters.AddWithValue("@rounds", t.Rounds);
            insertTournamentCmd.Parameters.AddWithValue("@typeof", t.Type.ToString());
            insertTournamentCmd.Parameters.AddWithValue("@date_begin", t.BeginOn.ToUniversalTime());
            insertTournamentCmd.Parameters.AddWithValue("@date_end", t.EndOn.ToUniversalTime());

            insertTournamentCmd.ExecuteNonQuery();

            return GetLatestTournament();
        }

        public void InsertResult(TournamentResult r)
        {
            insertResultCmd.Parameters.AddWithValue("@player_id", r.Participant.Id);
            insertResultCmd.Parameters.AddWithValue("@tournament_id", r.Event.Id);
            insertResultCmd.Parameters.AddWithValue("@points", r.Points);
            insertResultCmd.Parameters.AddWithValue("@seq_number", r.SeqNumber);
            insertResultCmd.Parameters.AddWithValue("@player_rate", r.Participant.GetRate(r.Event.Type));

            insertResultCmd.ExecuteNonQuery();
        }

        public void InsertGame(Game g)
        {
            insertGameCmd.Parameters.AddWithValue("@id_white", g.WhitePlayer.Id);
            insertGameCmd.Parameters.AddWithValue("@id_black", g.BlackPlayer.Id);
            insertGameCmd.Parameters.AddWithValue("@points", g.Result.ToString());
            insertGameCmd.Parameters.AddWithValue("@tournament_id", g.Tournament.Id);
            insertGameCmd.Parameters.AddWithValue("@playedon", g.PlayedOn.ToUniversalTime());

            insertGameCmd.ExecuteNonQuery();
        }

        public Tournament GetLatestTournament()
        {
            SQLiteDataReader dataReader = selectLatestTournamentCmd.ExecuteReader();
            Tournament t = null;
            while (dataReader.Read())
            {
                t = new Tournament(dataReader.GetInt64(0))
                {
                    Name = dataReader.GetString(1),
                    Rounds = dataReader.GetInt32(2),
                    Type = (GameType)Enum.Parse(typeof(GameType), dataReader.GetString(3)),
                    BeginOn = dataReader.GetDateTime(4),
                    EndOn = dataReader.GetDateTime(5),
                };

            }
            dataReader.Close();

            return t;
        }

        private SQLiteCommand GetSelectCmd(PlayerSortType st, GameType gt)
        {
            switch (st)
            {
                case PlayerSortType.ByRate:
                    switch (gt)
                    {
                        case GameType.Blitz:
                            return selectAllCmdSortBlitz;
                        case GameType.Rapid:
                            return selectAllCmdSortRapid;
                        case GameType.Classic:
                            return selectAllCmdSortClassic;
                    }
                    return selectAllCmdSortBlitz;
                case PlayerSortType.ByName:
                    return selectAllCmdSortName;
            }

            return selectAllCmd;
        }
    }
}
