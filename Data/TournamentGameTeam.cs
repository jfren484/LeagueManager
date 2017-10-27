namespace LeagueManager.Data
{
    public class TournamentGameTeam
    {
        public int Id { get; set; }
        public int TournamentGameId { get; set; }
        public int TournamentTeamId { get; set; }
        public int? Score { get; set; }

        public virtual TournamentGame TournamentGame { get; set; }
        public virtual TournamentTeam TournamentTeam { get; set; }
    }
}
