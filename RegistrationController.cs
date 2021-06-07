using E_CommerceClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceClient.Controllers
{
    public class RegistrationController : Controller
    {

        Covid_EssentialsContext db;


        public RegistrationController(Covid_EssentialsContext context)
        {
            db = context;

        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Registration()
        {

            return View();

        }

       
    }

      
}
