using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models.Employee
{
    public class EPY_ViewData
    {
        public class Resume
        {
            //Employee_EPY
            [Required]
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
            public string NationalityId { get; set; }
            public bool StayingOver { get; set; }
            public bool SameMobile { get; set; }
           
            public string Address { get; set; }
           
            public string ProvinceID { get; set; }
            public string DistrictID { get; set; }
            public string SubDistrictID { get; set; }
            public decimal Height { get; set; }
            public decimal Weight { get; set; }
            [Required]
            public string ReligionId { get; set; }
            [Required]
            public string MilitaryId { get; set; }
            [Required]
            //Birthday
            public int DayB { get; set; }
            [Required]
            public int MonthB { get; set; }
            [Required]
            public int YearsB { get; set; }

            ////////////////////////////////////

            //Education
            public string DegreeId1 { get; set; }
            public string SchoolName1 { get; set; }
            public string StudyCateId1 { get; set; }
            public string MajorSubject1 { get; set; }
            public int GraduatationYear1 { get; set; }
            public decimal GPA1 { get; set; }
            public string DegreeId2 { get; set; }
            public string SchoolName2 { get; set; }
            public string StudyCateId2 { get; set; }
            public string MajorSubject2 { get; set; }
            public int GraduatationYear2 { get; set; }
            public decimal GPA2 { get; set; }
            public string DegreeId3 { get; set; }
            public string SchoolName3 { get; set; }
            public string StudyCateId3 { get; set; }
            public string MajorSubject3 { get; set; }
            public int GraduatationYear3 { get; set; }
            public decimal GPA3 { get; set; }
            public bool StudyNowJE1 { get; set; }
            public bool StudyNowJE2 { get; set; }
            public bool StudyNowJE3 { get; set; }


            //JobExp
            public string CompanyName1 { get; set; }
            public string industryId1 { get; set; }
            public DateTime WorkStart1 { get; set; }
            public DateTime WorkEnd1 { get; set; }

            public string CompanyName2 { get; set; }
            public string industryId2 { get; set; }
            public DateTime WorkStart2 { get; set; }
            public DateTime WorkEnd2 { get; set; }

            public string CompanyName3 { get; set; }
            public string industryId3 { get; set; }
            public DateTime WorkStart3 { get; set; }
            public DateTime WorkEnd3 { get; set; }
            public string JobFieldId1 { get; set; }
            public string JobFieldId2 { get; set; }
            public string JobFieldId3 { get; set; }

            public string WorkProvinceID1 { get; set; }
            public string WorkProvinceID2 { get; set; }
            public string WorkProvinceID3 { get; set; }
            public string WorkDistrictID1 { get; set; }
            public string WorkDistrictID2 { get; set; }
            public string WorkDistrictID3 { get; set; }
            public string WorkSubDistrictID1 { get; set; }
            public string WorkSubDistrictID2 { get; set; }
            public string WorkSubDistrictID3 { get; set; }

            public string PositionId1 { get; set; }
            public string Status_Working1 { get; set; }
            public string WorkingDept1 { get; set; }
            public int Salary1 { get; set; }
            public string Jobduty1 { get; set; }
            public bool Work_in_over1 { get; set; }
            public string Workoverseas1 { get; set; }

            public string PositionId2 { get; set; }
            public string Status_Working2 { get; set; }
            public string WorkingDept2 { get; set; }
            public int Salary2 { get; set; }
            public string Jobduty2 { get; set; }
            public bool Work_in_over2 { get; set; }
            public string Workoverseas2 { get; set; }

            public string PositionId3 { get; set; }
            public string Status_Working3 { get; set; }
            public string WorkingDept3 { get; set; }
            public int Salary3 { get; set; }
            public string Jobduty3 { get; set; }
            public bool Work_in_over3 { get; set; }
            public string Workoverseas3 { get; set; }


            //SkillTraning
            public string Language1 { get; set; }
             public string Level1 { get; set; }

            public string Language2 { get; set; }
            public string Level2 { get; set; }

            public string Language3 { get; set; }
             public string Level3 { get; set; }

            public bool Drivinglicense1 { get; set; }
            public bool Drivinglicense2 { get; set; }
            public bool Drivinglicense3 { get; set; }
            public bool Drivinglicense4 { get; set; }
            public bool Drivinglicense5 { get; set; }
            public bool Own_car1 { get; set; }
            public bool Own_car2 { get; set; }
            public bool Own_car3 { get; set; }
            public DateTime DateStartTraining { get; set; }
            public DateTime DateEndTraining { get; set; }

            //Certificate
            public string CertCategoryId1 { get; set; }
            public string CertCategoryId2 { get; set; }
            public string CertCategoryId3 { get; set; }
            public string TitleName1 { get; set; }
            public string TitleName2 { get; set; }
            public string TitleName3 { get; set; }
            public string Issued_byCert1 { get; set; }
            public string Issued_byCert2 { get; set; }
            public string Issued_byCert3 { get; set; }
            public string Issued_bytrain1 { get; set; }
            public string Issued_bytrain2 { get; set; }
            public string Issued_bytrain3 { get; set; }
            public string TrainingName1 { get; set; }
            public string TrainingName2 { get; set; }
            public string TrainingName3 { get; set; }

            public DateTime DateStartTraining1 { get; set; }
            public DateTime DateStartTraining2 { get; set; }
            public DateTime DateStartTraining3 { get; set; }
            public DateTime DateEndTraining1 { get; set; }
            public DateTime DateEndTraining2 { get; set; }
            public DateTime DateEndTraining3 { get; set; }

            //Required Job
            [Required]
            public string JobField1 { get; set; }
            public string JobField2 { get; set; }
            public bool EmploymentType1 { get; set; }
            public bool EmploymentType2 { get; set; }
            public bool EmploymentType3 { get; set; }
            public bool EmploymentType4 { get; set; }
            [Required]
            public string ProvinceWorkLocation { get; set; }
            public int ExpectedSalary { get; set; }
            public string Img { get; set; }
            //public int Degree1Id { get; set; }
            //public int Degree2Id { get; set; }
            //public int Degree3Id { get; set; }
            public int CertCategoryId { get; set; }
            public string Image { get; set; }
            // public int CategoryId { get; set; }
            public IFormFile ImageName { get; set; }
            public DateTime Created_at { get; set; }
            public string ResumeName { get; set; }
            public string ClientId { get; set; }

            // public List<ResumeEPY> ResumeEPY { get; set; }
            //public IEnumerable<MembersInfoEPY> members { get; set; }
        }

        public class ViewResume
        {
            public int ID { get; set; }
            public string ResumeName { get; set; }
            public string ExpectedSalary { get; set; }
            public string JobField { get; set; }
            public string JobField2 { get; set; }
            public string Worklocation { get; set; }
            public bool status { get; set; }
           
        }
        public class ViewPerson
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public DateTime BirthDay { get; set; }
            public string MobilePhone { get; set; }
            public string Tel { get; set; }
            public string MarriageStatus { get; set; }
            public string Nationality { get; set; }
            public string Address { get; set; }
            public decimal Height { get; set; }
            public decimal Weight { get; set; }
             public string img { get; set; }

        }
        public class changstatus
        {
            public int ID { get; set; }
            public bool status { get; set; }
         

        }

    }
   
}
