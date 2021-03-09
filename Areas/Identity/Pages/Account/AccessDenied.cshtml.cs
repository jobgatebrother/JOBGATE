using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JOBGATE.Areas.Identity.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {
        private readonly UserManager<UserAccount> _userManager;

        public AccessDeniedModel(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.FindByNameAsync(_userManager.GetUserName(User));
            if (await _userManager.IsInRoleAsync(user, "Company"))
            {
                return Redirect("/Company/Company");
            }
            return Redirect("/");
        }
    }
}

