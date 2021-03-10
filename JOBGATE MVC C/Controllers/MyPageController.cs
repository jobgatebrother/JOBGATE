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
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly IWebHostEnvironment webHostEnvironment;
        public MyPageController(UserManager<AppUser> usrMgr, SignInManager<AppUser> signinMgr, RoleManager<IdentityRole> roleMgr, AccountsContext context, IWebHostEnvironment hostEnvironment)
        {
            userManager = usrMgr;
            signInManager = signinMgr;
            roleManager = roleMgr;
            _context = context;
            webHostEnvironment = hostEnvironment;
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

                var langitem = _context.ForeignLanguageEPY
               .Select(i => new { i.ForeignLanguage_Eng ,i.ForeignLanguage_ID})
               .Distinct();

               

                List<ForeignLanguage> ForeignLanguages = new List<ForeignLanguage>();
                ForeignLanguages = (from ForeignLanguage in _context.ForeignLanguageEPY select ForeignLanguage).ToList();

                List<MarriageStatus> marriageStatuses = new List<MarriageStatus>();
                marriageStatuses = (from MarriageStatus in _context.MarriageStatus select MarriageStatus).ToList();

                List<Nationality> nationalities = new List<Nationality>();
                nationalities = (from Nationality in _context.Nationality where Nationality.Nationality_ID != null orderby Nationality.Nationality_Eng select Nationality).ToList();

                List<Religion> religions = new List<Religion>();
                religions = (from Religion in _context.Religion select Religion).ToList();

                List<Military> militaries = new List<Military>();
                militaries = (from Military in _context.Military select Military).ToList();

                List<Degrees> degrees = new List<Degrees>();
                degrees = (from Degrees in _context.Degrees select Degrees).ToList();

                List<StudyCategory> studies = new List<StudyCategory>();
                studies = (from StudyCategory in _context.StudyCategory select StudyCategory).ToList();

                List<Industry> industries = new List<Industry>();
                industries = (from Industry in _context.Industry select Industry).ToList();

                List<JobFieldEPY> jobField = new List<JobFieldEPY>();
                jobField = (from JobFieldEPY in _context.JobFieldEPY select JobFieldEPY).ToList();

                List<Cert_pize> certificate = new List<Cert_pize>();
                certificate = (from Cert_Pizes in _context.Cert_Pizes select Cert_Pizes).ToList();


                List<PositionlevelEPY> Position = new List<PositionlevelEPY>();
                Position = (from PositionlevelEPY in _context.PositionlevelEPY select PositionlevelEPY).ToList();

                List<MembersInfoEPY> members = new List<MembersInfoEPY>();
                members = (from MembersInfoEPY in _context.MembersInfoEPY select MembersInfoEPY).ToList();

             //// var  Loca = (from e in _context.Location group e.Province_Eng by e.Id into g select new { Id = g.Key , Province_Eng = g.ToList()});
             //var test = _context.Location.Where(j => j.Province_ID.HasValue && Province_ID2.C(j.ObjectId.Value))
             //       .Where(j => j.Id == db.Jobs.Where(j2 => j2.ObjectId == j.ObjectId).Max(j => j.Id))
             //       .ToList();
                var items = _context.Location
                 .Select(i => new { i.Province_ID, i.Province_Eng})
                 .Distinct();

                var itemspro = _context.Location
                    .AsEnumerable()
                    .GroupBy(
                    i => i.Province_Eng
                   ) .Select(x => x.First())
                     .ToList();
                    
                //    _context.Location
                //.Select(i => new { i.Province_ID, i.Province_Eng })
                //.Distinct();

                Resume vm = new Resume();
                vm.ClientId = user.Id;
            
                ViewBag.listlang = new SelectList(langitem, "ForeignLanguage_ID", "ForeignLanguage_Eng");
                //ViewBag.listlevel = new SelectList(langlevel, "Languagelevel_Eng"); ;
                //ViewBag.listexam = languageExam;
                ViewBag.listpro = new SelectList(itemspro, "Id", "Province_Eng");
                ViewBag.listmarriage = marriageStatuses;
                ViewBag.listnational = nationalities;
                ViewBag.listreli = religions;
                ViewBag.listmili = militaries;
                ViewBag.listdegree = degrees;
                ViewBag.listStudy = studies;
                ViewBag.listindustry = industries;
                ViewBag.listjobfield = jobField;
                ViewBag.listpos = Position;
                ViewBag.listmem = members;
                ViewBag.listcert = certificate;
                ViewBag.listlocation = new SelectList(items, "Province_ID", "Province_Eng");
                return View(vm);





                //return View(Re);

            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }

        }

        public JsonResult GetLevel(string id)
        {

            var langitem = _context.ForeignLanguageEPY
                .Select(i => new { i.Languagelevel_Eng, i.Id ,i.ForeignLanguage_ID})
                 .Where(i => i.ForeignLanguage_ID == id)
                .Distinct();
            // List<Location> District = _context.Location.Where(x => x.Province_ID == Province_ID).ToList();
            //ViewBag.listDistrict = new SelectList(items, "District_ID", "District_Eng");
            return Json(new SelectList(langitem, "Id", "Languagelevel_Eng"));
        }
        public JsonResult GetDistList(string id)
        {

            var items = _context.Location
               .Select(i => new { i.District_ID, i.District_Eng, i.Province_ID })
               .Where(i => i.Province_ID == id)
               .Distinct();
          // List<Location> District = _context.Location.Where(x => x.Province_ID == Province_ID).ToList();
            //ViewBag.listDistrict = new SelectList(items, "District_ID", "District_Eng");
            return Json(new SelectList(items, "District_ID", "District_Eng"));
        }
        public JsonResult GetSubList(string id)
        {

            var items = _context.Location
               .Select(i => new { i.Tambon_ID, i.Tambon_Eng, i.District_ID ,i.Id})
               .Where(i => i.District_ID == id)
               .Distinct();
            // List<Location> District = _context.Location.Where(x => x.Province_ID == Province_ID).ToList();
            //ViewBag.listDistrict = new SelectList(items, "District_ID", "District_Eng");
            return Json(new SelectList(items, "Id", "Tambon_Eng"));
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterResume([Bind("FirstName,LastName,GenderId,Tel,MarriageStatusId,NationalityId,CurrentAddress,Height,Weight,ReligionId,MilitaryId,MobilePhone,Birthday,DayB,MonthB,YearsB,ClientId,ImageName,Created_at,ProvinceOwnId")] Resume Person
                                                                , [Bind("DegreeId,SchoolName,StudyCateId,MajorSubject,GradYear,GPAscore")] Resume Dg
                                                                , [Bind("DegreeId2,SchoolName2,StudyCateId2,MajorSubject2,GradYear2,GPAscore2")] Resume Dg2
                                                                , [Bind("DegreeId3,SchoolName3,StudyCateId3,MajorSubject3,GradYear3,GPAscore3")] Resume Dg3
                                                                , [Bind("CompanyName,industryId,JobFieldId,PositionId,WorkingDept,Salary,Jobduty,Working_in_overseas,WorkStartYear,WorkStartMonth,WorkEndYear,WorkEndMonth,etcposition, Status_Working,ProvinceComId")] Resume Jobexp
                                                                , [Bind("drivinglicenseId,Drivinglicense1,Drivinglicense2,Drivinglicense3,Drivinglicense4,Drivinglicense5,ResumeId")] Resume Dv
                                                                , [Bind("MemberRegisterId,JobfieldId,JobField2Id,locationId,JobExpId,PositionId,DrivinglicenseId,ClientId,JobField1,JobField2,ProvinceWorkLocation,ExpectedSalary,ResumeName")] Resume Result
                                                                , [Bind("DegreeId,ResumeId")] Resume Edu
                                                                , [Bind("vehicleId,ResumeId,vehicleId,Own_car1,Own_car2,Own_car3")] Resume Vch
                                                                , [Bind("CategoryId,CertName,Issued_by")] Resume Cert
                                                                , [Bind("EmploymentType1,EmploymentType2,EmploymentType3,EmploymentType4")] Resume Employment
                                                                , [Bind("TrainingName,CertName,Issued_by,StartTraining,EndTraining,StartMonth,StartYear,EndMonth,EndYear,Issued_byCert")] Resume Train
                                                                , [Bind("LanguageEX,Language,Level,Scgrade")]Resume lang)
                                                               
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            bool message = user.EmailConfirmed;
            string Id = user.Id;
            //string Email = user.Email;

            if (message == true)
            {
                var Members = (from Res in _context.MembersInfoEPY where Res.ClientId == Id select Res).ToList();


                var recordResume = _context.ResumeEPY.Count(a => a.MemberRegisterId == Person.ClientId);
                if (recordResume < 3)
                {
                   
               

                //var register_EPYModel = await _context.ResumeEPY
                //    .FirstOrDefaultAsync(m => m.MemberRegisterId == Id);
                //if (Members == null)
                //{
                if (Person.DayB != 0 && Person.MonthB != 0 && Person.YearsB != 0)
                {
                    var date = Person.DayB + "/" + Person.MonthB + "/" + Person.YearsB;
                    DateTime Birthday = DateTime.ParseExact(date, "d/M/yyyy", null);
             

                var MembersInfoEPY = new MembersInfoEPY
                {
                    FirstName = Person.FirstName,
                    LastName = Person.LastName,
                    GenderId = Person.GenderId,
                    Tel = Person.Tel,
                    MarriageStatusId = Person.MarriageStatusId,
                    NationalityId = Person.NationalityId,
                    MilitaryId = Person.MilitaryId,
                    ReligionId = Person.ReligionId,
                    CurrentAddress = Person.CurrentAddress,
                    Height = Person.Height,
                    Weight = Person.Weight,
                    Birthday = Birthday,
                    ClientId = Person.ClientId,
                    MobilePhone = Person.MobilePhone,
                    LocationId = Person.ProvinceOwnId
                };

                if (Person.MarriageStatusId != "" && Person.NationalityId != 0 && Person.MilitaryId != "" && Person.ReligionId != "" && Person.ProvinceOwnId != 0)
                {
                    var recordCount = _context.MembersInfoEPY.Count(a => a.ClientId == Person.ClientId);
                    if (recordCount == 0)
                    {
                        _context.MembersInfoEPY.Add(MembersInfoEPY);
                    }

                }

                }
                //await _context.SaveChangesAsync();
                DateTime now = DateTime.Now;


                string uniqueFileName = UploadedFile(Person);

                ImageFile image = new ImageFile
                {
                    ImageName = uniqueFileName,
                    ClientId = Person.ClientId,
                    Created_at = now
                };
                if (uniqueFileName != null)
                {
                    _context.Add(image);

                }

                // await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));


                // DateTime Def = "0 / 0 / 0000 00:00:00";
                var IDRSM = "RSM" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                var IDdeg = "DEG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                var IDdeg2 = "DEG2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                var IDdeg3 = "DEG3" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                var ResumeEPY = new ResumeEPY
                {
                    MemberRegisterId = Result.ClientId,
                    JobfieldId = Result.JobField1,
                    JobField2Id = Result.JobField2,
                    locationId = Result.ProvinceWorkLocation,
                    ExpectedSalary = Result.ExpectedSalary,
                    ResumeName = Result.ResumeName,
                    Created_at = now,
                    Update_at = now,
                    Id = IDRSM
                    // Deleted_at = Def

                };
                int Num;
                // if (Result.JobField1 != "null") { }
                bool isNum = int.TryParse(Result.ProvinceWorkLocation.ToString(), out Num);
                if (Result.JobField1 != "" && isNum)
                {
                    _context.ResumeEPY.Add(ResumeEPY);
                    await _context.SaveChangesAsync();

                }
              
                    var DegreeEPY = new DegreeEPY
                {
                    DegreeId = Dg.DegreeId,
                    SchoolName = Dg.SchoolName,
                    StudyCateId = Dg.StudyCateId,
                    MajorSubject = Dg.MajorSubject,
                    Year = Dg.GradYear,
                    GPAScore = Dg.GPAscore,
                    Id = IDdeg

                };

                var DegreeEPY2 = new DegreeEPY
                {
                    DegreeId = Dg2.DegreeId2,
                    SchoolName = Dg2.SchoolName2,
                    StudyCateId = Dg2.StudyCateId2,
                    MajorSubject = Dg2.MajorSubject2,
                    Year = Dg2.GradYear2,
                    GPAScore = Dg2.GPAscore2,
                    Id = IDdeg2

                };
                var DegreeEPY3 = new DegreeEPY
                {
                    DegreeId = Dg3.DegreeId3,
                    SchoolName = Dg3.SchoolName3,
                    StudyCateId = Dg3.StudyCateId3,
                    MajorSubject = Dg3.MajorSubject3,
                    Year = Dg3.GradYear3,
                    GPAScore = Dg3.GPAscore3,
                    Id = IDdeg3

                };
                    var IDEDC = "EDC1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var IDEDC2 = "EDC2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var IDEDC3 = "EDC3" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    if (Dg2.DegreeId2 == "null" && Dg2.StudyCateId2 == "null" && Dg3.DegreeId3 == "null" && Dg3.StudyCateId3 == "null" && Dg.DegreeId != "null" && Dg.StudyCateId != "null")
                    {
                        
                        _context.DegreeEPY.Add(DegreeEPY);
                        await _context.SaveChangesAsync();
                        //int dg1 = DegreeEPY.Id;
                        var EducationEPY = new EducationEPY
                        {

                            DegreeId = DegreeEPY.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };

                        _context.EducationEPY.Add(EducationEPY);

                    }
                    else if (Dg.DegreeId == "null" && Dg.StudyCateId == "null" && Dg3.DegreeId3 == "null" && Dg3.StudyCateId3 == "null" && Dg2.DegreeId2 != "null" && Dg2.StudyCateId2 != "null")
                    {
                        _context.DegreeEPY.Add(DegreeEPY2);
                        await _context.SaveChangesAsync();

                        var EducationEPY = new EducationEPY
                        {

                            DegreeId = DegreeEPY2.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };

                        _context.EducationEPY.Add(EducationEPY);
                    }
                    else if (Dg2.DegreeId2 == "null" && Dg2.StudyCateId2 == "null" && Dg.DegreeId == "null" && Dg.StudyCateId == "null" && Dg3.DegreeId3 != "null" && Dg3.StudyCateId3 != "null")
                    {
                        _context.DegreeEPY.Add(DegreeEPY3);
                        await _context.SaveChangesAsync();

                        var EducationEPY = new EducationEPY
                        {

                            DegreeId = DegreeEPY3.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };

                        _context.EducationEPY.Add(EducationEPY);
                    }
                    else if (Dg2.DegreeId2 == "null" && Dg2.StudyCateId2 == "null" && Dg.DegreeId != "null" && Dg.StudyCateId != "null" && Dg3.DegreeId3 != "null" && Dg3.StudyCateId3 != "null")
                    {
                        _context.DegreeEPY.Add(DegreeEPY);
                        _context.DegreeEPY.Add(DegreeEPY3);
                        await _context.SaveChangesAsync();

                        var Deg = new EducationEPY
                        {

                            DegreeId = DegreeEPY.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };
                        var Deg3 = new EducationEPY
                        {

                            DegreeId = DegreeEPY3.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC2

                        };

                        _context.EducationEPY.Add(Deg);
                        _context.EducationEPY.Add(Deg3);
                    }
                    else if (Dg.DegreeId == "null" && Dg.StudyCateId == "null" && Dg2.DegreeId2 != "null" && Dg2.StudyCateId2 != "null" && Dg3.DegreeId3 != "null" && Dg3.StudyCateId3 != "null")
                    {
                        _context.DegreeEPY.Add(DegreeEPY2);
                        _context.DegreeEPY.Add(DegreeEPY3);
                        await _context.SaveChangesAsync();

                        var Deg2 = new EducationEPY
                        {

                            DegreeId = DegreeEPY2.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };
                        var Deg3 = new EducationEPY
                        {

                            DegreeId = DegreeEPY3.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC2

                        };

                        _context.EducationEPY.Add(Deg2);
                        _context.EducationEPY.Add(Deg3);
                    }
                    else if (Dg3.DegreeId3 == "null" && Dg3.StudyCateId3 == "null" && Dg.DegreeId != "null" && Dg.StudyCateId != "null" && Dg2.DegreeId2 != "null" && Dg2.StudyCateId2 != "null")
                    {
                        _context.DegreeEPY.Add(DegreeEPY);
                        _context.DegreeEPY.Add(DegreeEPY2);
                        await _context.SaveChangesAsync();

                        var Deg = new EducationEPY
                        {

                            DegreeId = DegreeEPY.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };
                        var Deg2 = new EducationEPY
                        {

                            DegreeId = DegreeEPY2.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC2

                        };

                        _context.EducationEPY.Add(Deg);
                        _context.EducationEPY.Add(Deg2);
                    }
                    else if (Dg.DegreeId != "null" && Dg.StudyCateId != "null" && Dg2.DegreeId2 != "null" && Dg2.StudyCateId2 != "null" && Dg3.DegreeId != "null" && Dg3.StudyCateId != "null")
                    {

                        _context.DegreeEPY.Add(DegreeEPY);
                        _context.DegreeEPY.Add(DegreeEPY2);
                        _context.DegreeEPY.Add(DegreeEPY3);
                        await _context.SaveChangesAsync();

                        var Deg = new EducationEPY
                        {

                            DegreeId = DegreeEPY.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC

                        };
                        var Deg2 = new EducationEPY
                        {

                            DegreeId = DegreeEPY2.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC2

                        };
                        var Deg3 = new EducationEPY
                        {

                            DegreeId = DegreeEPY3.Id,
                            ResumeId = ResumeEPY.Id,
                            Id = IDEDC3

                        };
                        _context.EducationEPY.Add(Deg);
                        _context.EducationEPY.Add(Deg2);
                        _context.EducationEPY.Add(Deg3);

                    }




                var dateStartWorking = Jobexp.WorkStartMonth + "/" + Jobexp.WorkStartYear;
                var dateEndWorking = Jobexp.WorkEndMonth + "/" + Jobexp.WorkEndYear;
               
                if (Jobexp.WorkStartMonth != 0 && Jobexp.WorkEndMonth != 0)
                {
                    DateTime StartWorking = DateTime.ParseExact(dateStartWorking, "M/yyyy", null);
                    DateTime EndWorking = DateTime.ParseExact(dateEndWorking, "M/yyyy", null);


                        var IDjxe = "JXE1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var JobExpEPY = new JobExpEPY
                {
                    CompanyName = Jobexp.CompanyName,
                    industryId = Jobexp.industryId,
                    JobFieldId = Jobexp.JobFieldId,
                    PositionId = Jobexp.PositionId,
                    WorkingDept = Jobexp.WorkingDept,
                    Salary = Jobexp.Salary,
                    Jobduty = Jobexp.Jobduty,
                    Workingstart = StartWorking,
                    Workingend = EndWorking,
                    etcposition = Jobexp.etcposition,
                    CompanylocationId = Jobexp.ProvinceComId,
                    Status_Working = Jobexp.Status_Working,
                    working_in_overseas = Jobexp.Working_in_overseas,
                    Id = IDjxe

                        };
                if (Jobexp.CompanyName != "" )
                {
                    _context.JobExpEPY.Add(JobExpEPY);
                }

                    //await _context.SaveChangesAsync();

                }
                if(lang.Language != "" && lang.Level != "") 
                {
                    if (lang.Language != "" && lang.Language2 == "" && lang.Language3 == "")
                    {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        _context.LanguageMainEPY.Add(languageMain);
                    }

                    else if (lang.Language == "" && lang.Language2 != "" && lang.Language3 == "")
                    {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain2 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language2,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        _context.LanguageMainEPY.Add(languageMain2);
                    }
                    else if (lang.Language == "" && lang.Language2 == "" && lang.Language3 != "")
                    {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain3 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language3,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        _context.LanguageMainEPY.Add(languageMain3);
                    }
                    else if (lang.Language != "" && lang.Language2 != "" && lang.Language3 == "")
                    {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var IDlang2 = "LANG2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        var languageMain2 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language2,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang2

                        };

                        _context.LanguageMainEPY.Add(languageMain);
                        _context.LanguageMainEPY.Add(languageMain2);
                    }
                    else if (lang.Language != "" && lang.Language2 == "" && lang.Language3 != "")
                    {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var IDlang2 = "LANG2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        var languageMain3 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language3,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang2

                        };

                        _context.LanguageMainEPY.Add(languageMain);
                        _context.LanguageMainEPY.Add(languageMain3);

                    }
                    else if (lang.Language == "" && lang.Language2 != "" && lang.Language3 != "")
                    {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var IDlang2 = "LANG2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain2 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language2,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        var languageMain3 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language3,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang2

                        };
                        _context.LanguageMainEPY.Add(languageMain2);
                        _context.LanguageMainEPY.Add(languageMain3);
                    }
                    else if (lang.Language != "null" && lang.Language2 != "null" && lang.Language3 != "null") {
                        var IDlang = "LANG1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var IDlang2 = "LANG2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var IDlang3 = "LANG3" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        var languageMain = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang

                        };
                        var languageMain2 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language2,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang2

                        };
                        var languageMain3 = new LanguageMain
                        {
                            ForeignLanguageId = lang.Language3,
                            ResumeId = ResumeEPY.Id,
                            Id = IDlang3

                        };
                        _context.LanguageMainEPY.Add(languageMain);
                        _context.LanguageMainEPY.Add(languageMain2);
                        _context.LanguageMainEPY.Add(languageMain3);
                    }
                    // _context.LanguageMain.Add(languageMain);


                }
              
                   
               

                if (Dv.Drivinglicense1 != "false")
                {
                    var IDDRI1 = "DV"+ DateTime.Now.ToString("yyyyMMddhhmmssfff");

                    var drivinglicense = new DrivingEPY
                    {
                        drivinglicenseId = Dv.Drivinglicense1,
                        ResumeId = ResumeEPY.Id,
                        Id = IDDRI1


                    };
                    _context.DrivingEPY.Add(drivinglicense);
                }
                if (Dv.Drivinglicense2 != "false")
                {
                    var IDDRI2 = "DV2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var drivinglicense2 = new DrivingEPY
                    {
                        drivinglicenseId = Dv.Drivinglicense2,
                        ResumeId = ResumeEPY.Id,
                        Id = IDDRI2


                    };
                    _context.DrivingEPY.Add(drivinglicense2);
                }
                if (Dv.Drivinglicense3 != "false")
                {
                    var IDDRI3 = "DV3" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var drivinglicense3 = new DrivingEPY
                    {
                        drivinglicenseId = Dv.Drivinglicense3,
                        ResumeId = ResumeEPY.Id,
                        Id = IDDRI3


                    };
                    _context.DrivingEPY.Add(drivinglicense3);
                }
                if (Dv.Drivinglicense4 != "false")
                {
                    var IDDRI4 = "DV4" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var drivinglicense4 = new DrivingEPY
                    {
                        drivinglicenseId = Dv.Drivinglicense4,
                        ResumeId = ResumeEPY.Id,
                        Id = IDDRI4


                    };
                    _context.DrivingEPY.Add(drivinglicense4);
                }
                if (Dv.Drivinglicense5 != "false")
                {
                    var IDDRI5 = "DV5" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var drivinglicense5 = new DrivingEPY
                    {
                        drivinglicenseId = Dv.Drivinglicense5,
                        ResumeId = ResumeEPY.Id,
                        Id = IDDRI5


                    };
                    _context.DrivingEPY.Add(drivinglicense5);

                }



                if (Vch.Own_car1 != "false")
                {
                    var IDVCH = "VCH1" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Vechicle = new VehicleEPY
                    {
                        vehicleId = Vch.Own_car1,
                        ResumeId = ResumeEPY.Id,
                        Id = IDVCH


                    };
                    _context.VehicleEPY.Add(Vechicle);
                }
                if (Vch.Own_car2 != "false")
                {
                    var IDVCH2 = "VCH2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Vechicle2 = new VehicleEPY
                    {
                        vehicleId = Vch.Own_car2,
                        ResumeId = ResumeEPY.Id,
                        Id = IDVCH2


                    };
                    _context.VehicleEPY.Add(Vechicle2);
                }
                if (Vch.Own_car3 != "false")
                {
                    var IDVCH3 = "VCH3" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Vechicle3 = new VehicleEPY
                    {
                        vehicleId = Vch.Own_car3,
                        ResumeId = ResumeEPY.Id,
                        Id = IDVCH3

                    };
                    _context.VehicleEPY.Add(Vechicle3);
                }
                if (Cert.CategoryId != "") {
                    var IDCert = "CTC" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Certificate = new CertificateEPY
                {
                    Id = IDCert,
                    Cert_CategoryCert_pize_Id = Cert.CategoryId,
                    CertName = Cert.CertName,
                        ResumeId = ResumeEPY.Id,
                        Issued_by = Cert.Issued_byCert
                };
                _context.CertificateEPY.Add(Certificate);
                }

                var dateStartrain = Train.StartMonth + "/" + Train.StartYear;
                var dateEndtrain = Train.EndMonth + "/" + Train.EndYear;
                if (Train.StartMonth != 0 && Train.EndMonth != 0 && Train.TrainingName != "")
                {
                    DateTime StartWorkingtrain = DateTime.ParseExact(dateStartrain, "M/yyyy", null);
                    DateTime EndWorkingtrain = DateTime.ParseExact(dateEndtrain, "M/yyyy", null);

                    var IDtrain = "TN" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Training = new TrainingEPY
                    {
                        Id = IDtrain,
                        TrainingName = Train.TrainingName,
                        StartTraining = StartWorkingtrain,
                        EndTraining = EndWorkingtrain,
                        ResumeId = ResumeEPY.Id,
                        Issued_by = Train.Issued_byCert
                    };
                    _context.TrainingEPY.Add(Training);
                }

                if (Employment.EmploymentType1 != "false") 
                {
                    var IDem = "EMT" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Employmemt = new EmploymentEPY
                    {
                        EmploymentId = Employment.EmploymentType1,
                        resumeId = ResumeEPY.Id,
                        Id = IDem

                    };
                    _context.EmploymentEPY.Add(Employmemt);
                }
                if (Employment.EmploymentType2 != "false")
                {
                    var IDem = "EMT2" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Employmemt2 = new EmploymentEPY
                    {
                        EmploymentId = Employment.EmploymentType2,
                        resumeId = ResumeEPY.Id,
                        Id = IDem

                    };
                    _context.EmploymentEPY.Add(Employmemt2);
                }
                if (Employment.EmploymentType3 != "false")
                {
                    var IDem = "EMT3" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Employmemt3 = new EmploymentEPY
                    {
                        EmploymentId = Employment.EmploymentType3,
                        resumeId = ResumeEPY.Id,
                        Id = IDem

                    };
                    _context.EmploymentEPY.Add(Employmemt3);
                }
                if (Employment.EmploymentType4 != "false")
                {
                    var IDem = "EMT4" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    var Employmemt4 = new EmploymentEPY
                    {
                        EmploymentId = Employment.EmploymentType4,
                        resumeId = ResumeEPY.Id,
                        Id = IDem

                    };
                    _context.EmploymentEPY.Add(Employmemt4);
                }



                await _context.SaveChangesAsync();


                return RedirectToAction("ManageResume");

                }
                return RedirectToAction("ViewDataModel");
            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }

        }

        private string UploadedFile(Resume model)
        {
            string uniqueFileName = null;

            if (model.ImageName != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images//Employee");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageName.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageName.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
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

        public async Task<IActionResult> ManageResume()
        {
           
        
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            string Id = user.Id;
            bool message = user.EmailConfirmed;
            if (message == true)
            {
               
                //PostViewModel vm = new PostViewModel();
                //List<> Position = new List<PositionlevelEPY>();
                List<PostViewModel> model = new List<PostViewModel>();
                var Resume = (from Re in _context.ResumeEPY
                                join JobFieldEPY in _context.JobFields on Re.JobfieldId equals JobFieldEPY.Id
                              join loca in _context.Location on Re.locationId equals loca.Id
                              join JobFieldEPY2 in _context.JobFields on Re.JobField2Id equals JobFieldEPY2.Id into newgroup                            
                              from J in newgroup.DefaultIfEmpty()
                              orderby Re.Update_at descending
                             
                              where Re.MemberRegisterId == Id
                               select new
                              {
                                  ResumeName = Re.ResumeName,
                                 Jobfield = JobFieldEPY.JobField_Eng,
                                   Jobfield2 = (J.JobField_Eng == null ? "" : " , "+ J.JobField_Eng.ToString()),
                                  // Jobfield2 = JobFieldEPY2.JobField_Eng,
                                  ExpectedSalary = Re.ExpectedSalary,
                                  Location = loca.Province_Eng,
                                  Show_open = Re.Show_open,
                                  Id = Re.Id
                                 
                              }).ToList();
                foreach (var item in Resume) //retrieve each item and assign to model
                {
                    model.Add(new PostViewModel()
                    {
                        ResumeName = item.ResumeName,
                        Jobfield = item.Jobfield,
                        Jobfield2 = item.Jobfield2,
                        ExpectedSalary = item.ExpectedSalary,
                        Location = item.Location,
                        Show_open = item.Show_open,
                        Id = item.Id
                        
                    });
                }

                ////vm.Members = (from Mem in _context.MembersInfoEPY select Mem).ToList();
                //List<PostViewModel> viewModelList = new List<PostViewModel>();
                //viewModelList.Add(vm);
                //if (viewModelList.AsEnumerable() != null) { return View(viewModelList.AsEnumerable()); }
                //var grouping = Resume.ToLookup(e => e.Jobfield2);
                // var xy = (Resume).ToList();
                return View(model);

            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }
            //if (Id == ) { }
            // var northwindContext = _context.ResumeEPY.Include(p => p.MemberRegister).Include(p => p.Jobfield).Include(p => p.location);


            //var register_EPYModel = await _context.ResumeEPY
            //    .FirstOrDefaultAsync(m => m.MemberRegisterId == Id);
            //if (register_EPYModel == null)
            //{
            //    return NotFound();
            //}
            //else
          
        }

        //public JsonResult EditStatus([Bind("Show_open,Id")] PostViewModel model, string id)
        //{

        //    var items = _context.Location
        //       .Select(i => new { i.Tambon_ID, i.Tambon_Eng, i.District_ID, i.Id })
        //       .Where(i => i.District_ID == id)
        //       .Distinct();
        //    // List<Location> District = _context.Location.Where(x => x.Province_ID == Province_ID).ToList();
        //    //ViewBag.listDistrict = new SelectList(items, "District_ID", "District_Eng");
        //    return Json(new SelectList(items, "Id", "Tambon_Eng"));
        //}

        [HttpPost]
        public async Task<IActionResult> EditStatus([Bind("Show_open,Id")]PostViewModel model,string id)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (model.Show_open != false)
            {
                var ResumeEPY = new ResumeEPY
                {

                    Show_open = false

                };
                _context.ResumeEPY.Update(ResumeEPY);
                await _context.SaveChangesAsync();
            }
            else
            {
                var ResumeEPY = new ResumeEPY
                {

                    Show_open = true

                };
                _context.ResumeEPY.Update(ResumeEPY);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }




        public IActionResult Favorite()
        {
            return View();
        }
        public IActionResult ViewDataModel()
        {
            return View();
        }
        public IActionResult ConfirmEmail()
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
