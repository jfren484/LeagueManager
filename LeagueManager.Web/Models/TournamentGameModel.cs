using Microsoft.AspNetCore.Html;

namespace LeagueManager.Web.Models
{
    public class TournamentGameModel
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public HtmlString Description { get; set; }
        public HtmlString ResultLabel { get; set; }
        public string TeamADisplay { get; set; }
        public string TeamBDisplay { get; set; }
        public string WinnerDisplayResult { get; set; }
        public string LoserDisplayResult { get; set; }
    }
}
