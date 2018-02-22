using System.Collections.Generic;

namespace LeagueManager.Web.Models
{
    public class TournamentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dates { get; set; }
        public int TeamCount { get; set; }
        public List<TournamentGameModel> Games { get; set; }
    }
}
