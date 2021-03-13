using JOBGATE.Areas.Identity.Data;
using JOBGATE.Data;
using JOBGATE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private bool CompanyIntroductionExists()
        {
            return _context.CPN_CompanyIntroduction.Any(e => e.UserID == _userManager.GetUserId(User));
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
            if (_userManager.GetUserId(User) != CompanyIntroduction.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(CompanyIntroduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyIntroductionExists())
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

        public IActionResult JobPosting()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        public async Task<IActionResult> JobPosting_New()
        {
            var CompanyIntroduction = await _context.CPN_CompanyIntroduction.FirstOrDefaultAsync(m => m.UserID == _userManager.GetUserId(User));
            var user = await _userManager.GetUserAsync(User);
            ViewData["Email"] = await _userManager.GetEmailAsync(user);

            ViewBag.Industry = new SelectList(_context.CEN_IndustryCodeList.Select(m => new { m.Code, m.IndustryNameEN }), "Code", "IndustryNameEN", CompanyIntroduction.Industry);
            ViewBag.Province = new SelectList(_context.CEN_LocationThailand.Select(m => new { m.ProvinceID, m.ProvinceEN }).Distinct(), "ProvinceID", "ProvinceEN");
            ViewBag.District = new SelectList(_context.CEN_LocationThailand.Where(m => m.ProvinceID == CompanyIntroduction.Province).Select(m => new { m.DistrictID, m.DistrictEN }).Distinct(), "DistrictID", "DistrictEN");
            ViewBag.SubDistrict = new SelectList(_context.CEN_LocationThailand.Where(m => m.DistrictID == CompanyIntroduction.District).Select(m => new { m.SubDistrictID, m.SubDistrictEN }).Distinct(), "SubDistrictID", "SubDistrictEN");

            return View(CompanyIntroduction);
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
    }
}
