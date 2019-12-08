using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IOTWaterloo_JobBoard.Models;

namespace IOTWaterloo_JobBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobBoardContext _context;
        public HomeController(JobBoardContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult JobSearch()
        {
            var jobDetails = _context.JobDetails.Take(5);
            return View(jobDetails);
        }

         public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUS()
        {
            return View();
        }
        public IActionResult Partners()
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
