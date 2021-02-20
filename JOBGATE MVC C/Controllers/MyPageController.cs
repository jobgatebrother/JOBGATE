using JOBGATE_MVC_C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
//using Source_git.Data;
using JOBGATE_MVC_C.Email;
using Microsoft.EntityFrameworkCore;

namespace JOBGATE_MVC_C.Controllers
{
    [Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class MyPageController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private readonly AccountsContext _context;
        public MyPageController(UserManager<AppUser> usrMgr, SignInManager<AppUser> signinMgr, RoleManager<IdentityRole> roleMgr, AccountsContext context)
        {
            userManager = usrMgr;
            signInManager = signinMgr;
            roleManager = roleMgr;
            _context = context;
        }

        //private readonly AccountsContext _context;

        //public MyPageController(AccountsContext context)
        //{
        //    _context = context;
        //}
        // [Authorize(Roles = "Manager")]
        // [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> MyPage()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            
            //var Members = (from FirstName in _context.MembersInfoEPY select FirstName).ToList();
            MyPage use = new MyPage();
            use.Email = user.Email;
            use.ClientId = user.Id;
            
            //Use.Id = user.Id;
            //Use.Name = user.UserName;

            return View(use);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Tel,CurrentAddress,ClientId")] MembersInfoEPY myPage)
        {
            if (ModelState.IsValid)
            {

                _context.Add(myPage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Resume");

            }

            return RedirectToAction("MyPage");
        }

        public async Task<IActionResult> Resume()
        {

            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            bool message = user.EmailConfirmed;
            //string Email = user.Email;

            if (message == true)
            {

               // PostViewModel vm = new PostViewModel();
               // vm.Religions = (from ReligionName in _context.Religion select ReligionName).ToList();
               // vm.Militaries = (from MilitaryName in _context.Military select MilitaryName).ToList();
               // vm.Nationalities = (from NationalityName in _context.Nationality select NationalityName).ToList();
               // vm.Locations = (from LocationName in _context.Location where LocationName.PID == 3 select LocationName).ToList();
               //// vm.Locations = (from District in _context.Location where District.PID == 4 select District).ToList();
               // vm.Members = (from Mem in _context.MembersInfoEPY  select Mem).ToList();
               // List<PostViewModel> viewModelList = new List<PostViewModel>();
               // viewModelList.Add(vm);
               // return View(viewModelList.AsEnumerable());





                return View();

            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterResume([Bind("FirstName,LastName,Gender,Tel,MarriageStatusId,NationalityId,CurrentAddress,Height,Weight,ReligionId,MilitaryId,MobliePhone")]MembersInfoEPY model
                                                                ,Resume m
                                                                ,[Bind("DegreeId,SchoolName,StudyCateId,MajorSubject,Year,GPAscore")]DegreeEPY Dg
                                                                ,[Bind("DegreeId,SchoolName,StudyCateId,MajorSubject,Year,GPAscore")]DegreeEPY Dg2
                                                                ,[Bind("CompanyName,industryId,JobFieldId,PositionId,WorkingDept,Salary,Jobduty,Working_in_overseas")]JobExpEPY Jobexp
                                                                ,Resume Sk)
        {

            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            bool message = user.EmailConfirmed;
            //string Email = user.Email;

            if (message == true)
            {
                //if (ModelState.IsValid)
                //{
                //int Day = m.Day;
                //int Month = m.Month;
                //int Year = m.Year;
                Resume Re = new Resume();
                Re.Language = Sk.Language;
                Re.Drivinglicense = Sk.Drivinglicense;
                Re.Own_car = Sk.Own_car;
                Re.CertName = Sk.CertName;
                //_context.Add(model);
                //_context.Add(Dg);
                //_context.Add(Dg2);
                //_context.Add(Jobexp);
                //await _context.SaveChangesAsync();
                return RedirectToAction("ViewDataModel", new {Re});

                // }

                //return RedirectToAction("MyPage");




            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }

        }
        public IActionResult ViewDataModel(Resume Sk)
        {
            Resume Re = new Resume();
            //Required
            Re.JobField1 = Sk.JobField1;
            Re.JobField2 = Sk.JobField2;
            Re.EmploymentType = Sk.EmploymentType;
            Re.ProvinceWorkLocation = Sk.ProvinceWorkLocation;
            Re.ExpectedSalary = Sk.ExpectedSalary;
           
            //Skill
            Re.Language = Sk.Language;
            Re.Drivinglicense = Sk.Drivinglicense;
            Re.Own_car = Sk.Own_car;
            Re.LanguageEX = Sk.LanguageEX;
            Re.Level = Sk.Level;
            Re.CertName = Sk.CertName;
            Re.Scgrade = Sk.Scgrade;
            Re.Own_car = Sk.Own_car;
            Re.Issued_byCert = Sk.Issued_byCert;
            Re.TrainingName = Sk.TrainingName;
            Re.Issued_byTrain = Sk.Issued_byTrain;
            Re.StartYear = Sk.StartYear;
            Re.StartMonth = Sk.StartMonth;
            Re.EndYear = Sk.EndYear;
            Re.EndMonth = Sk.EndMonth;
            //Job Experience
            Re.CompanyName = Sk.CompanyName;
            Re.WorkStartYear = Sk.WorkStartYear;
            Re.WorkEndYear = Sk.WorkEndYear;
            Re.WorkStartMonth = Sk.WorkStartMonth;
            Re.WorkEndMonth = Sk.WorkEndMonth;
            Re.industryId = Sk.industryId;
            Re.JobFieldId = Sk.JobFieldId;
            Re.PositionId = Sk.PositionId;
            Re.WorkingDept = Sk.WorkingDept;
            Re.StudyNowJE = Sk.StudyNowJE;
            Re.ProvinceComId = Sk.ProvinceComId;
            Re.Salary = Sk.Salary;
            Re.Jobduty = Sk.Jobduty;
            //Education
            Re.DegreeId = Sk.DegreeId;
            Re.SchoolName = Sk.SchoolName;
            Re.StudyCateId = Sk.StudyCateId;
            Re.MajorSubject = Sk.MajorSubject;
            Re.GradYear = Sk.GradYear;
            Re.GPAscore = Sk.GPAscore;

            Re.DegreeId2 = Sk.DegreeId2;
            Re.SchoolName2 = Sk.SchoolName2;
            Re.StudyCateId2 = Sk.StudyCateId2;
            Re.MajorSubject2 = Sk.MajorSubject2;
            Re.GradYear2 = Sk.GradYear2;
            Re.GPAscore2 = Sk.GPAscore2;

            Re.DegreeId3 = Sk.DegreeId3;
            Re.SchoolName3 = Sk.SchoolName3;
            Re.StudyCateId3 = Sk.StudyCateId3;
            Re.MajorSubject3 = Sk.MajorSubject3;
            Re.GradYear3 = Sk.GradYear3;
            Re.GPAscore3 = Sk.GPAscore3;
            //Personel
            Re.FirstName = Sk.FirstName;
            Re.LastName = Sk.LastName;
            Re.Genderld = Sk.Genderld;
            Re.MobliePhone = Sk.MobliePhone;
            Re.DayB = Sk.DayB;
            Re.MonthB = Sk.MonthB;
            Re.YearsB = Sk.YearsB;
            Re.Tel = Sk.Tel;
            Re.MarriageStatusId = Sk.MarriageStatusId;
            Re.NationalityId = Sk.NationalityId;
            Re.StayingOver = Sk.StayingOver;
            Re.SameMobile = Sk.SameMobile;
            Re.ProvinceOwnId = Sk.ProvinceOwnId;
            Re.CurrentAddress = Sk.CurrentAddress;
            Re.Height = Sk.Height;
            Re.Weight = Sk.Weight;
            Re.ReligionId = Sk.ReligionId;
            Re.MilitaryId = Sk.MilitaryId;
            Re.Img = Sk.Img;
            // Re.Own_car = Sk.Own_car;
            return View(Re);
        }

        public async Task<IActionResult> ConfirmEmail()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);

            ConfirmEmail c = new ConfirmEmail();
            c.Email = user.Email;
            c.Name = user.UserName;



            return View(c);

        }
        //[Authorize]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmail model)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            // bool message = user.EmailConfirmed;
            //string UserName = user.Id;
            //string Email = model.Email;

            AppUser appUser = new AppUser
            {

                Email = model.Email,
                UserName = user.SecurityStamp
            };
            //IdentityResult result = await userManager.UpdateAsync(appUser);
            //if (result.Succeeded)
            //{
            var userId = await userManager.GetUserIdAsync(user);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            //token = System.Web.HttpUtility.UrlEncode(token);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = model.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(model.Email, confirmationLink);

            if (emailResponse)
                return RedirectToAction("MyPage");
            //}

            return View();




        }
        public IActionResult ManageResume()
        {
            return View();
        }

        public IActionResult Favorite()
        {
            return View();
        }

        public IActionResult Applying()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
