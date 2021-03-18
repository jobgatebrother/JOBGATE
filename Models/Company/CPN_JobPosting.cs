using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CPN_JobPosting
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
        public string MobilePhone { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string CompanyDetail { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string WelfareBenefit { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string JobTitle { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string JobType { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string JobField { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PositionLevel { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string JobDescription { get; set; }

        [Column(TypeName = "bit")]
        public bool FreshGraduated { get; set; }

        [Column(TypeName = "int")]
        public int JobExperience { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string EducationDegree { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string LanguageSkill { get; set; }

        [Column(TypeName = "bit")]
        public bool Car { get; set; }

        [Column(TypeName = "bit")]
        public bool Motorbike { get; set; }

        [Column(TypeName = "bit")]
        public bool Truck { get; set; }

        [Column(TypeName = "bit")]
        public bool Trailer { get; set; }

        [Column(TypeName = "bit")]
        public bool Forklift { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string QualificationDetail { get; set; }

        [Column(TypeName = "int")]
        public int AgeMin { get; set; }

        [Column(TypeName = "int")]
        public int AgeMax { get; set; }

        [Column(TypeName = "int")]
        public int SalaryMin { get; set; }

        [Column(TypeName = "int")]
        public int SalaryMax { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string ResumeType { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string JobAdvertise { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }

        [Column(TypeName = "int")]
        public int ApplyCount { get; set; }

        [Column(TypeName = "int")]
        public int ViewCount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }


    }
}
