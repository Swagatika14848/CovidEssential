using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_CommerceClient.ViewModels;
using E_CommerceClient.Models;
using Microsoft.AspNetCore.Identity;

namespace E_CommerceClient.Controllers
{
    public class AccountController : Controller
    {

        public readonly UserManager<UserDetail> userManager;//identity Api used for creating and managing users
        public readonly SignInManager<UserDetail> loginManager;//identity Api used for log in user in and out of the system
        public readonly RoleManager<UserRole> roleManager;//identity Api used for creating and managing  roles

        public AccountController(UserManager<UserDetail> userManager,
            SignInManager<UserDetail> loginManager,
            RoleManager<UserRole> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;


        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //user creation,role creation,assign role to user

        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                UserDetail user = new UserDetail();
                user.UserName = obj.UserName;
                user.UserEmail = obj.UserEmail;
                user.UserContact = obj.UserContact;
                user.UserAddress = obj.UserAddress;

                IdentityResult result = userManager.CreateAsync(user, obj.UserPassword).Result;
                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("Costumer").Result)
                    {
                        UserRole role = new UserRole();
                        role.RoleName = "Costumer";
                        
                        IdentityResult roleResult = roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error while creating Role.!");
                            return View(obj);
                        }


                    }

                    userManager.AddToRoleAsync(user, "Costumer").Wait();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    IEnumerable<IdentityError> errors = result.Errors;
                    foreach (var item in errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }

                }

            }
            return View(obj);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
