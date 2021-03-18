using JOBGATE.Data;
using JOBGATE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Controllers
{
    public class SearchEn : Controller
    {
        public JOBGATEData_Context db = new JOBGATEData_Context();
        public IActionResult Index()
        {
            return View();
        }

        public Array IndustyCode()
        {

            Array Indus;
            List<IndustryCodeList> insCode = new List<IndustryCodeList>();
            var sql = db.CEN_IndustryCodeList.ToList();


            foreach (var data in sql)
            {
                insCode.Add(new IndustryCodeList
                {
                    ID = data.ID,
                    Code = data.Code,
                    IndustryNameEN = data.IndustryNameEN,
                    IndustryNameTH = data.IndustryNameTH
                });
            }

            Indus = insCode.ToArray();
           return Indus;

        }
        public Array JobField()
        {
            Array JobFieldArr;
            List<CEN_JobField> jobfield = new List<CEN_JobField>();

            var sql = db.CEN_JobField.ToList();

            foreach (var data in sql)
            {

                jobfield.Add(new CEN_JobField
                {

                    ID = data.ID,
                    JobFieldID = data.JobFieldID,
                    JobFieldTH = data.JobFieldTH,
                    JobFieldEN = data.JobFieldEN,
                    JobCategoryID = data.JobCategoryID,
                    JobCategoryTH = data.JobCategoryTH,
                    JobCategoryEN = data.JobCategoryEN
                });
            }

            JobFieldArr = jobfield.ToArray();

            return JobFieldArr;

        }  
        public Array JobFieldF(string jobResultJobTypeId)
        {
            Array JobFieldArr;
            List<CEN_JobField> jobfield = new List<CEN_JobField>();

            var sql = db.CEN_JobField.Where(d => d.JobCategoryID == jobResultJobTypeId).GroupBy(de => new { de.JobFieldEN, de.JobFieldID }).Select(c => c.Key).ToList();

            foreach (var data in sql)
            {

                jobfield.Add(new CEN_JobField
                {

                   
                    JobFieldID = data.JobFieldID,
                    
                    JobFieldEN = data.JobFieldEN,
                  
                });
            }

            JobFieldArr = jobfield.ToArray();

            return JobFieldArr;

        } 
        public Array JobFieldTy()
        {
            Array JobFieldArr;
            List<CEN_JobField> jobfield = new List<CEN_JobField>();

            var sql = db.CEN_JobField.GroupBy(de => new { de.JobCategoryEN, de.JobCategoryID }).Select(c => c.Key).ToList();

            foreach (var data in sql)
            {

                jobfield.Add(new CEN_JobField
                {

                   
                    JobCategoryID = data.JobCategoryID,
                    
                    JobCategoryEN = data.JobCategoryEN
                  
                });
            }

            JobFieldArr = jobfield.ToArray();

            return JobFieldArr;

        }
        public Array LocationTh()
        {
            Array LocationArr;
            List<CEN_LocationThailand> location = new List<CEN_LocationThailand>();

            var sql = db.CEN_LocationThailand.ToList();

            foreach (var data in sql)
            {
                location.Add(new CEN_LocationThailand
                {

                    ID = data.ID,
                    SubDistrictID = data.SubDistrictID,
                    SubDistrictTH = data.SubDistrictTH,
                    SubDistrictEN = data.SubDistrictEN,
                    Postcode = data.Postcode,
                    DistrictID = data.DistrictID,
                    DistrictTH = data.DistrictTH,
                    DistrictEN = data.DistrictEN,
                    ProvinceID = data.ProvinceID,
                    ProvinceTH = data.ProvinceTH,
                    ProvinceEN = data.ProvinceEN,
                    RegionTH = data.RegionTH,
                    RegionEN = data.RegionEN

                });

            }

            LocationArr = location.ToArray();



           return LocationArr;

        }
        public Array LocationThPro()
        {
            Array locationPro;
            List<CEN_LocationThailand> location = new List<CEN_LocationThailand>();

            var sql = db.CEN_LocationThailand.GroupBy(p => new { p.ProvinceEN, p.ProvinceID, p.ProvinceTH }).Select(c => c.Key).ToList();



            foreach (var data in sql)
            {
                location.Add(new CEN_LocationThailand
                {
                    ProvinceID = data.ProvinceID,
                    ProvinceEN = data.ProvinceEN

                });

            }

            locationPro = location.ToArray();
            return locationPro;
        }
        public Array DisticLocationTh()
        {
            Array DislocationPro;
            List<CEN_LocationThailand> location = new List<CEN_LocationThailand>();

            var sql = db.CEN_LocationThailand.GroupBy(de => new { de.DistrictEN, de.DistrictID }).Select(c => c.Key).ToList();



            foreach (var data in sql)
            {
                location.Add(new CEN_LocationThailand
                {

                    DistrictID = data.DistrictID,
                    DistrictEN = data.DistrictEN

                });

            }

            DislocationPro = location.ToArray();
            return DislocationPro;
        }

        public Array DisticLocationThPro(string locationProvi)
        {
            Array DislocationPro;
            List<CEN_LocationThailand> location = new List<CEN_LocationThailand>();

            var sql = db.CEN_LocationThailand.Where(d => d.ProvinceID == locationProvi).GroupBy(de => new { de.DistrictEN,de.DistrictID}).Select(c => c.Key).ToList();



            foreach (var data in sql)
            {
                location.Add(new CEN_LocationThailand
                {

                    DistrictID = data.DistrictID,
                    DistrictEN = data.DistrictEN

                });

            }

            DislocationPro = location.ToArray();
            return DislocationPro;
        }

        public Array CoutryNation()
        {
            Array CouTryArr;
            List<CEN_Nationality> nation = new List<CEN_Nationality>();

            var sql = db.CEN_Nationality.ToList();

            foreach (var data in sql)
            {
                nation.Add(new CEN_Nationality
                {

                    ID = data.ID,
                    CountryID = data.CountryID,
                    CountryTH = data.CountryTH,
                    CountryEN = data.CountryEN,
                    ContientID = data.ContientID,
                    ContinentTH = data.ContinentTH,
                    ContinentEN = data.ContinentEN

                });
            }

            CouTryArr = nation.ToArray();

            return CouTryArr;
        }


        public Array PositionLevel()
        {
            Array Position;
            List<CEN_Positionlevel> PositionLevel = new List<CEN_Positionlevel>();

            var sql = db.CEN_Positionlevel.ToList();
            foreach(var data in sql)
            {
                PositionLevel.Add(new CEN_Positionlevel { 
                
                ID = data.ID,
                PositionlevelID =data.PositionlevelID,
                PositionlevelEN = data.PositionlevelEN,
                PositionlevelTH = data.PositionlevelTH
                
                
                });
            }

            Position = PositionLevel.ToArray();

            return Position;
        }


        public Array StudyCatalog()
        {
            Array StuCatalog;
            List<CEN_StudyCategory> Stucat = new List<CEN_StudyCategory>();

            var sql = db.CEN_StudyCategory.ToList();

            foreach(var data in sql)
            {
                Stucat.Add(new CEN_StudyCategory { 
                
                ID = data.ID,
                StudyCatID =data.StudyCatID,
                StudyCatEN =  data.StudyCatEN,
                StudyCatTH = data.StudyCatTH
                
                });
            }

            StuCatalog = Stucat.ToArray();
            return StuCatalog;
        }

        public Array ForeignLanguage()
        {
            Array Foreign;
            List<CEN_ForeignLanguage> foreLang = new List<CEN_ForeignLanguage>();

            var sql = db.CEN_ForeignLanguage.ToList();
            foreach(var data in sql)
            {
                foreLang.Add(new CEN_ForeignLanguage {
                
                    ID = data.ID,
                    LanguagelevelID = data.LanguagelevelID,
                    LanguagelevelEN =data.LanguagelevelEN,
                    LanguagelevelTH =data.LanguagelevelTH,
                    ForeignLanguageID =data.ForeignLanguageID,
                    ForeignLanguageEN = data.ForeignLanguageEN,
                    ForeignLanguageTH =data.ForeignLanguageTH
                
                });
            }
            Foreign = foreLang.ToArray();

            return Foreign;
        }

        public Array CertificateCatalog()
        {
            Array Certificate;

            List<CEN_CertificateCategory> certificateCat = new List<CEN_CertificateCategory>();

            var sql = db.CEN_CertificateCategory.ToList();

            foreach(var data in sql)
            {
                certificateCat.Add(new CEN_CertificateCategory { 
                
                    ID = data.ID,
                    CertificateID = data.CertificateID,
                    CertificateEN = data.CertificateEN,
                    CertificateTH = data.CertificateTH
                
                });
            }

            Certificate = certificateCat.ToArray();

            return Certificate;
        }

        public Array Degrees()
        {
            Array DegreesAr;
            List<CEN_Degrees> DegreesL = new List<CEN_Degrees>();

            var sql = db.CEN_Degrees.ToList();
            foreach(var data in sql)
            {
                DegreesL.Add(new CEN_Degrees { 
                
                ID = data.ID,
                DegreeID = data.DegreeID,
                DegreeEN = data.DegreeEN,
                DegreeTH = data.DegreeTH
                
                
                });
            }
            DegreesAr = DegreesL.ToArray();

            return DegreesAr;
        }



    }
}
