using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JOBGATE_MVC_C.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }
}
