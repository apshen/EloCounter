using System;
using System.Collections.Generic;
using System.Text;

namespace EloCounter
{
    public class TournamentResult
    {
        public long Id { get; private set; }
        public Player Participant { get; set; }
        public Tournament Event { get; set; }
        public int Points { get; set; }
        public int PlayerRate { get; set; }
        public int SeqNumber { get; set; }

        public TournamentResult()
        {
        }

        public TournamentResult(long id)
        {
            Id = id;
        }
    }
}
