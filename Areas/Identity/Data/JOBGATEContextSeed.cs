using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Areas.Identity.Data
{
    public static class JOBGATEContextSeed
    {
        public static async Task SeedDefaultAsync(UserManager<UserAccount> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            if (!await roleManager.RoleExistsAsync("Company"))
            {
                await roleManager.CreateAsync(new IdentityRole("Company"));
            }
            var defaultUser = new UserAccount
            {
                UserName = "AdminJOBGATE",
                Email = "dev@jobgate.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "jobgate@m1n");
            }
            defaultUser = await userManager.FindByEmailAsync("dev@jobgate.com");
            if (!await userManager.IsInRoleAsync(defaultUser,"Admin"))
            {
                await userManager.AddToRoleAsync(defaultUser, "Admin");
            }    
        }
    }
}
