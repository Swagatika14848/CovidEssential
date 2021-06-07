using E_CommerceClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceClient.Controllers
{
    public class ShoppingController : Controller
    {

        Covid_EssentialsContext db;

        public ShoppingController(Covid_EssentialsContext context)
        {
            db = context;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
