using JOBGATE_MVC_C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }
        //[Authorize(Roles = "Employee")]
        //public IActionResult MyPage()
        //{
        //    return View();
        //}
        //[Authorize]
        
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register_EPY()
        {

            return View();
        }

        public IActionResult Register_CPN()
        {
            return View();
        }
        public IActionResult test()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            //CheckoutModel Che = new CheckoutModel();
            //Che.ChargeID = Ch.ChargeID;
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
         public IActionResult Company_Introduction()
        {
            return View();
        }
        public IActionResult Job_Description()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult NewPassword()
        {
            return View();
        }

        public IActionResult JobResult()
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
