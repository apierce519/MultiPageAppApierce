using Microsoft.AspNetCore.Mvc;
using MultiPageAppApierce.Models;

namespace MultiPageAppApierce.Controllers
{
    public class CountryController : Controller
    {
        private CountryContext context;
        public CountryController(CountryContext context)
        {
            this.context = context;

        }
        public ViewResult Index(string activeGame = "all", string activeCategory = "all")
        {
            ViewBag.ActiveGame = activeGame;
            ViewBag.ActiveCategory = activeCategory;

            ViewBag.Category = context.Categories.ToList();
            ViewBag.Game = context.Games.ToList();

            IQueryable<Country> query = context.Countries.OrderBy(t => t.Name);

            if (activeCategory != "all")
            {
                query = query.Where(t => t.Category.CategoryId.ToLower() == activeCategory.ToLower());
            }
            if (activeGame != "all")
            {
                query = query.Where(t => t.Game.GameId.ToLower() == activeGame.ToLower());
            }

            var country = query.ToList();

            return View(country);
        }
    }
}
