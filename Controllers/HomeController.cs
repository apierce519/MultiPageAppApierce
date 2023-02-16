﻿using Microsoft.AspNetCore.Mvc;
using MultiPageAppApierce.Models;
using System.Diagnostics;

namespace MultiPageAppApierce.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}