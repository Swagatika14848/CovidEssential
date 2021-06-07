using E_CommerceClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Discount()
        {
            return View();

        }
        public IActionResult Service()
        {
            return View();

        }
      
        public IActionResult Contact()
        {

            return View();
        }
        //public string Subscribe(string input)
        //{

        //    if (!String.IsNullOrEmpty(input))
        //        return "Please welcome " + input + ".";
        //    else
        //        return "Please enter your email.";

        //}

      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
