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
    public class PositionlevelApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getPositionLevel()
        {
            Array Position;
            Position = dbq.PositionLevel();
            var ad = JsonConvert.SerializeObject(Position).ToString();
            return ad;
        }

        [HttpGet("{PositionlevelID}", Name = "getPositionLevel")]
        public string getPositionLevel(string PositionlevelID)
        {
            Array Position;
            List<CEN_Positionlevel> PositionLevel = new List<CEN_Positionlevel>();

            var sql = db.CEN_Positionlevel.Where(po => po.PositionlevelID.ToLower() == PositionlevelID).ToList();
            foreach (var data in sql)
            {
                PositionLevel.Add(new CEN_Positionlevel
                {

                    ID = data.ID,
                    PositionlevelID = data.PositionlevelID,
                    PositionlevelEN = data.PositionlevelEN,
                    PositionlevelTH = data.PositionlevelTH


                });
            }

            Position = PositionLevel.ToArray();

            var ad = JsonConvert.SerializeObject(Position).ToString();

            return ad;
        }

    }
}
