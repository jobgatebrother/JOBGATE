using Microsoft.AspNetCore.Mvc;
using JOBGATE_MVC_C.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using JOBGATE_MVC_C.Email;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Source_git.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace JOBGATE_MVC_C.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> usrMgr, SignInManager<AppUser> signinMgr, RoleManager<IdentityRole> roleMgr)
        {
            userManager = usrMgr;
            signInManager = signinMgr;
            roleManager = roleMgr;
        }


        //public AccountController(AccountsContext context)
        //{
        //    _context = context;
        //}
        //[Authorize(Roles = "Manager")]
        //public async Task<IActionResult> MyPage()
        //{

        //    return View();
        //}
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register_EPY()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register_CPN()
        {
            return View();
        }
        //GET : Account/Register_Result
        
        [AllowAnonymous]
        public IActionResult Register_Result()
        {

            return View();

        }

        //public ViewResult Create() => View();

        // POST: Account/Register_EPY
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register_EPY(Register_EPYModel user)
        {
            //using (var context = new ApplicationDbContext())
            //{
                // IdentityResult resultRole;
                if (ModelState.IsValid)
                {

                    AppUser appUser = new AppUser
                    {
                        UserName = user.Name,
                        Email = user.Email

                    };
                    
                    IdentityResult result = await userManager.CreateAsync(appUser, user.Password);


                    //var userStore = new UserStore<AppUser>(context);
                    //var UserManager = new userManager<AppUser>(userStore);
                    //userManager.AddToRoleAsync(user.Id, "User");
                    //userManager.AddToRoleAsync(userManager.FindByNameAsync(user.Name), "Employee");
                    if (result.Succeeded)
                    {

                   // AppUser users = await userManager.GetUserAsync(HttpContext.User);
                      
                    //AppUser account = await userManager.GetUserAsync(HttpContext.User);
                    //AppUser user = await userManager.FindByIdAsync(userId);
                    //if (user != null)
                    //{
                    //    resultRole = await userManager.AddToRoleAsync(user, "Employee");
                    //    if (!resultRole.Succeeded)
                    //        Errors(resultRole);
                    //}
                    //foreach (string userId in model.AddIds ?? new string[] { })
                    //{
                    //    AppUser users = await userManager.FindByIdAsync(userId);
                    //    if (users != null)
                    //    {
                    //        resultRole = await userManager.AddToRoleAsync(users, model.RoleName);
                    //        if (!resultRole.Succeeded)
                    //            Errors(resultRole);
                    //    }
                    //}
                    //var token = await userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    //var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                    //EmailHelper emailHelper = new EmailHelper();
                    //bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

                    //if (emailResponse)
                    return RedirectToAction("Register_Result");
                        //else
                        //{
                        //    return RedirectToAction("Home");
                        //}
                    }
                    else
                    {
                        //foreach (IdentityError error in result.Errors)
                        //    ModelState.AddModelError("", error.Description);
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                   


                 
                }
                return View(user);
            //}
        }
        [HttpGet]
        [AllowAnonymous]
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Login(string returnUrl)
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Home");
            }
            else
            {
                Login_EPYModel login = new Login_EPYModel();
                login.ReturnUrl = returnUrl;
                return View(login);
            }
            
           
                 
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login_EPYModel user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(user.Email);
                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, user.Password, false, true);
                    if (result.Succeeded)
                        return Redirect(user.ReturnUrl ?? "/");

                    /*bool emailStatus = await userManager.IsEmailConfirmedAsync(appUser);
                    if (emailStatus == false)
                    {
                        ModelState.AddModelError(nameof(login.Email), "Email is unconfirmed, please confirm it first");
                    }*/

                    /*if (result.IsLockedOut)
                        ModelState.AddModelError("", "Your account is locked out. Kindly wait for 10 minutes and try again");*/

                    //if (result.RequiresTwoFactor)
                    //{
                    //    return RedirectToAction("LoginTwoStep", new { appUser.Email, login.ReturnUrl });
                    //}
                }
               
                

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            Response.Cookies.Delete(".AspNetCore.Identity.Application", new CookieOptions()
            {
                Secure = true,
            });
            //Response.Cookies["ASPXPIKESADMINAUTH"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }
         private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
               // return View(userInfo);
                return RedirectToAction("Register_Result");
            else
            {
                AppUser user = new AppUser
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
                };

                IdentityResult identResult = await userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                       // return View(userInfo);
                        return RedirectToAction("Register_Result");
                    }
                }
                return AccessDenied();
            }
        }

        //send email
        //public void SendEmailToUser(string emailId, string activationCode)
        //{
        //    var GenarateUserVerificationLink = "/Register/UserVerification/" + activationCode;
        //    //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);

        //    var fromMail = new MailAddress("rakeshchavda404@gmail.com", "Rakesh"); // set your email    
        //    var fromEmailpassword = "*******"; // Set your password     
        //    var toEmail = new MailAddress(emailId);

        //    var smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

        //    var Message = new MailMessage(fromMail, toEmail);
        //    Message.Subject = "Registration Completed-Demo";
        //    Message.Body = "<br/> Your registration completed succesfully." +
        //                   "<br/> please click on the below link for account verification" +
        //                   "<br/><br/><a href=" + link + ">" + link + "</a>";
        //    Message.IsBodyHtml = true;
        //    smtp.Send(Message);
        //}



    }
}
