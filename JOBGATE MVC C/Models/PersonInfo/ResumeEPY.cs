using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE_MVC_C.Models.PersonInfo;

namespace JOBGATE_MVC_C.Models
{
    public class MembersInfoEPY
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
       // public string MobilePhone { get; set; }
        public MarriageStatus MarriageStatus { get; set; }
        public Nationality Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Religion Religion { get; set; }
        public Military Military { get; set; }
        public int MarriageStatusId { get; set; }
        public int NationalityId { get; set; }
        public int ReligionId { get; set; }
        public int MilitaryId { get; set; }
        public string ClientId { get; set; }
        public AppUser Client { get; set; }
       

    //public string Email { get; set; }
    // public string Name { get; set; }



}

    public class ResumeEPY
    {
        [Key]
        public int Id { get; set; }
        public string MemberRegister { get; set; }
        public JobFieldEPY Jobfield { get; set; }
        public Location location { get; set; }
        public JobExpEPY JobExp { get; set; }
        public string Positionlevel { get; set; }
        public EducationEPY Education { get; set; }
        public DrivinglicenseEPY Drivinglicense { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public DateTime Deleted_at { get; set; }
        public bool Show_open { get; set; }



    }
    public class DegreeEPY
    {
        [Key]
        public int Id { get; set; }
        public Degrees Degree { get; set; }
        public string SchoolName { get; set; }
        public StudyCategory StudyCate { get; set; }
        public string MajorSubject { get; set; }
        public int Year { get; set; }
        public float GPAScore { get; set; }
        public int DegreeId { get; set; }
        public int StudyCateId { get; set; }
    }

    public class DrivinglicenseEPY
    {
        [Key]
        public int Id { get; set; }
        public string DrivinglicenseName { get; set; }

    }

    public class EducationEPY
    {
        [Key]
        public int Id { get; set; }
        public DegreeEPY Degree1 { get; set; }
        public DegreeEPY Degree2 { get; set; }
        public DegreeEPY Degree3 { get; set; }

    }

    public class JobExpEPY
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int JobFieldId { get; set; }
        public JobFieldEPY JobField { get; set; }
        public int PositionId { get; set; }
        public PositionlevelEPY Position { get; set; }
        public string WorkingDept { get; set; }
        //public int CompanylocationId { get; set; }
        public Location Companylocation { get; set; }
        public int industryId { get; set; }
        public Industry industry { get; set; }
        public int Salary { get; set; }
        public string Jobduty { get; set; }
        public DateTime Workingstart { get; set; }
        public DateTime Workingend { get; set; }
        public string etcposition { get; set; }
        public bool working_in_overseas { get; set; }

    }

    
    public class LanguagecatEPY
    {
        [Key]
        public int Id { get; set; }
        public string LanguagecatName { get; set; }

    }

    public class PositionlevelEPY
    {
        [Key]
        public int Id { get; set; }
        public string Positonlevelname { get; set; }

    }
    public class VehicleCatEPY
    {
        [Key]
        public int Id { get; set; }
        public string VehicleCatName { get; set; }
    }
    public class Gender 
    { 
        [Key]
        public int Id { get; set; }
        public string GenderName { get; set; }
    
    }

    public class MarriageStatus 
    {
        public int Id { get; set; }
        public string MarriageName { get; set; }
    }

    public class Nationality
    {
        public int Id { get; set; }
        public string NationalityName { get; set; }
    }
    public class Religion
    {
        public int Id { get; set; }
        public string ReligionName { get; set; }
    }

    public class Military
    {
        public int Id { get; set; }
        public string MilitaryName { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public int PID { get; set; }
        public string LocationName { get; set; }
    }

    public class Degrees
    {
        [Key]
        public int Id { get; set; }
        public string DegreeName { get; set; }
    }
    public class StudyCategory
    {
        public int Id { get; set; }
        public string StudyCatName { get; set; }
    }
    public class Industry
    {
        [Key]
        public int Id { get; set; }
        public string IndustryName { get; set; }
    }
}
