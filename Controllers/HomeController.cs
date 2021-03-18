using JOBGATE.Controllers;
using JOBGATE.Data;
using JOBGATE.Models;
using JOBGATE.Models.SearchListModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Controllers
{
    public class HomeController : Controller
    {
        private readonly JOBGATEContext _context;
        public  JOBGATEData_Context db = new JOBGATEData_Context();
        public SearchEn se = new SearchEn();

        public HomeController(JOBGATEContext context )
        {
            _context = context;
           
            
        }

        public IActionResult Home()
        {
            //QueryJobPost();
            ViewBag.Insdus =  se.IndustyCode();
            ViewBag.JobField= se.JobField();
            ViewBag.JobFieldTy = se.JobFieldTy();
            ViewBag.Location =  se.LocationTh();
            ViewBag.locationPro= se.LocationThPro();
            ViewBag.Disti= se.DisticLocationTh();
            //ViewBag.Distic = se.DisticLocationThPro(pvId);
            return View();
        }

        [HttpPost]
        public JsonResult Home(string locationProvi)
        {
            
            var dis = se.DisticLocationThPro(locationProvi);
            string jsonresult = JsonConvert.SerializeObject(dis);
            return Json(jsonresult);
        }

        [HttpPost]
        public JsonResult changeFie(string jobResultJobTypeId)
        {
            var dis = se.JobFieldF(jobResultJobTypeId);
            string jsonresult = JsonConvert.SerializeObject(dis);
            return Json(jsonresult);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register_EPY()
        {
            return View();
        }

        public IActionResult Register_Result()
        {
            return View();
        }
        public IActionResult Company_Introduction()
        {
            return View();
        }
        public IActionResult Job_Description()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult NewPassword()
        {
           
            return View();
        }




        [HttpPost]
        public JsonResult JobResult(string locationProvi, string jobResultDistrictId, string jobResultJobFieldId, string jobResultIndustryId, string jobResultJobTypeId, string jobResultSalaryMinId, string jobResultSalaryMaxId, string jobResultKeywordsId)  

        {
            ViewBag.Insdus = se.IndustyCode();
            ViewBag.JobField = se.JobField();
            ViewBag.JobFieldTy = se.JobFieldTy();
            ViewBag.Location = se.LocationTh();
            ViewBag.locationPro = se.LocationThPro();
            ViewBag.Disti = se.DisticLocationTh();

            var sql = searchPost( locationProvi,  jobResultDistrictId,  jobResultJobFieldId,  jobResultIndustryId,  jobResultJobTypeId,  jobResultSalaryMinId,  jobResultSalaryMaxId,  jobResultKeywordsId);
            string jsonresult = JsonConvert.SerializeObject(sql);
                return Json(jsonresult);

        }

        public List<CPN_JobPosting> searchPost(string locationProvi, string jobResultDistrictId, string jobResultJobFieldId, string jobResultIndustryId, string jobResultJobTypeId, string jobResultSalaryMinId, string jobResultSalaryMaxId, string jobResultKeywordsId)
        {
            List<CPN_JobPosting> jop = new List<CPN_JobPosting>();

            if (locationProvi == null)
            {
                locationProvi = " ";
            } 
            if (jobResultDistrictId == null)
            {
                jobResultDistrictId = " ";
            } 
            if (jobResultJobFieldId == null)
            {
                jobResultJobFieldId = " ";
            } 
            if (jobResultIndustryId == null)
            {
                jobResultIndustryId = " ";
            } 
            if (jobResultJobTypeId == null)
            {
                jobResultJobTypeId = " ";
            }
          
            if (jobResultSalaryMinId == null)
            {
                jobResultSalaryMinId = "0";
            }
            if (jobResultSalaryMaxId == null)
            {
                jobResultSalaryMaxId = "0";
            }
            if (jobResultSalaryMaxId == "Over 100000")
            {
                jobResultSalaryMaxId = "100000";
            }
           
            var sql = db.CPN_JobPosting.Where(c => c.JobField.ToLower().Contains(jobResultJobFieldId)
            && c.Industry.ToLower().Contains(jobResultIndustryId)
            && c.Province.ToLower().Contains(locationProvi)
            && c.District.ToLower().Contains(jobResultDistrictId)
            && c.SalaryMin >= Convert.ToInt32(jobResultSalaryMinId)
            && c.SalaryMax <= Convert.ToInt32(jobResultSalaryMaxId)
            //&& c.Province.ToLower().Contains(locationProvi)

            ).ToList();
            var sql2 = db.CEN_LocationThailand.GroupBy(p => new { p.ProvinceEN, p.ProvinceID, p.ProvinceTH }).Select(c => c.Key).ToList();
            foreach (var data in sql)
            {
                var sw = sql2.Where(c => c.ProvinceID == data.Province).Select(s => s.ProvinceEN).FirstOrDefault();
                jop.Add(new CPN_JobPosting
                {
                    ID = data.ID,
                    UserID = data.UserID,
                    CompanyName = data.CompanyName,
                    Industry = data.Industry,
                    Oversea = Convert.ToBoolean(data.Oversea),
                    Country = data.Country,
                    Province = sw,
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
                    JobType = data.JobType,
                    JobField = data.JobField,
                    PositionLevel = data.PositionLevel,
                    JobDescription = data.JobDescription,
                    JobExperience = data.JobExperience,
                    EducationDegree = data.EducationDegree,
                    LanguageSkill = data.LanguageSkill,
                    Car = Convert.ToBoolean(data.Car),
                    Motorbike = Convert.ToBoolean(data.Motorbike),
                    Truck = Convert.ToBoolean(data.Truck),
                    Trailer = Convert.ToBoolean(data.Trailer),
                    Forklift = Convert.ToBoolean(data.Forklift),
                    QualificationDetail = data.QualificationDetail,
                    AgeMin = data.AgeMin,
                    AgeMax = data.AgeMax,
                    SalaryMin = data.SalaryMin,
                    SalaryMax = data.SalaryMax,
                    ResumeType = data.ResumeType,
                    JobAdvertise = data.JobAdvertise,
                    ApplyCount = data.ApplyCount,
                    CreateDate = data.CreateDate,
                    UpdateDate = data.UpdateDate,
                    ViewCount = data.ViewCount,
                    FreshGraduated = Convert.ToBoolean(data.FreshGraduated),
                    status = Convert.ToBoolean(data.status)




                });

            }
            return jop;

        }

        public IActionResult JobResult()    
        {
            ViewBag.Insdus = se.IndustyCode();
            ViewBag.JobField = se.JobField();
            ViewBag.JobFieldTy = se.JobFieldTy();
            ViewBag.Location = se.LocationTh();
            ViewBag.locationPro = se.LocationThPro();
            ViewBag.Disti = se.DisticLocationTh();
            Array listPost;

            List<CPN_JobPosting> jop = new List<CPN_JobPosting>();
            List<CEN_LocationThailand> jloc = new List<CEN_LocationThailand>();
            var sql = db.CPN_JobPosting.ToList();
            var sql2 = db.CEN_LocationThailand.GroupBy(p => new { p.ProvinceEN, p.ProvinceID, p.ProvinceTH }).Select(c => c.Key).ToList();
            var sqlf = sql.Join(sql2, c => c.Province, d => d.ProvinceID, (c, d) => new { c, d }).Where(df => df.d.ProvinceID == df.c.Province).ToList();
            foreach (var data in sqlf)
            {
                jop.Add(new CPN_JobPosting {
                    ID = data.c.ID,
                    UserID = data.c.UserID,
                    CompanyName = data.c.CompanyName,
                    Industry = data.c.Industry,
                    Oversea = Convert.ToBoolean(data.c.Oversea),
                    Country = data.c.Country,
                    Province = data.d.ProvinceEN,
                    District = data.c.District,
                    SubDistrict = data.c.SubDistrict,
                    Address = data.c.Address,
                    Website = data.c.Website,
                    Contract = data.c.Contract,
                    Telephone = data.c.Telephone,
                    MobilePhone = data.c.MobilePhone,
                    Email = data.c.Email,
                    CompanyDetail = data.c.CompanyDetail,
                    WelfareBenefit = data.c.WelfareBenefit,
                    JobTitle = data.c.JobTitle,
                    JobType = data.c.JobType,
                    JobField = data.c.JobField,
                    PositionLevel = data.c.PositionLevel,
                    JobDescription = data.c.JobDescription,
                    JobExperience = data.c.JobExperience,
                    EducationDegree = data.c.EducationDegree,
                    LanguageSkill = data.c.LanguageSkill,
                    Car = Convert.ToBoolean(data.c.Car),
                    Motorbike = Convert.ToBoolean(data.c.Motorbike),
                    Truck = Convert.ToBoolean(data.c.Truck),
                    Trailer = Convert.ToBoolean(data.c.Trailer),
                    Forklift = Convert.ToBoolean(data.c.Forklift),
                    QualificationDetail = data.c.QualificationDetail,
                    AgeMin = data.c.AgeMin,
                    AgeMax = data.c.AgeMax,
                    SalaryMin = data.c.SalaryMin,
                    SalaryMax = data.c.SalaryMax,
                    ResumeType = data.c.ResumeType,
                    JobAdvertise = data.c.JobAdvertise,
                    ApplyCount = data.c.ApplyCount,
                    CreateDate = data.c.CreateDate,
                    UpdateDate = data.c.UpdateDate,
                    ViewCount = data.c.ViewCount,
                    FreshGraduated = Convert.ToBoolean(data.c.FreshGraduated),
                    status = Convert.ToBoolean(data.c.status)




                });
                
            }

            listPost = jop.ToArray();

            ViewBag.jobposting = listPost;
            ViewBag.Pocount = listPost.Length;

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public List<CPN_JobPosting> QueryJobPost(string locationProvi, string jobResultDistrictId, string jobResultJobFieldId
        , string jobResultIndustryId, string jobResultJobTypeId, string jobResultSalaryMinId, string jobResultSalaryMaxId, string jobResultKeywordsId)
        {

            Array JobPosting;

            List<CPN_JobPosting> Jobpost = new List<CPN_JobPosting>();

            var sql = db.CPN_JobPosting.Where(c => c.status == false
                 && c.JobField == jobResultJobFieldId

                 ).ToList();

            foreach (var data in sql)
            {
                Jobpost.Add(new CPN_JobPosting
                {
                         ID =data.ID,
                         UserID               = data.UserID,
                         CompanyName          = data.CompanyName ,           
                         Industry             = data.Industry   ,            
                         Oversea              = Convert.ToBoolean(data.Oversea)  ,              
                         Country              = data.Country  ,              
                         Province             = data.Province   ,            
                         District             = data.District    ,  
                         SubDistrict          = data.SubDistrict  ,    
                         Address              = data.Address       ,         
                         Website              = data.Website       ,         
                         Contract             = data.Contract      ,         
                         Telephone            = data.Telephone      ,        
                         MobilePhone          = data.MobilePhone   ,         
                         Email                = data.Email            ,      
                         CompanyDetail        = data.CompanyDetail    ,      
                         WelfareBenefit       = data.WelfareBenefit  ,       
                         JobTitle             = data.JobTitle     ,          
                         JobType              = data.JobType      ,          
                         JobField             = data.JobField      ,         
                         PositionLevel        = data.PositionLevel  ,        
                         JobDescription       = data.JobDescription     ,    
                         JobExperience        = data.JobExperience     ,     
                         EducationDegree      = data.EducationDegree    ,    
                         LanguageSkill        = data.LanguageSkill    ,      
                         Car                  = Convert.ToBoolean(data.Car)            ,       
                         Motorbike            = Convert.ToBoolean(data.Motorbike),       
                         Truck                = Convert.ToBoolean(data.Truck),      
                         Trailer              = Convert.ToBoolean(data.Trailer),       
                         Forklift             = Convert.ToBoolean(data.Forklift),   
                         QualificationDetail  = data.QualificationDetail   , 
                         AgeMin               = data.AgeMin     ,            
                         AgeMax               = data.AgeMax         ,        
                         SalaryMin            = data.SalaryMin       ,       
                         SalaryMax            = data.SalaryMax       ,       
                         ResumeType           = data.ResumeType       ,      
                         JobAdvertise         = data.JobAdvertise   ,
                         ApplyCount = data.ApplyCount,
                         CreateDate = data.CreateDate,
                         UpdateDate =  data.UpdateDate,
                         ViewCount =   data.ViewCount,
                         FreshGraduated = Convert.ToBoolean(data.FreshGraduated),
                         status = Convert.ToBoolean(data.status)


                });
            }

            JobPosting = Jobpost.ToArray();


            return Jobpost;
        }



    }
}
