using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE.Models;
using JOBGATE.Data;
using Newtonsoft.Json;

namespace JOBGATE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationApi : ControllerBase
    {
        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getProvi()
        {
            Array locationPro;
            locationPro = dbq.LocationThPro();
            var ad = JsonConvert.SerializeObject(locationPro).ToString();
            return ad;
        }

        [HttpGet("{ProvinceID}", Name = "getProvi")]
        public string getProvi(string ProvinceID)
        {
            Array locationPro;
            List<CEN_LocationThailand> location = new List<CEN_LocationThailand>();

            var sql = db.CEN_LocationThailand.GroupBy(p => new { p.ProvinceEN, p.ProvinceID, p.ProvinceTH }).Select(c => c.Key)
                .Where(r => r.ProvinceID.ToLower() == ProvinceID)
                .ToList();

            foreach (var data in sql)
            {
                location.Add(new CEN_LocationThailand
                {
                    ProvinceID = data.ProvinceID,
                    ProvinceEN = data.ProvinceEN,
                    ProvinceTH = data.ProvinceTH

                });

            }

            locationPro = location.ToArray();

            var ad = JsonConvert.SerializeObject(locationPro).ToString();

            return ad;
        }


    }
}
