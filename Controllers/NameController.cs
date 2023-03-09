using Microsoft.AspNetCore.Mvc;
using MultiPageAppApierce.Models;

namespace MultiPageAppApierce.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Index()
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                ActiveCategory = session.GetActiveCateg(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries(),
                UserName = session.GetName()
            };

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Change(CountriesViewModel model)
        {
            var session = new CountrySession(HttpContext.Session);
            session.SetName(model.UserName);

            return RedirectToAction("Index", "Country",
                new
                {
                    ActiveCategory = session.GetActiveCateg(),
                    ActiveGame = session.GetActiveGame()
                });
        }
    }
}
