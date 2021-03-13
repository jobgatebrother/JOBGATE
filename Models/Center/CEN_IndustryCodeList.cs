using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CEN_IndustryCodeList
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string IndustryNameTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string IndustryNameEN { get; set; }
    }
}
