using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models
{
    public class Register_EPYModel
    {
        [Required(ErrorMessage = "Incorrect Email form")]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No match with Email address")]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [Compare("Email", ErrorMessage = "No match with Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "PW Validation Error")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d)[a-z\d]{8,}$", ErrorMessage = "Minimum 8 characters, at least one lowercase letter and one number")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d)[a-z\d]{8,}$", ErrorMessage = "Minimum 8 characters, at least one lowercase letter and one number")]
        [Compare("Password", ErrorMessage = "No match with Confirm PW")]
        public string ConfirmPassword { get; set; }

        
        
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please accept our privacy terms")]
        public bool PrivacyCheck { get; set; }

    }
}
