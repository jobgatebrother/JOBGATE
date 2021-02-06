using System;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE_MVC_C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JOBGATE_MVC_C.Controllers
{
    public class Register_EPYController : Controller
    {

        // GET: Home
        public ActionResult Register_EPY()
            {
                return View();
            }

        [HttpPost]
        public ActionResult Register_EPY(Register_EPYModel Register)
        {

            return View();
        }
        //[AllowAnonymous]
        //[AcceptVerbs("Get", "Post")]
        //public async Task<IActionResult> IsUsedEmailID(string Email)
        //{
        //    //if (!string.IsNullOrEmpty(EmailID))
        //    {
        //        var user = await _user.FindByEmailAsync(Email);

        //        if (user == null)
        //        {
        //            return Json(true);
        //        }
        //        else
        //        {
        //            return Json($"Email {Email} this Email ID already in Used.");
        //        }
        //    }

        //}


    }
}