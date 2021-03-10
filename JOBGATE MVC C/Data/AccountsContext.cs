using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOBGATE_MVC_C.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JOBGATE_MVC_C.Models.PersonInfo;

namespace JOBGATE_MVC_C.Models
{
    public class AccountsContext : IdentityDbContext<AppUser>
    {
        public AccountsContext(DbContextOptions<AccountsContext> options)
            : base(options)
        {

        }
       
       public DbSet<MembersInfoEPY> MembersInfoEPY { get; set; }
      public DbSet<ResumeEPY> ResumeEPY { get; set; }
       public DbSet<DegreeEPY> DegreeEPY { get; set; }
       
        public DbSet<DrivinglicenseEPY> DrivinglicenseEPY { get; set; }
        public DbSet<EducationEPY> EducationEPY { get; set; }
        public DbSet<JobExpEPY> JobExpEPY { get; set; }
        public DbSet<JobFieldEPY> JobFieldEPY { get; set; }
        public DbSet<ForeignLanguage> ForeignLanguageEPY { get; set; }
        public DbSet<PositionlevelEPY> PositionlevelEPY { get; set; }
        public DbSet<VehicleCatEPY> VehicleCatEPY { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MarriageStatus> MarriageStatus { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<Military> Military { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<DrivingEPY> DrivingEPY { get; set; }
        public DbSet<VehicleEPY> VehicleEPY { get; set; }
        public DbSet<LanguageMain> LanguageMainEPY { get; set; }
       
        public DbSet<SkillsEPY> SkillEPY { get; set; }
        public DbSet<CertificateEPY> CertificateEPY { get; set; }
        public DbSet<TrainingEPY> TrainingEPY { get; set; }
        public DbSet<StudyCategory> StudyCategory { get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<JobFieldEPY> JobFields { get; set; }
        public DbSet<Degrees> Degrees { get; set; }
        public DbSet<ImageFile> imageFiles { get; set; }
        public DbSet<Cert_pize> Cert_Pizes { get; set; }
        public DbSet<EmploymentType> EmploymentType { get; set; }
        public DbSet<EmploymentEPY> EmploymentEPY { get; set; }

    }
}
