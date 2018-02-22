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
                   .Where(t => t.Id == id)
                   .Select(t => new TournamentModel
                                {
                                    Name = t.Name,
                                    Description = t.Description,
                                    Dates = t.Dates,
                                    TeamCount = t.TournamentTeams.Count(),
                                    Games = t.TournamentGames
                                             .Select(g => new TournamentGameModel
                                                          {
                                                              Id = g.Id,
                                                              Tag = g.Tag,
                                                              Description = new HtmlString(g.Description),
                                                              ResultLabel = new HtmlString(g.ResultLabel),
                                                              TeamADisplay = g.ParticipantATournamentTeam == null
                                                                  ? null
                                                                  : $"#{g.ParticipantATournamentTeam.Seed} {g.ParticipantATournamentTeam.TeamNameOverride ?? g.ParticipantATournamentTeam.Team.Name}",
                                                              TeamBDisplay = g.ParticipantBTournamentTeam == null
                                                                  ? null
                                                                  : $"#{g.ParticipantBTournamentTeam.Seed} {g.ParticipantBTournamentTeam.TeamNameOverride ?? g.ParticipantBTournamentTeam.Team.Name}"
                                                          })
                                             .ToList()
                                })
                   .SingleOrDefaultAsync();

            return tournament == null
                ? (IActionResult)NotFound()
                : View("Tournament8Team", new Tournament8TeamModel(tournament));
        }
    }
}