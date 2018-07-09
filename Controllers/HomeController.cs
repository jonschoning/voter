using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using voter.Models;

namespace voter.Controllers
{
    public static class GlobalVariables
    {
        public static int add_1;
        public static int add_2;
        public static int add_3;
    }
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Results() {
            return View();
        }
        [HttpPost]
        public IActionResult ResultsPost() {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Reset() {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPost() {
            GlobalVariables.add_1 = 0;
            GlobalVariables.add_2 = 0;
            GlobalVariables.add_3 = 0;
            return RedirectToAction("Reset");
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult IndexPost() {
            if (Request.Form.Keys.Contains("add_1")) {
                GlobalVariables.add_1 += 1;
            } else if (Request.Form.Keys.Contains("add_2")) {
                GlobalVariables.add_2 += 1;
            } else if (Request.Form.Keys.Contains("add_3")) {
                GlobalVariables.add_3 += 1;
            }

            return RedirectToAction("Results");
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
