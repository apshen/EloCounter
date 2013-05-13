using System;
using System.Collections.Generic;
using System.Text;

namespace EloCounter
{
    public class Tournament
    {
        public long Id {get; private set;}
        public string Name {get; set;}
        public int Rounds {get; set;}
        public GameType Type {get; set;}
        public DateTime BeginOn {get; set;}
        public DateTime EndOn {get; set;}

        public Tournament(long id)
        {
            this.Id = id;
        }

        public Tournament()
        { 
        }
    }
}
