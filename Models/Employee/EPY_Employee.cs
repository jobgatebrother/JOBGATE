using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JOBGATE.Models

{
    public partial class EPY_Employee
    {  
        public int ID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string UserID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string MobilePhone { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Tel { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Nationality { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string MarriageStatus { get; set; }

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

        [Column(TypeName = "varchar(max)")]
        public string Address { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Height { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ImgPath { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Religion { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Military { get; set; }       
    }
 
}
