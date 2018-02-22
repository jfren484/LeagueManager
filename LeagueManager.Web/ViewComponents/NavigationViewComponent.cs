using LeagueManager.Data;
using LeagueManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueManager.Web.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public NavigationViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _db.Tournaments
                      .Select(t => new NavTournamentModel { Id = t.Id, Name = t.Name })
                      .ToListAsync();

            return View(items);
        }
    }
}
