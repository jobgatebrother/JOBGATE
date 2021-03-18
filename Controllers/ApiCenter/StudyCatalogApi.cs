using JOBGATE.Data;
using JOBGATE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Controllers.ApiCenter
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyCatalogApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getStuCatalog()
        {
            Array StuCatalog;
            StuCatalog = dbq.StudyCatalog();
            var ad = JsonConvert.SerializeObject(StuCatalog).ToString();
            return ad;
        }

        [HttpGet("{StudyCatID}", Name = "getStuCatalog")]
        public string getStuCatalog(string StudyCatID)
        {
            Array StuCatalog;
            List<CEN_StudyCategory> Stucat = new List<CEN_StudyCategory>();

            var sql = db.CEN_StudyCategory.Where(stc => stc.StudyCatID.ToLower() == StudyCatID).ToList();

            foreach (var data in sql)
            {
                Stucat.Add(new CEN_StudyCategory
                {

                    ID = data.ID,
                    StudyCatID = data.StudyCatID,
                    StudyCatEN = data.StudyCatEN,
                    StudyCatTH = data.StudyCatTH

                });
            }

            StuCatalog = Stucat.ToArray();
            

            var ad = JsonConvert.SerializeObject(StuCatalog).ToString();

            return ad;
        }

    }
}
