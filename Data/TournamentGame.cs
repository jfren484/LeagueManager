using System.Collections.Generic;
using System.Linq;

namespace LeagueManager.Data
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
        public string Tag { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }

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
