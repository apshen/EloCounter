using System;
using System.Collections.Generic;
using System.Text;

namespace EloCounter
{
    public class Player
    {
        public Player(long id)
        {
            this.Id = id;
        }

        public Player()
        {
            BlitzLastUpdate = DateTime.Now;
            RapidLastUpdate = DateTime.Now;
            ClassicLastUpdate = DateTime.Now;
        }

        public long Id {get; private set; }
        public string Name { get; set; }
        public int BlitzRate { get; set; }
        public int RapidRate { get; set; }
        public int ClassicRate { get; set; }
        public DateTime BlitzLastUpdate { get; set; }
        public DateTime RapidLastUpdate { get; set; }
        public DateTime ClassicLastUpdate { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string GetNameWithRate(GameType t)
        {
            string ret = Name;

            switch(t)
            {
                case GameType.Blitz:
                    ret += " [" + BlitzRate.ToString() + "]";
                    break;
                case GameType.Rapid:
                    ret += " [" + RapidRate.ToString() + "]";
                    break;
                case GameType.Classic:
                    ret += " [" + ClassicRate.ToString() + "]";
                    break;
            }
            return ret;
        }

        public Player Clone()
        {
            return new Player (this.Id)
            {
                Name = this.Name,
                BlitzRate = this.BlitzRate,
                RapidRate = this.RapidRate,
                ClassicRate = this.ClassicRate,
                Id = this.Id,
                BlitzLastUpdate = this.BlitzLastUpdate,
                RapidLastUpdate = this.RapidLastUpdate,
                ClassicLastUpdate = this.ClassicLastUpdate,
            };
        }

        public int GetRate(GameType t)
        {
            int ret = 0;
            switch (t)
            {
                case GameType.Blitz:
                    ret = this.BlitzRate;
                    break;
                case GameType.Rapid:
                    ret = this.RapidRate;
                    break;
                case GameType.Classic:
                    ret = this.ClassicRate;
                    break;
            }

            return ret;
        }

        public void SetRate(GameType t, int newRate)
        {
            switch (t)
            {
                case GameType.Blitz:
                    BlitzRate = newRate;
                    break;
                case GameType.Rapid:
                    RapidRate = newRate;
                    break;
                case GameType.Classic:
                    ClassicRate = newRate;
                    break;
            }
        }

        public DateTime GetUpdateDate(GameType t)
        {
            DateTime ret = DateTime.Now;
            switch (t)
            {
                case GameType.Blitz:
                    ret = BlitzLastUpdate;
                    break;
                case GameType.Rapid:
                    ret = RapidLastUpdate;
                    break;
                case GameType.Classic:
                    ret = ClassicLastUpdate;
                    break;
            }

            return ret;
        }


        public void SetUpdateDate(GameType t, DateTime d)
        {
            switch (t)
            {
                case GameType.Blitz:
                    if (BlitzLastUpdate.CompareTo(d) <= 0)
                    {
                        BlitzLastUpdate = d;
                    }
                    break;
                case GameType.Rapid:
                    if (RapidLastUpdate.CompareTo(d) <= 0)
                    {
                        RapidLastUpdate = d;
                    }
                    break;
                case GameType.Classic:
                    if (ClassicLastUpdate.CompareTo(d) <= 0)
                    {
                        ClassicLastUpdate = d;
                    }
                    break;
            }
        }

        public bool IsActive(GameType t)
        {
            return DateTime.Now.Subtract(GetUpdateDate(t)).Days <= 365;
        }
    }
}
