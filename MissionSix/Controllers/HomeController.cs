using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
      
        private MovieApplicationContext blahContext { get; set; }

        //Constructor
        public HomeController(MovieApplicationContext someName)
        {
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        // do we need confirmation and extra? I noticed he doesn't have them
        // in video 9 but I don't remember him making a point of removing them
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
            // here we are creating the list of variables and passing it to the viewbag
            // We've also created an entry here called majors that will hold all of this.
            ViewBag.Categories = blahContext.Categories.ToList();
            return View();
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
            else //If Invalid
            {
                ViewBag.Categories = blahContext.Categories.ToList();
                return View();
            }
        }
          

        [HttpGet]
        public IActionResult WaitList ()
        {
            // This will sort/filter out the table!
            var applications = blahContext.Responses.Include(x => x.Category).OrderBy(x => x.Title).ToList();

            return View(applications);

        }

        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            // there's no need to create something totally new here
            // so instead we send it back to our 'list of options'
            ViewBag.Categories = blahContext.Categories.ToList();
            var application = blahContext.Responses.Single(x => x.ApplicationId == applicationid);
            // we return to the view (our application) so that we can see and make changes
            // we pass in the var we just created
            return View("MovieForm", application);
        }

        [HttpPost]
        // receives an instance of an application response that we can refer to
        public IActionResult Edit (ApplicationResponse blah)
        {
            // here we update and save changes based on the info passed above
            blahContext.Update(blah);
            blahContext.SaveChanges();

            // we pass it all into the waitlist cshtml
            // remember that you must also specify an action that will
            // actually go back to the previous waitlist action we made so it
            // not only shows the view but also pulls in the actions
            return RedirectToAction("Waitlist");

        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = blahContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete (ApplicationResponse ar)
        {
            blahContext.Responses.Remove(ar);
            blahContext.SaveChanges();

            return RedirectToAction("WaitList");
        }

    }
}
