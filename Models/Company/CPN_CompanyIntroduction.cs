using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CPN_CompanyIntroduction
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string UserID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Industry { get; set; }

        [Column(TypeName = "bit")]
        public bool Oversea { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Province { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string District { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SubDistrict { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Website { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Contract { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Telephone { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string InternalPhone { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string CompanyDetail { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string WelfareBenefit { get; set; }
    }
}
