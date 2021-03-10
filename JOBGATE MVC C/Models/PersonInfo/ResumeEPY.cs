using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE_MVC_C.Models.PersonInfo;
using Microsoft.AspNetCore.Http;

namespace JOBGATE_MVC_C.Models
{
    public partial class MembersInfoEPY
    {
        //public MembersInfoEPY()
        //{
        //    ResumeEPY = new HashSet<ResumeEPY>();
        //}
        [Key, ForeignKey("Client")]
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string MobilePhone { get; set; }
        public MarriageStatus MarriageStatus { get; set; }
        public Nationality Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Religion Religion { get; set; }
        public Military Military { get; set; }
        public string GenderId { get; set; }
        public string MarriageStatusId { get; set; }
        public int NationalityId { get; set; }
        public string ReligionId { get; set; }
        public string MilitaryId { get; set; }
        public int LocationId { get; set; }
        //public string ClientId { get; set; }
        public AppUser Client { get; set; }

        public Location location { get; set; }
        //public string Email { get; set; }
        // public string Name { get; set; }



    }

    public partial class ResumeEPY
    {
        [Key]
        public string Id { get; set; }
        public string MemberRegisterId { get; set; }
        public AppUser MemberRegister { get; set; }
        public string ResumeName { get; set; }
        public string JobfieldId { get; set; }
        public string JobField2Id { get; set; }
        public int locationId { get; set; }
        public JobFieldEPY Jobfield { get; set; }
        public JobFieldEPY JobField2 { get; set; }
        public Location location { get; set; }

        public int ExpectedSalary { get; set; }
        // public EducationEPY Education { get; set; }
        //public DrivinglicenseEPY Drivinglicense { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Update_at { get; set; }
        public DateTime Deleted_at { get; set; }
        public bool Show_open { get; set; }

        public ResumeEPY resume { get; set; }
       // public JobExpEPY jobExpEPY { get; set; }
       // public JobFieldEPY jobField { get; set; }
       // public Location location { get; set; }

    }
    public class DegreeEPY
    {
        [Key]
        public string Id { get; set; }
        public Degrees Degree { get; set; }
        public string SchoolName { get; set; }
        public StudyCategory StudyCate { get; set; }
        public string MajorSubject { get; set; }
        public int Year { get; set; }
        public float GPAScore { get; set; }
        public string DegreeId { get; set; }
        public string StudyCateId { get; set; }
    }

    public class DrivinglicenseEPY
    {
        [Key]
        public string Id { get; set; }
        public string DrivinglicenseName { get; set; }


    }

    public class EducationEPY
    {
        [Key]
        public string Id { get; set; }
        public string DegreeId { get; set; }
        public string ResumeId { get; set; }
        public DegreeEPY Degree { get; set; }
        public ResumeEPY Resume { get; set; }
       
    }

    public class JobExpEPY
    {
        [Key]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string JobFieldId { get; set; }
        public JobFieldEPY JobField { get; set; }
        public string PositionId { get; set; }
        public PositionlevelEPY Position { get; set; }
        public string WorkingDept { get; set; }
        public int CompanylocationId { get; set; }
        public Location Companylocation { get; set; }
        public string industryId { get; set; }
        public Industry industry { get; set; }
        public int Salary { get; set; }
        public string Jobduty { get; set; }
        public DateTime Workingstart { get; set; }
        public DateTime Workingend { get; set; }
        public string etcposition { get; set; }
        public bool working_in_overseas { get; set; }
        public int Status_Working { get; set; }
        public ResumeEPY Resume { get; set; }

    }


    public class ForeignLanguage
    {
        [Key]
        public string Id { get; set; }
        public string Languagelevel_Thai { get; set; }
        public string Languagelevel_Eng { get; set; }
        public string ForeignLanguage_ID { get; set; }
        public string ForeignLanguage_Thai { get; set; }
        public string ForeignLanguage_Eng { get; set; }

    }

    public class PositionlevelEPY
    {
        [Key]
        public string Id { get; set; }
        public string Positionlevel_Thai{ get; set; }
        public string Positionlevel_Eng { get; set; }

    }
    public class VehicleCatEPY
    {
        [Key]
        public string Id { get; set; }
        public string VehicleCatName { get; set; }
    }
    public class Gender
    {
        [Key]
        public string Id { get; set; }
        public string GenderName { get; set; }

    }

