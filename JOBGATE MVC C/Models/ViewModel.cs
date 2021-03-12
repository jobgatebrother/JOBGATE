using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models
{
    public class ViewModel
    {
        public Register_EPYModel register_EPYModel { get; set; }
        public Register_CPNModel register_CPNModel { get; set; }
    }
    public class EPYViewModel
    {
        public Register_EPYModel register_EPYModel { get; set; }
        public List<Register_EPYModel> EPY { get; set; }
    }
    public class ECPNViewModel
    {
        public Register_CPNModel register_CPNModel { get; set; }
        public List<Register_CPNModel> CPN { get; set; }
    }

    public class Resume
    {
        //public List<Religion> Religions { get; set; }
        //public List<Military> Militaries { get; set; }
        //public List<Nationality> Nationalities { get; set; }
        //public List<Location> Locations { get; set; }
        //public List<MembersInfoEPY> Members { get; set; }
        [Required(ErrorMessage = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string GenderId { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        public string Tel { get; set; }
        [Required]
        public string MarriageStatusId { get; set; }
        [Required]
        public int NationalityId { get; set; }
        public bool StayingOver { get; set; }
        public bool SameMobile { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        [Required]
        public int ProvinceOwnId { get; set; }
        public string Province_ID { get; set; } 
        public string District_ID { get; set; }
        //[Required]
        public int Height { get; set; }
       // [Required]
        public int Weight { get; set; }
        [Required]
        public string ReligionId { get; set; }
        [Required]
        public string MilitaryId { get; set; }
        [Required]
        public int DayB { get; set; }
        [Required]
        public int MonthB { get; set; }
        [Required]
        public int YearsB { get; set; }
        //public string Id { get; set; }
        public string ClientId { get; set; }
        public string DegreeId { get; set; }
        public string SchoolName { get; set; }
        public string StudyCateId { get; set; }
        public string MajorSubject { get; set; }
        public int GradYear { get; set; }
        public float GPAscore { get; set; }
        public string DegreeId2 { get; set; }
        public string SchoolName2 { get; set; }
        public string StudyCateId2 { get; set; }
        public string MajorSubject2 { get; set; }
        public int GradYear2 { get; set; }
        public float GPAscore2 { get; set; }
        public string DegreeId3 { get; set; }
        public string SchoolName3 { get; set; }
        public string StudyCateId3 { get; set; }
        public string MajorSubject3 { get; set; }
        public int GradYear3 { get; set; }
        public float GPAscore3 { get; set; }
        public string CompanyName { get; set; }
        public string industryId { get; set; }
        public int WorkStartYear { get; set; }
        public int WorkEndYear { get; set; }
        public int WorkStartMonth { get; set; }
        public int WorkEndMonth { get; set; }
        public string JobFieldId { get; set; }
        public int ProvinceComId { get; set; }
        public bool StudyNowJE { get; set; }
        public bool StudyNowJE2 { get; set; }
        public bool StudyNowJE3 { get; set; }
        public string PositionId { get; set; }
        public string etcposition { get; set; }
        public int Status_Working { get; set; }
        public string WorkingDept { get; set; }
        public int Salary { get; set; }
        public string Jobduty { get; set; }
        public bool Working_in_overseas { get; set; }
        public string Language { get; set; }
        public string Level { get; set; }
       
       
        public string Language2 { get; set; }
        public string Level2 { get; set; }
        
       
        public string Language3 { get; set; }
        public string Level3 { get; set; }
      
        public string Scgrade3 { get; set; }
        public string Drivinglicense1 { get; set; }
        public string Drivinglicense2 { get; set; }
        public string Drivinglicense3 { get; set; }
        public string Drivinglicense4 { get; set; }
        public string Drivinglicense5 { get; set; }
        public string Own_car1 { get; set; }
        public string Own_car2 { get; set; }
        public string Own_car3 { get; set; }
        public string CertName { get; set; }
        public string Issued_byCert { get; set; }
        public string Issued_byTrain { get; set; }
        public string TrainingName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }
        public int JobfieldId { get; set; }
        [Required]
        public string JobField1 { get; set; }
        public string JobField2 { get; set; }
        public string EmploymentType1 { get; set; }
        public string EmploymentType2 { get; set; }
        public string EmploymentType3 { get; set; }
        public string EmploymentType4 { get; set; }
        [Required]
        public int ProvinceWorkLocation { get; set; }
        public int ExpectedSalary { get; set; }
        public string Img { get; set; }
        public int Degree1Id { get; set; }
        public int Degree2Id { get; set; }
        public int Degree3Id { get; set; }
        public string CategoryId { get; set; }
        public IFormFile ImageName { get; set; }
        public DateTime Created_at { get; set; }
        public string ResumeName { get; set; }

        // public List<ResumeEPY> ResumeEPY { get; set; }
        //public IEnumerable<MembersInfoEPY> members { get; set; }
    }
   

    public class PostViewModel
    {
       
       public string ResumeName { get; set; }
       public string Jobfield { get; set; }
       public int ExpectedSalary { get; set; }
       public string Location { get; set; }
        public string Jobfield2 { get; set; }
        public ResumeEPY Resume { get; set; }
        public JobFieldEPY JobField { get; set; }
        public Location location { get; set; }
        public string Status { get; set;}
        public bool Show_open { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Img { get; set; }
        public DateTime Updatetime { get; set; }
        public string Genders { get; set; }
        public int birthday { get; set; }
        public string job { get; set; }
        public string locationSearch { get; set; }
        public string education { get; set; }
        public string searchString { get; set; }
    }
    public class AspNetUser
    {

        public string Email { get; set; }
    }
        public class MyPage 
    {
        public List<AspNetUser> Members { get; set; }
       // public MembersInfoEPY members { get; set; }
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime Birthday { get; set; }
      //  public Nationality Nationality { get; set; }
        public string ClientId { get; set; }
        //public string Id { get; internal set; }
     
      
    }
    public class SearchJob 
    {
        public string job { get; set; }
        public string location { get; set; }
        public string education { get; set; }

    
    
    }
    


}
