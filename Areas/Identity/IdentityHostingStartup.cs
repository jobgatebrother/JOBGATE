using System;
using JOBGATE.Areas.Identity.Data;
using JOBGATE.Data;
using JOBGATE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JOBGATE.Areas.Identity.IdentityHostingStartup))]
namespace JOBGATE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<JOBGATEContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("JOBGATEContextConnection")));

                services.AddDefaultIdentity<UserAccount>(options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = true;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<JOBGATEContext>();;
            });
        }
    }
}