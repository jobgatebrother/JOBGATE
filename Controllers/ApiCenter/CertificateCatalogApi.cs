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
    public class CertificateCatalogApi : ControllerBase
    {

        public SearchEn dbq = new SearchEn();
        public JOBGATEData_Context db = new JOBGATEData_Context();

        [HttpGet]
        public string getCertificate()
        {
            Array Certificate;
            Certificate = dbq.CertificateCatalog();
            var ad = JsonConvert.SerializeObject(Certificate).ToString();
            return ad;
        }

        [HttpGet("{CertificateID}", Name = "getCertificate")]
        public string getCertificate(string CertificateID)
        {
            Array Certificate;

            List<CEN_CertificateCategory> certificateCat = new List<CEN_CertificateCategory>();

            var sql = db.CEN_CertificateCategory.Where(cc => cc.CertificateID.ToLower() == CertificateID).ToList();

            foreach (var data in sql)
            {
                certificateCat.Add(new CEN_CertificateCategory
                {

                    ID = data.ID,
                    CertificateID = data.CertificateID,
                    CertificateEN = data.CertificateEN,
                    CertificateTH = data.CertificateTH

                });
            }

            Certificate = certificateCat.ToArray();

            var ad = JsonConvert.SerializeObject(Certificate).ToString();

            return ad;
        }

    }
}
