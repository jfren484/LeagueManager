using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueManager.Data.Entities
{
    public class TournamentTeam
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public int Seed { get; set; }
        [MaxLength(30)]
        public string TeamNameOverride { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual Team Team { get; set; }

        public virtual IEnumerable<TournamentGame> ParticipantATournamentGames { get; set; }
        public virtual IEnumerable<TournamentGame> ParticipantBTournamentGames { get; set; }
        public virtual IEnumerable<TournamentGameTeam> TournamentGameTeams { get; set; }

        public string Display => $"#{Seed} {TeamNameOverride ?? Team.Name}";
    }
}
