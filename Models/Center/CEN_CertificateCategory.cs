using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CEN_CertificateCategory
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string CertificateID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string CertificateTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string CertificateEN { get; set; }
    }
}
