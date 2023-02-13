using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MissionSix.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MissionSix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieApplicationContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Extra()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {

                blahContext.Add(ar);
                blahContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                return View();
            }
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
    }
}
