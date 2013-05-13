using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EloCounter
{
    public delegate void PlayerDeleteEvent(Player p);

    public interface ITournamentTable : ITournament
    {
        event PlayerDeleteEvent OnPlayerDelete;

        void AddPlayer(Player p);
        bool IsComplete();

        int Rounds { get; set; }
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        GameType Type { get; set; }
        string Name { get; set; }
    }

}
