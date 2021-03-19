
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using JOBGATE.Models;
using JOBGATE.Areas.Identity.Data;
using JOBGATE.Data;
using static JOBGATE.Models.Employee.EPY_ViewData;


namespace JOBGATE_MVC_C.Controllers
{

    public class MyEmployeeController : Controller
    {

        private UserManager<UserAccount> _userManager;
        private readonly JOBGATEDataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MyEmployeeController(UserManager<UserAccount> userManager, JOBGATEDataContext context, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
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
            UserAccount user = await _userManager.GetUserAsync(HttpContext.User);

            //var Members = (from FirstName in _context.MembersInfoEPY select FirstName).ToList();
            var Employee = await _context.CPN_CompanyIntroduction.FirstOrDefaultAsync(m => m.UserID == _userManager.GetUserId(User));
            ViewData["Email"] = await _userManager.GetEmailAsync(user);

            var items = _context.CEN_LocationThailand
               .Select(i => new { i.ProvinceID, i.ProvinceEN })
               .Distinct();

            var itemspro = _context.CEN_LocationThailand
                .AsEnumerable()
                 .OrderBy(i => i.ProvinceEN)
                .GroupBy(
                i => i.ProvinceEN
               ).Select(x => x.First())
                 .ToList();

            GetDataPerson();
            GetNationality();
            ViewBag.listpro = new SelectList(itemspro, "ProvinceID", "ProvinceEN");
            ViewBag.listlocation = new SelectList(items, "ProvinceID", "ProvinceEN");
            return View(Employee);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Gender,Nationality,Address,MobilePhone,Birthday,DayB,MonthB,YearsB,ImageName,Created_at,ProvinceID,DistrictID,SubDistrictID")] Resume Person)
        {
           

                if (Person.DayB != 0 && Person.MonthB != 0 && Person.YearsB != 0)
                {
                    var date = Person.DayB + "/" + Person.MonthB + "/" + Person.YearsB;
                    DateTime Birthday = DateTime.ParseExact(date, "d/M/yyyy", null);
                    string uniqueFileName = UploadedFile(Person);


                    var EPY_Employees = new EPY_Employee
                    {
                        FirstName = Person.FirstName,
                        LastName = Person.LastName,
                        Gender = Person.GenderId,
                        Nationality = Person.NationalityId,
                        Address = Person.Address,
                        Birthday = Birthday,
                        UserID = _userManager.GetUserId(User),
                        MobilePhone = Person.MobilePhone,
                        Province = Person.ProvinceID,
                        District = Person.DistrictID,
                        SubDistrict = Person.SubDistrictID,
                        ImgPath = uniqueFileName
                    };


                    var recordCount = _context.EPY_Employee.Count(a => a.UserID == _userManager.GetUserId(User));
                    if (recordCount == 0)
                    {
                        _context.EPY_Employee.Add(EPY_Employees);
                        await _context.SaveChangesAsync();

                      
                    }
                    

                }
                return RedirectToAction("MyPage");

            

        }

        public async Task<IActionResult> Resume()
        {

            UserAccount user = await _userManager.GetUserAsync(HttpContext.User);
            bool message = user.EmailConfirmed;
            //string Email = user.Email;

            if (message == true)
            {


              
                var items = _context.CEN_LocationThailand
                 .Select(i => new { i.ProvinceID, i.ProvinceEN })
                 .Distinct();

                var itemspro = _context.CEN_LocationThailand
                    .AsEnumerable()
                     .OrderBy(i => i.ProvinceEN)
                    .GroupBy(
                    i => i.ProvinceEN
                   ).Select(x => x.First())
                     .ToList();

               

          

                Resume vm = new Resume();
                vm.ClientId = user.Id;
                Getlanguage();
                GetMarriageStatus();
                GetNationality();
                GetStudycat();
                GetCertificate();
                GetJobfield();
                GetDegrees();
                GetIndustry();
                GetPositionLevel();
                GetDataPerson();

                ViewBag.listpro = new SelectList(itemspro, "ProvinceID", "ProvinceEN");
                ViewBag.listlocation = new SelectList(items, "ProvinceID", "ProvinceEN");
  
                return View(vm);

     
            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }

        }

        public JsonResult GetLevel(string id)
        {

            var langitem = _context.CEN_ForeignLanguage

                .Select(i => new { i.LanguagelevelEN, i.LanguagelevelID, i.ForeignLanguageID })
                 .Where(i => i.ForeignLanguageID == id)
                .Distinct();

            return Json(new SelectList(langitem, "LanguagelevelID", "LanguagelevelEN"));
        }
        public JsonResult GetDistList(string id)
        {

            var items = _context.CEN_LocationThailand
               .Select(i => new { i.DistrictID, i.DistrictEN, i.ProvinceID })
               .Where(i => i.ProvinceID == id)
               .Distinct();

            return Json(new SelectList(items, "DistrictID", "DistrictEN"));
        }
        public JsonResult GetSubList(string id)
        {

            var items = _context.CEN_LocationThailand
               .Select(i => new { i.SubDistrictID, i.SubDistrictEN, i.DistrictID })
               .Where(i => i.DistrictID == id)
               .Distinct();

            return Json(new SelectList(items, "SubDistrictID", "SubDistrictEN"));
        }

        public void Getlanguage()
        {

            var langitem = _context.CEN_ForeignLanguage
           .Select(i => new { i.ForeignLanguageEN, i.ForeignLanguageID })
           .Distinct();

            ViewBag.listlang = new SelectList(langitem, "ForeignLanguageID", "ForeignLanguageEN");

        }

        public void GetMarriageStatus()
        {


            List<CEN_MarriageStatus> marriageStatuses = new List<CEN_MarriageStatus>();
            marriageStatuses = (from MarriageStatus in _context.CEN_MarriageStatus select MarriageStatus).ToList();
            ViewBag.listmarriage = new SelectList(marriageStatuses, "MarriageID", "MarriageNameEN");

        }

        public void GetNationality()
        {
            List<CEN_Nationality> nationalities = new List<CEN_Nationality>();
            nationalities = (from Nationality in _context.CEN_Nationality where Nationality.NationalityID != null orderby Nationality.NationalityEN select Nationality).ToList();
            ViewBag.listnational = new SelectList(nationalities, "NationalityID", "NationalityEN");
        }
        public void GetStudycat()
        {
            List<CEN_StudyCategory> studies = new List<CEN_StudyCategory>();
            studies = (from StudyCategory in _context.CEN_StudyCategory select StudyCategory).ToList();
            ViewBag.listStudy = new SelectList(studies, "StudyCatID", "StudyCatEN");
        }
        public void GetCertificate()
        {
            List<CEN_CertificateCategory> certificate = new List<CEN_CertificateCategory>();
            certificate = (from Cert_Pizes in _context.CEN_CertificateCategory select Cert_Pizes).ToList();
            ViewBag.listcert = new SelectList(certificate, "CertificateID", "CertificateEN");
        }

        public void GetPositionLevel()
        {
            List<CEN_Positionlevel> Position = new List<CEN_Positionlevel>();
            Position = (from PositionlevelEPY in _context.CEN_Positionlevel select PositionlevelEPY).ToList();
            ViewBag.listpos = new SelectList(Position, "PositionlevelID", "PositionlevelEN");
        }
        public void GetDegrees()
        {
            List<CEN_Degrees> degrees = new List<CEN_Degrees>();
            degrees = (from Degrees in _context.CEN_Degrees select Degrees).ToList();
            ViewBag.listdegree = new SelectList(degrees, "DegreeID", "DegreeEN");
        }
        public void GetIndustry()
        {
            List<CEN_IndustryCodeList> industries = new List<CEN_IndustryCodeList>();
            industries = (from Industry in _context.CEN_IndustryCodeList select Industry).ToList();
            ViewBag.listindustry = new SelectList(industries, "Code", "IndustryNameEN");

        }
     
        public void GetJobfield()
        {
            var itemsjob = _context.CEN_JobField
                 .AsEnumerable()
                  .OrderBy(i => i.JobFieldEN)
                 .GroupBy(
                 i => i.JobFieldEN
                )
                 .Select(x => x.First())
                  .ToList();
           
            ViewBag.listjobfield = new SelectList(itemsjob, "JobFieldID", "JobFieldEN");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterResume([Bind("FirstName,LastName,GenderId,Tel,MarriageStatusId,NationalityId,Address,Height,Weight,ReligionId,MilitaryId,MobilePhone,Birthday,DayB,MonthB,YearsB,ImageName,Created_at,ProvinceID,DistrictID,SubDistrictID")] Resume Person
                                                                , [Bind("DegreeId1,SchoolName1,StudyCateId1,MajorSubject1,GraduatationYear1,GPA1,DegreeId2,SchoolName2,StudyCateId2,MajorSubject2,GraduatationYear2,GPA2,DegreeId3,SchoolName3,StudyCateId3,MajorSubject3,GraduatationYear3,GPA3")] Resume Degree
                                                                , [Bind("CompanyName1,industryId1,JobFieldId1,PositionId1,WorkingDept1,Salary1,Jobduty1,Work_in_over1,Workoverseas1,WorkStart1,WorkEnd1,Status_Working1,WorkProvinceID1,WorkDistrictID1,WorkSubDistrictID1")] Resume Jobexp
                                                                , [Bind("EmploymentType1,EmploymentType2,EmploymentType3,EmploymentType4,JobField1,JobField2,ProvinceWorkLocation,ExpectedSalary,ResumeName")] Resume Result
                                                                , [Bind("Language1,Language2,Language3,drivinglicenseId,Drivinglicense1,Drivinglicense2,Drivinglicense3,Drivinglicense4,Drivinglicense5,Own_car1,Own_car2,Own_car3,Level1,Level2,Level3")] Resume Skill
                                                                , [Bind("CertCategoryId1,TitleName1,Issued_byCert1,CertCategoryId2,TitleName2,Issued_byCert2,CertCategoryId3,TitleName3,Issued_byCert3")] Resume Certificate
                                                                , [Bind("EmploymentType1,EmploymentType2,EmploymentType3,EmploymentType4")] Resume Employment
                                                                , [Bind("TrainingName1,Issued_bytrain1,DateEndTraining1,DateStartTraining1,TrainingName2,Issued_bytrain2,DateEndTraining2,DateStartTraining2,TrainingName3,Issued_bytrain3,DateEndTraining3,DateStartTraining3")] Resume Train
                                                                , [Bind("EPY_RequiredJob,ResumeName")]Resume ShowData )

        {
            UserAccount user = await _userManager.GetUserAsync(HttpContext.User);
            bool message = user.EmailConfirmed;
            string Id = user.Id;
          

            if (message == true)
            {
               
                var sh = _context.EPY_ShowResume.ToList();
                var em = _context.EPY_Employee.ToList();
                var ch = sh.Join(em, t => t.Employee, f => f.ID.ToString(), (t, f) => new { t, f })
                    .Count(re => re.f.UserID == _userManager.GetUserId(User));

                if (ch < 3)
                {
                  
            
            
                     
                        var EPY_SkillTraning = new EPY_SkillTraning
                        {
                            Language1 = Skill.Language1,
                            Language2 = Skill.Language2,
                            Language3 = Skill.Language3,
                            LevelLanguage1 = Skill.Level1,
                            LevelLanguage2 = Skill.Level2,
                            LevelLanguage3 = Skill.Level3,
                            DrivingLicenseCar = Skill.Drivinglicense1,
                            DrivingLicenseMotorbike = Skill.Drivinglicense2,
                            DrivingLicenseTruck = Skill.Drivinglicense3,
                            DrivingLicenseTrailer = Skill.Drivinglicense4,
                            DrivingLicenseForklift = Skill.Drivinglicense5,
                            OwrCarForkCar = Skill.Own_car1,
                            OwrCarForkMotorbike = Skill.Own_car2,
                            OwrCarForkTruck = Skill.Own_car3

                        };

                _context.EPY_SkillTraning.Add(EPY_SkillTraning);

                await _context.SaveChangesAsync();
              
                var Certificate_EPY = new EPY_Certificate
                            {
                               SkillID = EPY_SkillTraning.ID.ToString(),
                                CertCategory = Certificate.CertCategoryId1,
                                TitleName = Certificate.TitleName1,
                                Issued_by = Certificate.Issued_byCert1
                            };

                    var Certificate_EPY2 = new EPY_Certificate
                    {
                        SkillID = EPY_SkillTraning.ID.ToString(),
                        CertCategory = Certificate.CertCategoryId2,
                        TitleName = Certificate.TitleName2,
                        Issued_by = Certificate.Issued_byCert2
                    };

                    var Certificate_EPY3 = new EPY_Certificate
                    {
                        SkillID = EPY_SkillTraning.ID.ToString(),
                        CertCategory = Certificate.CertCategoryId3,
                        TitleName = Certificate.TitleName3,
                        Issued_by = Certificate.Issued_byCert3
                    };

                    //}


                    var Training_EPY = new EPY_Training
                            {
                                SkillID = EPY_SkillTraning.ID.ToString(),
                                TrainingName = Train.TrainingName1,
                                StartTraining = Train.DateStartTraining1,
                                EndTraining = Train.DateEndTraining1,
                                Issued_by = Train.Issued_bytrain1
                            };
                   
                    var Training_EPY2 = new EPY_Training
                    {
                        SkillID = EPY_SkillTraning.ID.ToString(),
                        TrainingName = Train.TrainingName2,
                        StartTraining = Train.DateStartTraining2,
                        EndTraining = Train.DateEndTraining2,
                        Issued_by = Train.Issued_bytrain2
                   
                    };
                    var Training_EPY3 = new EPY_Training
                    {
                        SkillID = EPY_SkillTraning.ID.ToString(),
                        TrainingName = Train.TrainingName3,
                        StartTraining = Train.DateStartTraining3,
                        EndTraining = Train.DateEndTraining3,
                        Issued_by = Train.Issued_bytrain3
                    };

                  
                    var RequiredJob_EPY = new EPY_RequiredJob
                    {
                        JobField1 = Result.JobField1,
                        JobField2 = Result.JobField2,
                        FullTime = Result.EmploymentType1,
                        PartTime = Result.EmploymentType2,
                        Freelance = Result.EmploymentType3,
                        Intern = Result.EmploymentType4,
                        WorkLocation = Result.ProvinceWorkLocation,
                        ExpectedSalary = Result.ExpectedSalary,
                       

                    };

                    if (Certificate.TitleName1 != null) { _context.EPY_Certifiacte.Add(Certificate_EPY); }
                    if (Certificate.TitleName2 != null) { _context.EPY_Certifiacte.Add(Certificate_EPY2); }
                    if (Certificate.TitleName3 != null) { _context.EPY_Certifiacte.Add(Certificate_EPY3); }
                    if (Train.TrainingName1 != null) { _context.EPY_Training.Add(Training_EPY); }
                    if (Train.TrainingName2 != null) { _context.EPY_Training.Add(Training_EPY2); }
                    if (Train.TrainingName3 != null) { _context.EPY_Training.Add(Training_EPY3); }
                 
                _context.EPY_RequiredJob.Add(RequiredJob_EPY);

                await _context.SaveChangesAsync();

                var ResumeId = "RM" + DateTime.Now.ToString("yyyyMMddhhmmssfff");


                    if (Person.DayB != 0 && Person.MonthB != 0 && Person.YearsB != 0)
                    {
                        var date = Person.DayB + "/" + Person.MonthB + "/" + Person.YearsB;
                        DateTime Birthday = DateTime.ParseExact(date, "d/M/yyyy", null);
                        string uniqueFileName = UploadedFile(Person);


                        var EPY_Employees = new EPY_Employee
                        {
                            FirstName = Person.FirstName,
                            LastName = Person.LastName,
                            Gender = Person.GenderId,
                            Tel = Person.Tel,
                            MarriageStatus = Person.MarriageStatusId,
                            Nationality = Person.NationalityId,
                            Military = Person.MilitaryId,
                            Religion = Person.ReligionId,
                            Address = Person.Address,
                            Height = Person.Height,
                            Weight = Person.Weight,
                            Birthday = Birthday,
                            UserID = _userManager.GetUserId(User),
                            MobilePhone = Person.MobilePhone,
                            Province = Person.ProvinceID,
                            District = Person.DistrictID,
                            SubDistrict = Person.SubDistrictID,
                            ImgPath = uniqueFileName
                        };


                        var recordCount = _context.EPY_Employee.Count(a => a.UserID == _userManager.GetUserId(User));
                        if (recordCount == 0)
                        {
                            _context.EPY_Employee.Add(EPY_Employees);
                            await _context.SaveChangesAsync();
                          
                            var EPY_ShowResume = new EPY_ShowResume
                            {

                                ResumeID = ResumeId,
                                ResumeName = ShowData.ResumeName,
                                Employee = EPY_Employees.ID.ToString(),
                                RequiredJob = RequiredJob_EPY.ID.ToString(),
                                SkillTraning = EPY_SkillTraning.ID.ToString(),
                                Date_create = DateTime.Now,
                                Date_update = DateTime.Now,
                                Status_open = true


                            };
                            _context.EPY_ShowResume.Add(EPY_ShowResume);
                        }
                        else if (recordCount != 0)
                        {

                            var CheckId = await _context.EPY_Employee.FirstOrDefaultAsync(m => m.UserID == _userManager.GetUserId(User));
                            var IDemp = CheckId.ID;
                            var EPY_ShowResume = new EPY_ShowResume
                            {

                                ResumeID = ResumeId,
                                ResumeName = ShowData.ResumeName,
                                Employee = IDemp.ToString(),
                                RequiredJob = RequiredJob_EPY.ID.ToString(),
                                SkillTraning = EPY_SkillTraning.ID.ToString(),
                                Date_create = DateTime.Now,
                                Date_update = DateTime.Now,
                                Status_open = true


                            };

                            _context.EPY_ShowResume.Add(EPY_ShowResume);
                        }

                    }

                
                   
                  
                    if (Jobexp.CompanyName1 != null) {
                        var JobExp_EPY = new EPY_JobExp
                        {
                            ResumeID = ResumeId,
                            CompanyName = Jobexp.CompanyName1,
                            Industry = Jobexp.industryId1,
                            JobField = Jobexp.JobFieldId1,
                            Position = Jobexp.PositionId1,
                            WorkingDept = Jobexp.WorkingDept1,
                            Salary = Jobexp.Salary1,
                            Jobduty = Jobexp.Jobduty1,
                            DateStartWork = Jobexp.WorkStart1,
                            DateEndWork = Jobexp.WorkEnd1,
                            Province = Jobexp.WorkProvinceID1,
                            District = Jobexp.WorkDistrictID1,
                            SubDistrict = Jobexp.WorkSubDistrictID1,
                            Statuswork = Jobexp.Status_Working1,
                            Country = Jobexp.Workoverseas1,
                            DateCreate = DateTime.Now,
                            DateEdit = DateTime.Now

                        };
                        _context.EPY_JobExp.Add(JobExp_EPY);
                    }
                    if (Jobexp.CompanyName2 != null)
                    {
                        var JobExp_EPY2 = new EPY_JobExp
                        {
                            ResumeID = ResumeId,
                            CompanyName = Jobexp.CompanyName2,
                            Industry = Jobexp.industryId2,
                            JobField = Jobexp.JobFieldId2,
                            Position = Jobexp.PositionId2,
                            WorkingDept = Jobexp.WorkingDept2,
                            Salary = Jobexp.Salary2,
                            Jobduty = Jobexp.Jobduty2,
                            DateStartWork = Jobexp.WorkStart2,
                            DateEndWork = Jobexp.WorkEnd2,
                            Province = Jobexp.WorkProvinceID2,
                            District = Jobexp.WorkDistrictID2,
                            SubDistrict = Jobexp.WorkSubDistrictID2,
                            Statuswork = Jobexp.Status_Working2,
                            Country = Jobexp.Workoverseas2,
                            DateCreate = DateTime.Now,
                            DateEdit = DateTime.Now

                        };
                        _context.EPY_JobExp.Add(JobExp_EPY2);
                    }
                    if (Jobexp.CompanyName3 != null)
                    {
                        var JobExp_EPY3 = new EPY_JobExp
                        {
                            ResumeID = ResumeId,
                            CompanyName = Jobexp.CompanyName3,
                            Industry = Jobexp.industryId3,
                            JobField = Jobexp.JobFieldId3,
                            Position = Jobexp.PositionId3,
                            WorkingDept = Jobexp.WorkingDept3,
                            Salary = Jobexp.Salary3,
                            Jobduty = Jobexp.Jobduty1,
                            DateStartWork = Jobexp.WorkStart3,
                            DateEndWork = Jobexp.WorkEnd3,
                            Province = Jobexp.WorkProvinceID3,
                            District = Jobexp.WorkDistrictID3,
                            SubDistrict = Jobexp.WorkSubDistrictID3,
                            Statuswork = Jobexp.Status_Working3,
                            Country = Jobexp.Workoverseas3,
                            DateCreate = DateTime.Now,
                            DateEdit = DateTime.Now

                        };
                        _context.EPY_JobExp.Add(JobExp_EPY3);
                    }



                    var Education_EPY1 = new EPY_Education
                {
                    ResumeID = ResumeId,
                    Degree = Degree.DegreeId1,
                    SchoolName = Degree.SchoolName1,
                    StudyCatagory = Degree.StudyCateId1,
                    MajorSubject = Degree.MajorSubject1,
                    GraduatationYear = Degree.GraduatationYear1,
                    GPA = Degree.GPA1


                };

                var Education_EPY2 = new EPY_Education
                {
                    ResumeID = ResumeId,
                    Degree = Degree.DegreeId2,
                    SchoolName = Degree.SchoolName2,
                    StudyCatagory = Degree.StudyCateId2,
                    MajorSubject = Degree.MajorSubject2,
                    GraduatationYear = Degree.GraduatationYear2,
                    GPA = Degree.GPA2


                };

                var Education_EPY3 = new EPY_Education
                {
                    ResumeID = ResumeId,
                    Degree = Degree.DegreeId3,
                    SchoolName = Degree.SchoolName3,
                    StudyCatagory = Degree.StudyCateId3,
                    MajorSubject = Degree.MajorSubject3,
                    GraduatationYear = Degree.GraduatationYear3,
                    GPA = Degree.GPA3


                };

                if (Degree.DegreeId1 != null || Degree.SchoolName1 != null)
                {
                    _context.EPY_Education.Add(Education_EPY1);
                }
                if (Degree.DegreeId2 != null || Degree.SchoolName2 != null)
                {

                    _context.EPY_Education.Add(Education_EPY2);
                }
                if (Degree.DegreeId3 != null || Degree.SchoolName3 != null)
                {

                    _context.EPY_Education.Add(Education_EPY3);
                }

                await _context.SaveChangesAsync();


                return RedirectToAction("ManageResume");

                }
                return RedirectToAction("ManageResume");
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
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Employee//Img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageName.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageName.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        
        public async Task<IActionResult> ManageResume()
        {


            UserAccount user = await _userManager.GetUserAsync(HttpContext.User);
            string Id = user.Id;
            bool message = user.EmailConfirmed;
            if (message == true)
            {
                GetDataResume();


                return View();

            }
            else
            {
                return RedirectToAction("ConfirmEmail");
            }
           

        }

        public void GetDataResume()
        {
            Array ModelResume;
            List<ViewResume> model = new List<ViewResume>();

            var loca = _context.CEN_LocationThailand.ToList();
            var Resume = _context.EPY_ShowResume.ToList();
            var JobFil = _context.CEN_JobField.ToList();
            var Emp = _context.EPY_Employee.ToList();
            var der = _context.EPY_Education.ToList();
            var gg = _context.EPY_RequiredJob.ToList();

            var Require = gg
                .AsEnumerable()
                
                .GroupJoin(loca, r => r.WorkLocation, q => q.ProvinceID, (r, q) => new { r, q })
               .SelectMany(g => g.q.DefaultIfEmpty(), (g, q) => new { g.r, q })
               .GroupJoin(JobFil, er => er.r.JobField1, de => de.JobFieldID, (er, de) => new { er, de })
               .SelectMany(ag => ag.de.DefaultIfEmpty(), (ag,de) => new { ag.er, de})
               .GroupJoin(JobFil, es => es.er.r.JobField2, ds => ds.JobFieldID, (es, ds) => new { es, ds })
               .SelectMany(ku => ku.ds.DefaultIfEmpty(), (ku,ds)=> new { ku.es, ds})
                 
                .Join(Resume, ge => ge.es.er.r.ID.ToString(), ce => ce.RequiredJob,(ge, ce) => new {ge, ce})
                .Join(Emp, cx => cx.ce.Employee, cz => cz.ID.ToString(), (cx,cz) => new { cx,cz } )
                 .Where(e => e.cz.UserID == _userManager.GetUserId(User))

               
                .GroupBy(x => new { x.cx.ge.es.er.q.ProvinceID, x.cx.ge.es.er.q.ProvinceEN,x.cx.ge.es.er.r.ExpectedSalary,x.cx.ce.ResumeName,job1 = x.cx.ge.es.de.JobFieldEN,x.cx.ce.Status_open,x.cx.ce.ID  })
             .Select(g => new { g.Key.ProvinceEN,g.Key.ExpectedSalary,g.Key.ResumeName,g.Key.job1,g.Key.Status_open,g.Key.ID})
                .ToList();

            var ad = Resume.Join(Emp, c => c.Employee, d => d.ID.ToString(), (c, d) => new { c, d })
                .Join(gg, cd => cd.c.RequiredJob, df => df.ID.ToString(), (cd, df) => new { cd, df })
                .Where(e => e.cd.d.UserID == _userManager.GetUserId(User)).ToList();


            foreach (var Manage in Require)
            {

                model.Add(new JOBGATE.Models.Employee.EPY_ViewData.ViewResume
                {
                    ResumeName = Manage.ResumeName,
                    Worklocation = Manage.ProvinceEN,
                    JobField = Manage.job1,
                  // JobField2 = Manage.job2,
                    ExpectedSalary = Manage.ExpectedSalary.ToString(),
                    status = Manage.Status_open,
                    ID = Manage.ID
                    



                });
            }

            ModelResume = model.ToArray();
            ViewBag.Resume = ModelResume;


        }

        


        public async Task<IActionResult> Resume_Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Array ModelPerson;
            List<Resume> modellistregis = new List<Resume>();

            var main = _context.EPY_ShowResume.Where(e => e.ID == id).ToList();
            var Require = _context.EPY_RequiredJob.ToList();
            var edu = _context.EPY_Education.ToList();
            var Person = _context.EPY_Employee
               
                .ToList();

            var setRevise = main.Join(Person, ae => ae.Employee, ar => ar.ID.ToString(), (ae, ar) => new { ae, ar })
                //.GroupJoin(edu, ac => ac.ae.ID.ToString(), ab => ab.ResumeID, (ac, ab) => new { ac, ab })
                //.SelectMany(gr => gr.ab.DefaultIfEmpty(), (gr,ab) => new { gr.ac,ab })
                .Join(Require, ad => ad.ae.RequiredJob, af => af.ID.ToString(), (ad, af) => new { ad, af })
                .ToList();

           


            foreach (var Regis in setRevise)
            {

                DateTime Birthday = Regis.ad.ar.Birthday;
                modellistregis.Add(new JOBGATE.Models.Employee.EPY_ViewData.Resume
                {
                    FirstName = Regis.ad.ar.FirstName,
                    LastName = Regis.ad.ar.LastName,
                    GenderId = Regis.ad.ar.Gender,
                    MobilePhone = Regis.ad.ar.MobilePhone,
                    Tel = Regis.ad.ar.Tel,
                    MarriageStatusId = Regis.ad.ar.MarriageStatus,
                    NationalityId = Regis.ad.ar.Nationality,
                    Address = Regis.ad.ar.Address,
                    Height = Regis.ad.ar.Height,
                    Weight = Regis.ad.ar.Weight,
                    ReligionId = Regis.ad.ar.Religion,
                    MilitaryId = Regis.ad.ar.Military,
                    DayB = Birthday.Day,
                    MonthB = Birthday.Month,
                    YearsB = Birthday.Year,
                    Image = Regis.ad.ar.ImgPath,
                   // DegreeId1 = Regis.ad.Degree,
                   // SchoolName1 = Regis.ad.SchoolName


                });
            }

            ModelPerson = modellistregis.ToArray();
            ViewBag.ResumeRegis = ModelPerson;


            return View();
        }
        
        public void GetDataPerson()
        {
            Array ModelPerson;
            List<Resume> modellistregis = new List<Resume>();

            var Person = _context.EPY_Employee
                .Where(e => e.UserID == _userManager.GetUserId(User))
                .ToList();
            // var register = Person.Join()
            

            foreach (var Regis in Person)
            {

                DateTime Birthday = Regis.Birthday;
                modellistregis.Add(new JOBGATE.Models.Employee.EPY_ViewData.Resume
                {
                 FirstName = Regis.FirstName,
                 LastName = Regis.LastName,
                 GenderId = Regis.Gender,
                 MobilePhone = Regis.MobilePhone,
                 Tel = Regis.Tel,
                 MarriageStatusId = Regis.MarriageStatus,
                 NationalityId = Regis.Nationality,
                 Address = Regis.Address,
                 Height = Regis.Height,
                 Weight = Regis.Weight,
                 ReligionId = Regis.Religion,
                 MilitaryId = Regis.Military,
                 DayB = Birthday.Day,
                 MonthB = Birthday.Month,
                 YearsB = Birthday.Year,
                 Image = Regis.ImgPath


                });
            }

            ModelPerson = modellistregis.ToArray();
            ViewBag.ResumeRegis = ModelPerson;


        }
       

        public JsonResult EditStatus(int? id, bool status)
        {
            var result = _context.EPY_ShowResume.Where(a => a.ID == id).FirstOrDefault();
            if (result != null)
            {
                result.Status_open = status;
                _context.SaveChanges();
            }
            return Json(result);
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
