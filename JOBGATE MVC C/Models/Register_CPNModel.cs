using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models
{
    public class Register_CPNModel
    {
        [Required(ErrorMessage = "<i class='bi bi - exclamation - triangle - fill'></i>Incorrect Email form")]
        [EmailAddress]
        //[Remote(controller: "Account", action: "IsUsedEmailID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No match with Email address")]
        [EmailAddress]
        //[Remote(controller: "Account", action: "IsUsedEmailID")]
        public string ConfirmEmail { get; set; }
        [Required(ErrorMessage = "PW Validation Error")]
        public string Password { get; set; }
        [Required(ErrorMessage = "No match with Confirm PW")]
        public string ConfirmPassword { get; set; }

        public string 
    }
}
