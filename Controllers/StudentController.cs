using Microsoft.AspNetCore.Mvc;
using MultiPageAppApierce.Models;

namespace MultiPageAppApierce.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private StudentContext context;
        public StudentController(ILogger<StudentController> logger, StudentContext context) {
            _logger = logger;
            this.context = context;
        }
        [HttpGet]
        [Route("Student")]
        public IActionResult StudentList(int id)
        {
            var con = context.Students.OrderBy(c => c.LastName).ToList();
            ViewBag.AccessLevel = id;
            return View(con);
        }

    }
}
