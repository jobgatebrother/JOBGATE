using JOBGATE_MVC_C.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register_EPY()
        {
            return View();
        }

        public IActionResult Register_CPN()
        {
            return View();
        }
        //GET : Account/Register_Result
        public IActionResult Register_Result(Register_EPYModel RegisterEPY)
        {
            string Email = RegisterEPY.Email;
            string ConfirmEmail = RegisterEPY.ConfirmEmail;
            //string Password = RegisterEPY.Password;
            //string ConfirmPassword = RegisterEPY.ConfirmPassword;
            ////string CompanyName = RegisterCPN.CompanyName;
            ////string JobPosition = RegisterCPN.JobPosition;
            ////string Contact = RegisterCPN.Contact;
            ////string Telephon = RegisterCPN.Telephon;

            return View(RegisterEPY);

        }

       
        
    }
}
