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
    public class JobFieldApi : ControllerBase
    {
        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getJobfield()
        {
            Array JobFieldArr;
            JobFieldArr = dbq.JobField();
            var ad = JsonConvert.SerializeObject(JobFieldArr).ToString();
            return ad;
        }

        [HttpGet("{JobFieldID}", Name = "getJobfield")]
        public string getJobfield(string JobFieldID)
        {
            Array JobFieldArr;
            List<CEN_JobField> jobfield = new List<CEN_JobField>();

            var sql = db.CEN_JobField.Where(jf => jf.JobFieldID.ToLower() == JobFieldID ).ToList();

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

            var ad = JsonConvert.SerializeObject(JobFieldArr).ToString();

            return ad;
        }

    }
}
