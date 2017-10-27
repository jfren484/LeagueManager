using System.Collections.Generic;

namespace LeagueManager.Data
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dates { get; set; }

        public virtual IEnumerable<TournamentTeam> TournamentTeams { get; set; }
        public virtual IEnumerable<TournamentGame> TournamentGames { get; set; }
    }
}
