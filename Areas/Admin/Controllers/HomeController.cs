using Microsoft.AspNetCore.Mvc;
using MultiPageAppApierce.Models;
using System.Diagnostics;

namespace MultiPageAppApierce.Admin.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("Admin/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}