using LeagueManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LeagueManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var db = new ApplicationDbContext();

            return View(db.Tournaments.First());
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
