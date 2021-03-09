using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JOBGATE.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the UserAccount class
    public class UserAccount : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(max)")]
        public string CompanyName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Industry { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string ContratPerson { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Telephone { get; set; }
    }
}
