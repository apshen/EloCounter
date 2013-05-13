using System;
using System.Collections.Generic;
using System.Text;

namespace EloCounter
{
    public interface ITournament
    {
        List<Player> GetPlayers();
        List<Game> GetGames();
        int GetAverageRate(Player p);
        Tournament GetTournament();
        int GetMaxPoints(Player p);
        TournamentResult GetResult(Player p);
        GameType GetGameType();
    }
}
