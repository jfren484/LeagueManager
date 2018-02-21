using LeagueManager.Data;
using LeagueManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Html;

namespace LeagueManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var tournament = _db.Tournaments
                                .Include(t => t.TournamentTeams)
                                .ThenInclude(tt => tt.Team)
                                .Include(t => t.TournamentGames)
                                .ThenInclude(tg => tg.ParticipantATournamentTeam)
                                .Include(t => t.TournamentGames)
                                .ThenInclude(tg => tg.ParticipantATournamentGame)
                                .Include(t => t.TournamentGames)
                                .ThenInclude(tg => tg.ParticipantBTournamentGame)
                                .ThenInclude(tg => tg.ParticipantBTournamentTeam)
                                .First();

            var games = tournament.TournamentGames
                                  .Select(g => new TournamentGameModel
                                               {
                                                   Id = g.Id,
                                                   Tag = g.Tag,
                                                   Description = new HtmlString(g.Description),
                                                   TeamADisplay = g.ParticipantA?.Display,
                                                   TeamBDisplay = g.ParticipantB?.Display
                                               })
                                  .ToList();

            var model = new Tournament8TeamModel
                        {
                            Name = tournament.Name,
                            Description = tournament.Description,
                            Dates = tournament.Dates,
                            QuarterFinal1Vs8 = games.Single(g => g.Tag == "QF.1"),
                            QuarterFinal4Vs5 = games.Single(g => g.Tag == "QF.2"),
                            QuarterFinal2Vs7 = games.Single(g => g.Tag == "QF.3"),
                            QuarterFinal3Vs6 = games.Single(g => g.Tag == "QF.4"),
                            ConsSemiFinal8Vs5 = games.Single(g => g.Tag == "CSF.1"),
                            ConsSemiFinal7Vs6 = games.Single(g => g.Tag == "CSF.2"),
                            ConsFinal = games.Single(g => g.Tag == "CF.1"),
                            SemiFinal1Vs4 = games.Single(g => g.Tag == "SF.1"),
                            SemiFinal2Vs3 = games.Single(g => g.Tag == "SF.2"),
                            Final = games.Single(g => g.Tag == "F.1"),
                            ThirdPlace = games.Single(g => g.Tag == "F.2")
                        };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
