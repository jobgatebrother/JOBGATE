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
    public class NationalityApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getNationality()
        {
            Array CouTryArr;
            CouTryArr = dbq.CoutryNation();
            var ad = JsonConvert.SerializeObject(CouTryArr).ToString();
            return ad;
        }

        [HttpGet("{CountryID}", Name = "getNationality")]
        public string getNationality(string CountryID)
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
            var ad = JsonConvert.SerializeObject(CouTryArr).ToString();

            return ad;
        }

    }
}
