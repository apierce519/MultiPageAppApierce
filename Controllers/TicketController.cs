using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiPageAppApierce.Models;

namespace MultiPageAppApierce.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext context;
        public TicketController(TicketContext context) => this.context = context;
        public ViewResult Index(string id)
        {
            //Load current filters and data needed for filter drop downs in ViewBag
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();

            //get open tickets from database based on current filters
            IQueryable<Ticket> query = context.Tickets
                .Include(t => t.Status);

            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            var tasks = query.ToList();

            return View(tasks);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Statuses = context.Statuses.ToList();
            var task = new Ticket { StatusId = "todo" };
            return View(task);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Statuses = context.Statuses.ToList();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { Id = id });
        }
        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, Ticket ticket)
        {
            ticket = context.Tickets.Find(ticket.Id)!;
            if (ticket != null)
            {
                ticket.StatusId = "done";
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { Id = id });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = context.Tickets
                .Where(t => t.StatusId == "done").ToList();

            foreach (var t in toDelete)
            {
                context.Tickets.Remove(t);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { Id = id });
        }


    }
}
