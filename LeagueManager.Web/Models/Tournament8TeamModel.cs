namespace LeagueManager.Web.Models
{
    public class Tournament8TeamModel : TournamentModel
    {
        public TournamentGameModel QuarterFinal1Vs8 { get; set; }
        public TournamentGameModel QuarterFinal2Vs7 { get; set; }
        public TournamentGameModel QuarterFinal3Vs6 { get; set; }
        public TournamentGameModel QuarterFinal4Vs5 { get; set; }
        public TournamentGameModel ConsSemiFinal8Vs5 { get; set; }
        public TournamentGameModel ConsSemiFinal7Vs6 { get; set; }
        public TournamentGameModel ConsFinal { get; set; }
        public TournamentGameModel SemiFinal1Vs4 { get; set; }
        public TournamentGameModel SemiFinal2Vs3 { get; set; }
        public TournamentGameModel ThirdPlace { get; set; }
        public TournamentGameModel Final { get; set; }
    }
}
