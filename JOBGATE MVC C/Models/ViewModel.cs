using Microsoft.AspNetCore.Mvc;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genderld { get; set; }
        public string MobliePhone { get; set; }
        public string Tel { get; set; }
        public int MarriageStatusId { get; set; }
        public int NationalityId { get; set; }
        public bool StayingOver { get; set; }
        public bool SameMobile { get; set; }
        public string CurrentAddress { get; set; }
        public int ProvinceOwnId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ReligionId { get; set; }
        public int MilitaryId { get; set; }
        public int DayB { get; set; }
        public int MonthB { get; set; }
        public int YearsB { get; set; }
        public int DegreeId { get; set; }
        public string SchoolName { get; set; }
        public int StudyCateId { get; set; }
        public string MajorSubject { get; set; }
        public int GradYear { get; set; }
        public float GPAscore { get; set; }
        public int DegreeId2 { get; set; }
        public string SchoolName2 { get; set; }
        public int StudyCateId2 { get; set; }
        public string MajorSubject2 { get; set; }
        public int GradYear2 { get; set; }
        public float GPAscore2 { get; set; }
        public int DegreeId3 { get; set; }
        public string SchoolName3 { get; set; }
        public int StudyCateId3 { get; set; }
        public string MajorSubject3 { get; set; }
        public int GradYear3 { get; set; }
        public float GPAscore3 { get; set; }
        public string CompanyName { get; set; }
        public int industryId { get; set; }
        public int WorkStartYear { get; set; }
        public int WorkEndYear { get; set; }
        public int WorkStartMonth { get; set; }
        public int WorkEndMonth { get; set; }
        public int JobFieldId { get; set; }
        public int ProvinceComId { get; set; }
        public bool StudyNowJE { get; set; }
        public bool StudyNowJE2 { get; set; }
        public bool StudyNowJE3 { get; set; }
        public int PositionId { get; set; }
        public string WorkingDept { get; set; }
        public int Salary { get; set; }
        public string Jobduty { get; set; }
        public bool Working_in_overseas { get; set; }
        public int Language { get; set; }
        public int Level { get; set; }
        public int LanguageEX { get; set; }
        public int Scgrade { get; set; }
        public string Drivinglicense { get; set; }
        public string Own_car { get; set; }
        public string CertName { get; set; }
        public string Issued_byCert { get; set; }
        public string Issued_byTrain { get; set; }
        public string TrainingName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int StartMonth { get; set; }
        public int EndMonth { get; set; }
        public int JobField1 { get; set; }
        public int JobField2 { get; set; }
        public string EmploymentType { get; set; }
        public int ProvinceWorkLocation { get; set; }
        public int ExpectedSalary { get; set; }
        public string Img { get; set; }

    }
   

    public class PostViewModel
    {
        public ResumeEPY ResumeEPY { get; set; }
        public MembersInfoEPY members { get; set; }
        public DegreeEPY DegreeEPY { get; set; }
        public EducationEPY EducationEPY { get; set; }
        public JobExpEPY jobExpEPY { get; set; }
        public VehicleCatEPY VehicleCatEPY { get; set; }
        public DrivinglicenseEPY Drivinglicense { get; set; }
        public ConfirmEmail confirm { get; set; }
        public List<Religion> Religions { get; set; }
        public List<Military> Militaries { get; set; }
        public List<Nationality> Nationalities { get; set; }
        public List<Location> Locations { get; set; }
        public List<MembersInfoEPY> Members { get; set; }
      
    }
    public class AspNetUser
    {

        public string Email { get; set; }
    }
        public class MyPage
    {
        public List<AspNetUser> Members { get; set; }
        public MembersInfoEPY members { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime Birthday { get; set; }
        public Nationality Nationality { get; set; }
        public string ClientId { get; set; }
        //public string Id { get; internal set; }

    }
    

    
}
