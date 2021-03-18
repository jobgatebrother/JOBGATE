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
    public class DegreesApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getDegreesAr()
        {
            Array DegreesAr;
            DegreesAr = dbq.Degrees();
            var ad = JsonConvert.SerializeObject(DegreesAr).ToString();
            return ad;
        }

        [HttpGet("{DegreeID}", Name = "getDegreesAr")]
        public string getDegreesAr(string DegreeID)
        {
            Array DegreesAr;
            List<CEN_Degrees> DegreesL = new List<CEN_Degrees>();

            var sql = db.CEN_Degrees.Where(dr => dr.DegreeID.ToLower() == DegreeID).ToList();
            foreach (var data in sql)
            {
                DegreesL.Add(new CEN_Degrees
                {

                    ID = data.ID,
                    DegreeID = data.DegreeID,
                    DegreeEN = data.DegreeEN,
                    DegreeTH = data.DegreeTH


                });
            }
            DegreesAr = DegreesL.ToArray();

            string ad = JsonConvert.SerializeObject(DegreesAr).ToString();

            return ad;
        }

    }
}
