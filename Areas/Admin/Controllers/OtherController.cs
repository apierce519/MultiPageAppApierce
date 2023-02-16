using Microsoft.AspNetCore.Mvc;
using MultiPageAppApierce.Models;
using System.Diagnostics;

namespace MultiPageAppApierce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OtherController : Controller
    {

        private readonly ILogger<OtherController> _logger;
        private ContactContext context;

        public OtherController(ILogger<OtherController> logger, ContactContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("Admin/Contacts")]
        public IActionResult Contacts()
        {
            var con = context.Contacts.OrderBy(c => c.Name).ToList();
            return View(con);
        }

        [HttpGet]
        [Route("Admin/Add")]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Contact());
        }
        [HttpGet]
        [Route("Admin/Edit")]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var contact = context.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        [Route("Admin/Edit")]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                    context.Contacts.Add(contact);
                else
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Contacts", "Other");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                return View(contact);
            }
        }
        [HttpGet]
        [Route("Admin/Delete")]
        public IActionResult Delete(int id)
        {
            var movie = context.Contacts.Find(id);
            return View(movie);
        }
        [HttpPost]
        [Route("Admin/Delete")]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Contacts", "Other");
        }

    }
}
