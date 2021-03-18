using JOBGATE.Areas.Identity.Data;
using JOBGATE.Data;
using JOBGATE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    public class MyCompanyController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly JOBGATEDataContext _context;

        public MyCompanyController(JOBGATEDataContext context, UserManager<UserAccount> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCompanyPage()
        {
            var CompanyIntroduction = await _context.CPN_CompanyIntroduction.FirstOrDefaultAsync(m => m.UserID == _userManager.GetUserId(User));
            var user = await _userManager.GetUserAsync(User);
            ViewData["Email"] = await _userManager.GetEmailAsync(user);

            ViewBag.Industry = new SelectList(_context.CEN_IndustryCodeList.Select(m => new { m.Code, m.IndustryNameEN }), "Code", "IndustryNameEN",CompanyIntroduction.Industry);
            ViewBag.Province = new SelectList(_context.CEN_LocationThailand.Select(m => new { m.ProvinceID ,m.ProvinceEN}).Distinct(), "ProvinceID", "ProvinceEN");
            ViewBag.District = new SelectList(_context.CEN_LocationThailand.Where(m => m.ProvinceID == CompanyIntroduction.Province).Select(m => new { m.DistrictID, m.DistrictEN }).Distinct(), "DistrictID", "DistrictEN");
            ViewBag.SubDistrict = new SelectList(_context.CEN_LocationThailand.Where(m => m.DistrictID == CompanyIntroduction.District).Select(m => new { m.SubDistrictID, m.SubDistrictEN }).Distinct(), "SubDistrictID", "SubDistrictEN");

            return View(CompanyIntroduction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyCompanyPage_Update([Bind("ID,UserID,CompanyName,Industry,Province,District,SubDistrict,Address,Website,Contract,Telephone,InternalPhone,CompanyDetail,WelfareBenefit")] CPN_CompanyIntroduction CompanyIntroduction)
        {
            if (ModelState.IsValid)
            {
                _context.Update(CompanyIntroduction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(MyCompanyPage));
        }

        public IActionResult Favorite()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public async Task<IActionResult> JobPosting(string filter)
        {
            string strfilter = "";
            if (filter == null)
            {
                strfilter = "";
            }
            else
            {
                strfilter = "AND jp.Status = '" + filter + "' ";
            }
            var JobPosting = await _context.CPN_JobPosting.FromSqlRaw
                (
                    "SELECT " +
                    "jp.ID " +
                    ",jp.UserID " +
                    ",jp.CompanyName " +
                    ",jp.Industry " +
                    ",jp.Oversea " +
                    ",jp.Country " +
                    ",Province = (SELECT DISTINCT ProvinceEN FROM CEN_LocationThailand WHERE ProvinceID = jp.Province) " +
                    ",jp.District " +
                    ",jp.SubDistrict " +
                    ",jp.Address " +
                    ",jp.Website " +
                    ",jp.Contract " +
                    ",jp.Telephone " +
                    ",jp.MobilePhone " +
                    ",jp.Email " +
                    ",jp.CompanyDetail " +
                    ",jp.WelfareBenefit " +
                    ",jp.JobTitle " +
                    ",jp.JobType " +
                    ",JobField = (SELECT DISTINCT JobFieldEN FROM CEN_JobField WHERE JobFieldID = jp.JobField) " +
                    ",jp.PositionLevel " +
                    ",jp.JobDescription " +
                    ",jp.JobExperience " +
                    ",jp.EducationDegree " +
                    ",jp.LanguageSkill " +
                    ",jp.Car " +
                    ",jp.Motorbike " +
                    ",jp.Truck " +
                    ",jp.Trailer " +
                    ",jp.Forklift " +
                    ",jp.QualificationDetail " +
                    ",jp.AgeMin " +
                    ",jp.AgeMax " +
                    ",jp.SalaryMin " +
                    ",jp.SalaryMax " +
                    ",jp.ResumeType " +
                    ",jp.JobAdvertise " +
                    ",jp.ApplyCount " +
                    ",jp.CreateDate " +
                    ",jp.UpdateDate " +
                    ",jp.ViewCount " +
                    ",jp.FreshGraduated " +
                    ",jp.Status " +
                    "FROM CPN_JobPosting jp " +
                    "WHERE jp.UserID = '"+ _userManager.GetUserId(User) +"' " +
                    ""+ strfilter +" "
                ).ToListAsync();
            return View(JobPosting);
        }

        public IActionResult Payment()
        {
            return View();
        }

        public async Task<IActionResult> JobPosting_New()
        {
            var CompanyIntroduction = await _context.CPN_CompanyIntroduction.FirstOrDefaultAsync(m => m.UserID == _userManager.GetUserId(User));
            var user = await _userManager.GetUserAsync(User);

            ViewBag.UserID =  user.Id;
            ViewBag.CompanyName = CompanyIntroduction.CompanyName;
            ViewBag.Address = CompanyIntroduction.Address;
            ViewBag.Contract = CompanyIntroduction.Contract;
            ViewBag.Telephone = CompanyIntroduction.Telephone;
            ViewBag.Email = user.Email;
            ViewBag.Website = CompanyIntroduction.Website;
            ViewBag.CompanyDetail = CompanyIntroduction.CompanyDetail;
            ViewBag.WelfareBenefit = CompanyIntroduction.WelfareBenefit;

            ViewBag.Industry = new SelectList(_context.CEN_IndustryCodeList.Select(m => new { m.Code, m.IndustryNameEN }), "Code", "IndustryNameEN", CompanyIntroduction.Industry);
            ViewBag.Province = new SelectList(_context.CEN_LocationThailand.Select(m => new { m.ProvinceID, m.ProvinceEN }).Distinct(), "ProvinceID", "ProvinceEN", CompanyIntroduction.Province);
            ViewBag.District = new SelectList(_context.CEN_LocationThailand.Where(m => m.ProvinceID == CompanyIntroduction.Province).Select(m => new { m.DistrictID, m.DistrictEN }).Distinct(), "DistrictID", "DistrictEN", CompanyIntroduction.District);
            ViewBag.SubDistrict = new SelectList(_context.CEN_LocationThailand.Where(m => m.DistrictID == CompanyIntroduction.District).Select(m => new { m.SubDistrictID, m.SubDistrictEN }).Distinct(), "SubDistrictID", "SubDistrictEN", CompanyIntroduction.SubDistrict);
            ViewBag.JobField = new SelectList(_context.CEN_JobField, "JobFieldID", "JobFieldEN");
            ViewBag.Postitionlevel = new SelectList(_context.CEN_Positionlevel, "PositionlevelID", "PositionlevelEN");
            ViewBag.Degree = new SelectList(_context.CEN_Degrees, "DegreeID", "DegreeEN");
            ViewBag.Language = new SelectList(_context.CEN_ForeignLanguage.Select(m => new { m.ForeignLanguageID,m.ForeignLanguageEN }).Distinct(), "ForeignLanguageID", "ForeignLanguageEN");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JobPosting_New(CPN_JobPosting JobPostingDB)
        {
            _context.Add(JobPostingDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(JobPosting));
        }

        public async Task<IActionResult> JobPosting_Edit(int? id)
        {
            var JobPostingDB = await _context.CPN_JobPosting.FindAsync(id);
            ViewBag.Industry = new SelectList(_context.CEN_IndustryCodeList.Select(m => new { m.Code, m.IndustryNameEN }), "Code", "IndustryNameEN", JobPostingDB.Industry);
            ViewBag.Province = new SelectList(_context.CEN_LocationThailand.Select(m => new { m.ProvinceID, m.ProvinceEN }).Distinct(), "ProvinceID", "ProvinceEN", JobPostingDB.Province);
            ViewBag.District = new SelectList(_context.CEN_LocationThailand.Where(m => m.ProvinceID == JobPostingDB.Province).Select(m => new { m.DistrictID, m.DistrictEN }).Distinct(), "DistrictID", "DistrictEN", JobPostingDB.District);
            ViewBag.SubDistrict = new SelectList(_context.CEN_LocationThailand.Where(m => m.DistrictID == JobPostingDB.District).Select(m => new { m.SubDistrictID, m.SubDistrictEN }).Distinct(), "SubDistrictID", "SubDistrictEN", JobPostingDB.SubDistrict);
            ViewBag.JobField = new SelectList(_context.CEN_JobField, "JobFieldID", "JobFieldEN", JobPostingDB.JobField);
            ViewBag.Postitionlevel = new SelectList(_context.CEN_Positionlevel, "PositionlevelID", "PositionlevelEN", JobPostingDB.PositionLevel);
            ViewBag.Degree = new SelectList(_context.CEN_Degrees, "DegreeID", "DegreeEN", JobPostingDB.EducationDegree);
            ViewBag.Language = new SelectList(_context.CEN_ForeignLanguage.Select(m => new { m.ForeignLanguageID, m.ForeignLanguageEN }).Distinct(), "ForeignLanguageID", "ForeignLanguageEN", JobPostingDB.LanguageSkill);
            return View(JobPostingDB) ;
        }

        [HttpPost]
        public async Task<IActionResult> JobPosting_Edit(CPN_JobPosting JobPostingDB)
        {
            _context.Update(JobPostingDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(JobPosting));
        }

        public async Task<IActionResult> JobPosting_Copy(int? id)
        {
            var data = await _context.CPN_JobPosting.FindAsync(id);
            var JobPostingDB = new CPN_JobPosting 
            {
                UserID = data.UserID,
                CompanyName = data.CompanyName,
                Industry = data.Industry,
                Oversea = data.Oversea,
                Country = data.Country,
                Province = data.Province,
                District = data.District,
                SubDistrict = data.SubDistrict,
                Address = data.Address,
                Website = data.Website,
                Contract = data.Contract,
                Telephone = data.Telephone,
                MobilePhone = data.MobilePhone,
                Email = data.Email,
                CompanyDetail = data.CompanyDetail,
                WelfareBenefit = data.WelfareBenefit,
                JobTitle = data.JobTitle,
                JobField = data.JobField,
                PositionLevel = data.PositionLevel,
                JobDescription = data.JobDescription,
                FreshGraduated = data.FreshGraduated,
                JobExperience = data.JobExperience,
                EducationDegree = data.EducationDegree,
                LanguageSkill = data.LanguageSkill,
                Car = data.Car,
                Motorbike = data.Motorbike,
                Truck = data.Truck,
                Trailer = data.Trailer,
                Forklift = data.Forklift,
                QualificationDetail = data.QualificationDetail,
                AgeMin = data.AgeMin,
                AgeMax = data.AgeMax,
                SalaryMin = data.SalaryMin,
                SalaryMax = data.SalaryMax,
                ResumeType = data.ResumeType,
                JobAdvertise = data.JobAdvertise,
                ApplyCount = data.ApplyCount,
                ViewCount = data.ViewCount,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Status = false
            };

            _context.Add(JobPostingDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(JobPosting));
        }

        public async Task<IActionResult> JobPosting_Delete(int? id)
        {
            var JobPostingDB = await _context.CPN_JobPosting.FindAsync(id);
            _context.CPN_JobPosting.Remove(JobPostingDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(JobPosting));
        }

        public JsonResult GetDistrict(string ProvinceID)
        {
            var DistrictList = new SelectList(_context.CEN_LocationThailand.Where(m => m.ProvinceID == ProvinceID).Select(m => new { m.DistrictID, m.DistrictEN }).Distinct(), "DistrictID", "DistrictEN");
            return Json(DistrictList);

        }

        public JsonResult GetSubDistrict(string DistrictID)
        {
            var SubDistrictList = new SelectList(_context.CEN_LocationThailand.Where(m => m.DistrictID == DistrictID).Select(m => new { m.SubDistrictID, m.SubDistrictEN }), "SubDistrictID", "SubDistrictEN");
            return Json(SubDistrictList);

        }

        public async Task<JsonResult> ShowJob(int id,bool status)
        {
            var JobPostingDB = await _context.CPN_JobPosting.FindAsync(id);
            JobPostingDB.Status = status;
            _context.Update(JobPostingDB);
            await _context.SaveChangesAsync();
            return Json(JobPostingDB);
        }
    }
}
