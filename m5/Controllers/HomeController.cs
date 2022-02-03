using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using m5.Models;
using Microsoft.EntityFrameworkCore;

namespace m5.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext movieContext { get; set; }

        public HomeController(MovieApplicationContext someName)
        {
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodCasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            //viewbag to hold list of categories
            ViewBag.Category = movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(FormResponse fr)
        {
            // set this variable true to indiciate that im adding new data not the seeded data
            ViewBag.New = true;

            if (ModelState.IsValid)
            {
                //connecting to DB
                movieContext.Add(fr);
                movieContext.SaveChanges();

                return View("Confirmation", fr);
            }
            else //if invalid
            {
                ViewBag.Category = movieContext.Categories.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = movieContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

               
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Category = movieContext.Categories.ToList();
            var application = movieContext.responses.Single(x => x.FormID == applicationid);

            return View("MovieForm", application);
        }

        [HttpPost]
        public IActionResult Edit(FormResponse blah)
        {
            //update, save, and update to the database
            movieContext.Update(blah);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = movieContext.responses.Single(x => x.FormID == applicationid);
            return View(application);

        }

        [HttpPost]
        public IActionResult Delete(FormResponse fr)
        {
            movieContext.responses.Remove(fr);
            movieContext.SaveChanges();

            //back to the waitlist page
            return RedirectToAction("MovieList");
        }



    }
}
