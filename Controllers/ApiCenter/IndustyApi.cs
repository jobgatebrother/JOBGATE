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
    public class IndustyApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getIndusty()
        {
            Array Indus;
            Indus = dbq.IndustyCode();
            var ad = JsonConvert.SerializeObject(Indus).ToString();
            return ad;
        }

        [HttpGet("{Code}", Name = "getIndusty")]
        public string getIndusty(string Code)
        {
            Array Indus;
            List<IndustryCodeList> insCode = new List<IndustryCodeList>();
            var sql = db.CEN_IndustryCodeList.Where(indus => indus.Code.ToLower() == Code).ToList();


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

            var ad = JsonConvert.SerializeObject(Indus).ToString();

            return ad;
        }

    }
}