    public class MarriageStatus
    {
        public string Id { get; set; }
        public string MarriageName { get; set; }
    }

    public class Nationality
    {
        public int Id { get; set; }
        public string Country_ID { get; set; }
        public string Country_Thai { get; set; }
        public string Country_Eng { get; set; }
        public string Contient_ID { get; set; }
        public string Continent_Thai { get; set; }
        public string Continent_Eng { get; set; }
        public string Nationality_ID { get; set; }
        public string Nationality_Thai { get; set; }
        public string Nationality_Eng { get; set; }
    }
    public class Religion
    {
        public string Id { get; set; }
        public string ReligionName { get; set; }
    }

    public class Military
    {
        public string Id { get; set; }
        public string MilitaryName { get; set; }
    }

    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Tambon_ID { get; set; }
        public string Tambon_Thai { get; set; }
        public string Tambon_Eng { get; set; }
        public string Postal_Code { get; set; }
        public string District_ID { get; set; }
        public string District_Thai { get; set; }
        public string District_Eng { get; set; }
        public string Province_ID { get; set; }
        public string Province_Thai { get; set; }
        public string Province_Eng { get; set; }
        public string Region_Thai { get; set; }
        public string Region_Eng { get; set; }
    }

    public class Degrees
    {
        [Key]
        public string Id { get; set; }
        public string Degree_Thai { get; set; }
        public string Degree_Eng { get; set; }
    }
    public class StudyCategory
    {
        public string Id { get; set; }
        public string StudyCat_Eng { get; set; }
        public string StudyCat_Thai { get; set; }
    }
    public class Industry
    {
        [Key]
        public string Id { get; set; }
        public string Industry_Thai { get; set; }
        public string Industry_Eng { get; set; }
    }



    public class LanguageMain
    {
        [Key]
        public string Id { get; set; }
        public string ForeignLanguageId { get; set; }
        public string ResumeId { get; set; }
        public ForeignLanguage ForeignLanguage { get; set; }
        public ResumeEPY Resume { get; set; }

    }
    public class JobFieldEPY
    {
        [Key]
        public string Id { get; set; }
        public string JobField_Thai { get; set; }
        public string JobField_Eng { get; set; }
        public string JobField_Category_ID { get; set; }
        public string JobField_Category_Thai { get; set; }
        public string JobField_Category_Eng { get; set; }
    }

    public class ImageFile
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string File_format { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime update_at { get; set; }
        public string ClientId { get; set; }
        public MembersInfoEPY Client { get; set; }

       

    }


    public class DrivingEPY
    {
        [Key]
        public string Id { get; set; }

        public string drivinglicenseId { get; set; }
        public string ResumeId { get; set; }
        public DrivinglicenseEPY drivinglicense { get; set; }
        public ResumeEPY Resume { get; set; }

    }

    public class VehicleEPY
    {
        [Key]
        public string Id { get; set; }

        public string vehicleId { get; set; }
        public string ResumeId { get; set; }
        public VehicleCatEPY vehicle { get; set; }
        public ResumeEPY Resume { get; set; }

    }

    public class CertificateEPY
    {
        [Key]
        public string Id { get; set; }
        public string Cert_CategoryCert_pize_Id { get; set; }
        public Cert_pize Cert_Category { get; set; }
        public string CertName { get; set; }
        public string Issued_by { get; set; }
        public string ResumeId { get; set; }
        public ResumeEPY Resume { get; set; }

    }

    public class Cert_pize
    {
        [Key]
        public string Cert_pize_Id { get; set; }
        public string Position_level_thai { get; set; }
        public string Position_level_Eng { get; set; }
    }

    public class TrainingEPY
    {
        [Key]
        public string Id { get; set; }
        public string TrainingName { get; set; }
        public string Issued_by { get; set; }
        public DateTime StartTraining { get; set; }
        public DateTime EndTraining { get; set; }
        public string ResumeId { get; set; }
        public ResumeEPY Resume { get; set; }
    }

    public class EmploymentType
    {   
        [Key]
        public string Id { get; set; }
        public string Employment_Thai { get; set; }
        public string Employment_Eng { get; set; }
    
    }

    public class EmploymentEPY
    {
        [Key]
        public string Id { get; set; }
        public string EmploymentId { get; set; }
        public string resumeId { get; set; }
        public EmploymentType Employment { get; set; }
        public ResumeEPY resume { get; set; }

    }
}
