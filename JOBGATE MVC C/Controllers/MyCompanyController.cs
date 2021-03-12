using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    public class MyCompanyController : Controller
    {
        public IActionResult MyCompanyPage()
        {
            return View();
        }

        public IActionResult Favorite()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult JobPosting()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult JobPosting_New()
        {
            return View();
        }
    }
}
