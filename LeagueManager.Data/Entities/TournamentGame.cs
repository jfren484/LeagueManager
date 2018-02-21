using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LeagueManager.Data.Entities
{
    public class TournamentGame
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int? ParticipantATournamentTeamId { get; set; }
        public int? ParticipantBTournamentTeamId { get; set; }
        public int? ParticipantATournamentGameId { get; set; }
        public bool? ParticipantAGameIsWinner { get; set; }
        public int? ParticipantBTournamentGameId { get; set; }
        public bool? ParticipantBGameIsWinner { get; set; }
        [MaxLength(10)]
        public string Tag { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Result { get; set; }
        [MaxLength(50)]
        public string ResultLabel { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual TournamentTeam ParticipantATournamentTeam { get; set; }
        public virtual TournamentTeam ParticipantBTournamentTeam { get; set; }
        public virtual TournamentGame ParticipantATournamentGame { get; set; }
        public virtual TournamentGame ParticipantBTournamentGame { get; set; }

        public virtual IEnumerable<TournamentGame> ParticipantATournamentGames { get; set; }
        public virtual IEnumerable<TournamentGame> ParticipantBTournamentGames { get; set; }
        public virtual IEnumerable<TournamentGameTeam> TournamentGameTeams { get; set; }

        public TournamentTeam ParticipantA =>
            ParticipantATournamentTeam ??
            ParticipantATournamentGame?
                .TournamentGameTeams?
                .OrderBy(tgt => tgt.Score * (ParticipantAGameIsWinner ?? false ? -1 : 1))
                .FirstOrDefault()?
                .TournamentTeam;

        public TournamentTeam ParticipantB =>
            ParticipantBTournamentTeam ??
            ParticipantBTournamentGame?
                .TournamentGameTeams?
                .OrderBy(tgt => tgt.Score * (ParticipantBGameIsWinner ?? false ? -1 : 1))
                .FirstOrDefault()?
                .TournamentTeam;
    }
}
