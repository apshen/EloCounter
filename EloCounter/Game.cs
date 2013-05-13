using System;
using System.Collections.Generic;
using System.Text;

namespace EloCounter
{
    public class Game
    {
        public long Id { get; set; }
        public Player WhitePlayer { get; set; }
        public Player BlackPlayer { get; set; }

        public GameResult Result { get; set; }
        public Tournament Tournament { get; set; }
        public DateTime PlayedOn { get; set; }
        public string PGN { get; set; }

        public Game()
        {
        }

        public Game(long id)
        {
            Id = id;
        }

    }
}
