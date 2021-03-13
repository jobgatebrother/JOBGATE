using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class EPY_SkillTraning
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Language1 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string LevelLanguage1 { get; set; }
        
        [Column(TypeName = "varchar(10)")]
        public string Language2 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string LevelLanguage2 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Language3 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string LevelLanguage3 { get; set; }

        [Column(TypeName = "bit")]
        public bool DrivingLicenseCar { get; set; }

        [Column(TypeName = "bit")]
        public bool DrivingLicenseMotorbike { get; set; }

        [Column(TypeName = "bit")]
        public bool DrivingLicenseTruck { get; set; }

        [Column(TypeName = "bit")]
        public bool DrivingLicenseTrailer { get; set; }

        [Column(TypeName = "bit")]
        public bool DrivingLicenseForklift { get; set; }

        [Column(TypeName = "bit")]
        public bool OwrCarForkCar { get; set; }

        [Column(TypeName = "bit")]
        public bool OwrCarForkMotorbike { get; set; }

        [Column(TypeName = "bit")]
        public bool OwrCarForkTruck { get; set; }


    }
}
