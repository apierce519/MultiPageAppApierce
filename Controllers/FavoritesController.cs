using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiPageAppApierce.Models;

namespace MultiPageAppApierce.Controllers
{
    public class FavoritesController : Controller
    {

        private CountryContext context;
        public FavoritesController(CountryContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/Views/Favorites/Index.cshtml")]
        public ViewResult Index()
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                ActiveCategory = session.GetActiveCateg(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries(),
                UserName = session.GetName()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Country country)
        {
            country = context.Countries
                .Include(t => t.Category)
                .Include(t => t.Game)
                .Where(t => t.CountryId == country.CountryId)
                .FirstOrDefault() ?? new Country();

            var session = new CountrySession(HttpContext.Session);
            var cookies = new CountryCookies(Response.Cookies);

            var countries = session.GetMyCountries();
            countries.Add(country);
            session.SetMyCountries(countries);

            TempData["message"] = $"{country.Name} added to your favorites";

            return RedirectToAction("Index", "Country",
                new
                {
                    ActiveCategory = session.GetActiveCateg(),
                    ActiveGame = session.GetActiveGame(),
                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new CountrySession(HttpContext.Session);
            var cookies = new CountryCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite teams cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveCategory = session.GetActiveCateg(),
                    ActiveGame = session.GetActiveGame(),
                });

        }
    }
}
