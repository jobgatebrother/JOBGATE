using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CEN_MarriageStatus
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string MarriageID { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string MarriageNameTH { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string MarriageNameEN { get; set; }
    }
}
