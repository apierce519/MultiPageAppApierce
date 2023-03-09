using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiPageAppApierce.Models;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MultiPageAppApierce.Controllers
{
    public class CountryController : Controller
    {
        private CountryContext context;
        public CountryController(CountryContext context)
        {
            this.context = context;

        }
        public ViewResult Index(CountriesViewModel model)
        {
            var session = new CountrySession(HttpContext.Session);
            session.SetActiveCateg(model.ActiveCategory);
            session.SetActiveGame(model.ActiveGame);

            int? count = session.GetMyCountryCount();
            if (!count.HasValue)
            {
                var cookies = new CountryCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                if (ids.Length > 0)
                {
                    var myCountries = context.Countries
                        .Include(c => c.Category)
                        .Include(c => c.Game)
                        .Where(c => ids.Contains(c.CountryId))
                        .ToList();
                    session.SetMyCountries(myCountries);
                }
            }

            model.Categories = context.Categories.ToList();
            model.Games = context.Games.ToList();

            IQueryable<Country> query = context.Countries.OrderBy(t => t.Name);

            if (model.ActiveCategory != "all")
            {
                query = query.Where(t => t.Category.CategoryId.ToLower() == model.ActiveCategory.ToLower());
            }
            if (model.ActiveGame != "all")
            {
                query = query.Where(t => t.Game.GameId.ToLower() == model.ActiveGame.ToLower());
            }
            model.Countries = query.ToList();

            return View(model);

        }

        public IActionResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                Country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Category)
                .FirstOrDefault(t => t.CountryId == id) ?? new Country(),
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCateg()
            };
            return View(model);
        }
    }
}
