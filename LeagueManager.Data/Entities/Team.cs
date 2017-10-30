using System.Collections.Generic;

namespace LeagueManager.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeamLevels Level { get; set; }

        public virtual IEnumerable<TournamentTeam> TournamentTeams { get; set; }
    }
}
