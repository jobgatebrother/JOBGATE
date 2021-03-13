using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CEN_Nationality
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string CountryID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string CountryTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string CountryEN { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string ContientID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ContinentTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ContinentEN { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string NationalityID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string NationalityTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string NationalityEN { get; set; }
    }
}
