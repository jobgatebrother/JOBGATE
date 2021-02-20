using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace JOBGATE_MVC_C.Models
{
    public class ConfirmEmail
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        //public string Id { get; set; }
    }
}
