using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueManager.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public TeamLevels Level { get; set; }

        public virtual IEnumerable<TournamentTeam> TournamentTeams { get; set; }
    }
}
