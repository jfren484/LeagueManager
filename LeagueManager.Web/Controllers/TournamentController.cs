using System.Linq;
using System.Threading.Tasks;
using LeagueManager.Data;
using LeagueManager.Web.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Web.Controllers
{
    [Route("Tournaments")]
    public class TournamentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TournamentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Tournament(int id)
        {
            var tournament = await
                _db.Tournaments
                   .Select(t => new
                                {
                                    t.Id,
                                    t.Name,
                                    t.Description,
                                    t.Dates,
                                    TeamCount = t.TournamentTeams.Count(),
                                    Games = t.TournamentGames
                                             .Select(g => new TournamentGameModel
                                                          {
                                                              Id = g.Id,
                                                              Tag = g.Tag,
                                                              Description = new HtmlString(g.Description),
                                                              TeamADisplay = g.ParticipantATournamentTeam == null
                                                                  ? null
                                                                  : $"#{g.ParticipantATournamentTeam.Seed} {g.ParticipantATournamentTeam.TeamNameOverride ?? g.ParticipantATournamentTeam.Team.Name}",
                                                              TeamBDisplay = g.ParticipantBTournamentTeam == null
                                                                  ? null
                                                                  : $"#{g.ParticipantBTournamentTeam.Seed} {g.ParticipantBTournamentTeam.TeamNameOverride ?? g.ParticipantBTournamentTeam.Team.Name}"
                                                          })
                                             .ToList()
                                })
                   .SingleOrDefaultAsync(t => t.Id == id);

            if (tournament == null)
            {
                return NotFound();
            }

            var model = new Tournament8TeamModel
                        {
                            Name = tournament.Name,
                            Description = tournament.Description,
                            Dates = tournament.Dates,
                            QuarterFinal1Vs8 = tournament.Games.Single(g => g.Tag == "QF.1"),
                            QuarterFinal4Vs5 = tournament.Games.Single(g => g.Tag == "QF.2"),
                            QuarterFinal2Vs7 = tournament.Games.Single(g => g.Tag == "QF.3"),
                            QuarterFinal3Vs6 = tournament.Games.Single(g => g.Tag == "QF.4"),
                            ConsSemiFinal8Vs5 = tournament.Games.Single(g => g.Tag == "CSF.1"),
                            ConsSemiFinal7Vs6 = tournament.Games.Single(g => g.Tag == "CSF.2"),
                            ConsFinal = tournament.Games.Single(g => g.Tag == "CF.1"),
                            SemiFinal1Vs4 = tournament.Games.Single(g => g.Tag == "SF.1"),
                            SemiFinal2Vs3 = tournament.Games.Single(g => g.Tag == "SF.2"),
                            Final = tournament.Games.Single(g => g.Tag == "F.1"),
                            ThirdPlace = tournament.Games.Single(g => g.Tag == "F.2")
                        };

            return View("Tournament8Team", model);
        }
    }
}