using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models.PersonInfo
{
    public class CertificateEPY
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string CertName { get; set; }
        public string Issued_by { get; set; }
        
    }
}
