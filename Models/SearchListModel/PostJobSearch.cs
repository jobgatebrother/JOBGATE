using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models.SearchListModel
{
    public class PostJobSearch
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public bool Oversea { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Contract { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string CompanyDetail { get; set; }
        public string WelfareBenefit { get; set; }
        public string JobTitle { get; set; }
        public string JobType { get; set; }
        public string JobField { get; set; }
        public string PositionLevel { get; set; }
        public string JobDescription { get; set; }
        public int JobExperience { get; set; }
        public string EducationDegree { get; set; }
        public string LanguageSkill { get; set; }
        public bool Car { get; set; }
        public bool Motorbike { get; set; }
        public bool Truck { get; set; }
        public bool Trailer { get; set; }
        public bool Forklift { get; set; }
        public string QualificationDetail { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public int ResumeType { get; set; }
        public int JobAdvertise { get; set; }
        public int ApplyCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int ViewCount { get; set; }
        public bool FreshGraduated { get; set; }
        public bool status { get; set; }
  


    }
}
