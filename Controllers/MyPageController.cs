using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    public class MyPageController : Controller
    {
        public IActionResult MyPage()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult ManageResume()
        {
            return View();
        }

        public IActionResult Favorite()
        {
            return View();
        }

        public IActionResult Applying()
        {
            return View();
        }
    }
}
