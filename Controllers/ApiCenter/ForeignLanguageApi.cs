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
    public class ForeignLanguageApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getForeign()
        {
            Array Foreign;
            Foreign = dbq.ForeignLanguage();
            var ad = JsonConvert.SerializeObject(Foreign).ToString();
            return ad;
        }

        [HttpGet("{LanguagelevelID}", Name = "getForeign")]
        public string getForeign(string LanguagelevelID)
        {
            Array Foreign;
            List<CEN_ForeignLanguage> foreLang = new List<CEN_ForeignLanguage>();

            var sql = db.CEN_ForeignLanguage.Where(fl => fl.LanguagelevelID.ToLower() == LanguagelevelID).ToList();
            foreach (var data in sql)
            {
                foreLang.Add(new CEN_ForeignLanguage
                {

                    ID = data.ID,
                    LanguagelevelID = data.LanguagelevelID,
                    LanguagelevelEN = data.LanguagelevelEN,
                    LanguagelevelTH = data.LanguagelevelTH,
                    ForeignLanguageID = data.ForeignLanguageID,
                    ForeignLanguageEN = data.ForeignLanguageEN,
                    ForeignLanguageTH = data.ForeignLanguageTH

                });
            }
            Foreign = foreLang.ToArray();

            var ad = JsonConvert.SerializeObject(Foreign).ToString();

            return ad;
        }

    }
}
