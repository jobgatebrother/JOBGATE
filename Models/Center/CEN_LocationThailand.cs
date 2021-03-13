using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CEN_LocationThailand
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SubDistrictID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string SubDistrictTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string SubDistrictEN { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Postcode { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string DistrictID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string DistrictTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string DistrictEN { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string ProvinceID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ProvinceTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ProvinceEN { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string RegionTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string RegionEN { get; set; }

    }
}
