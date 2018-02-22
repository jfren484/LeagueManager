using System.Linq;

namespace LeagueManager.Web.Models
{
    public class Tournament8TeamModel : TournamentModel
    {
        public Tournament8TeamModel(TournamentModel parent)
        {
            Name = parent.Name;
            Description = parent.Description;
            Dates = parent.Dates;
            TeamCount = parent.TeamCount;
            Games = parent.Games;
        }

        public TournamentGameModel QuarterFinal1Vs8 => Games.Single(g => g.Tag == "QF.1");
        public TournamentGameModel QuarterFinal4Vs5 => Games.Single(g => g.Tag == "QF.2");
        public TournamentGameModel QuarterFinal3Vs6 => Games.Single(g => g.Tag == "QF.3");
        public TournamentGameModel QuarterFinal2Vs7 => Games.Single(g => g.Tag == "QF.4");
        public TournamentGameModel ConsSemiFinal8Vs5 => Games.Single(g => g.Tag == "CSF.1");
        public TournamentGameModel ConsSemiFinal7Vs6 => Games.Single(g => g.Tag == "CSF.2");
        public TournamentGameModel ConsFinal => Games.Single(g => g.Tag == "CF.1");
        public TournamentGameModel SemiFinal1Vs4 => Games.Single(g => g.Tag == "SF.1");
        public TournamentGameModel SemiFinal2Vs3 => Games.Single(g => g.Tag == "SF.2");
        public TournamentGameModel Final => Games.Single(g => g.Tag == "F.1");
        public TournamentGameModel ThirdPlace => Games.Single(g => g.Tag == "F.2");
    }
}
