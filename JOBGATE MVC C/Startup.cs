using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JOBGATE_MVC_C.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using Identity.IdentityPolicy;
using System;
using Microsoft.AspNetCore.Authorization;
using Identity.CustomPolicy;


namespace JOBGATE_MVC_C
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
          
            services.AddSession();

            services.AddDbContext<AccountsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AccountsContext")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AccountsContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = true;
               option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.User.AllowedUserNameCharacters =
           "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                // option.User.AllowedUserNameCharacters = null;

            });
           // services.ConfigureApplicationCookie(options =>
           //{
           //    options.Cookie.Name = ".AspNetCore.Identity.Application";
           //    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
           //    options.SlidingExpiration = true;
           //}); 

            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/Account/Login";
                opts.AccessDeniedPath = "/Home/Home";
            });

            //services.Configure<IdentityOptions>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
            //    opts.Password.RequiredLength = 8;

            //    opts.SignIn.RequireConfirmedEmail = true;
            //});
            services.AddAuthentication()
               .AddGoogle(opts =>
               {
                   opts.ClientId = "514514906254-gt4h07ghukks6otg9df7kbfak78nivl4.apps.googleusercontent.com";
                   opts.ClientSecret = "XjA8CsTzF9VX_kyrEz3kCpvF";
                   opts.SignInScheme = IdentityConstants.ExternalScheme;
               });
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Home}/{id?}");
            });
           
        }

    }
}
