using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    public class TermsController : Controller
    {
        public IActionResult TermsOfService()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cookie()
        {
            return View();
        }
    }
}
