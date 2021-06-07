using E_CommerceClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceClient.Controllers
{
    public class ProductController : Controller
    {

        Covid_EssentialsContext db;

        public ProductController(Covid_EssentialsContext context)
        {
            db = context;

        }

        //get items

        //public IActionResult Index()
        //{

        //    return View(db.Emps.ToList());
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
