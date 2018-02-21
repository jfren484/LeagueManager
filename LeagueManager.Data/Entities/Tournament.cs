using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueManager.Data.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string Dates { get; set; }

        public virtual IEnumerable<TournamentTeam> TournamentTeams { get; set; }
        public virtual IEnumerable<TournamentGame> TournamentGames { get; set; }
    }
}
