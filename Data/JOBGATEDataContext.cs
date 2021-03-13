using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JOBGATE.Models;

namespace JOBGATE.Data
{
    public class JOBGATEDataContext : DbContext
    {
        public JOBGATEDataContext (DbContextOptions<JOBGATEDataContext> options)
            : base(options)
        {
        }

        //Center Model
        public DbSet<CEN_CertificateCategory> CEN_CertificateCategory { get; set; }
        public DbSet<CEN_Degrees> CEN_Degrees { get; set; }
        public DbSet<CEN_ForeignLanguage> CEN_ForeignLanguage { get; set; }
        public DbSet<CEN_IndustryCodeList> CEN_IndustryCodeList { get; set; }
        public DbSet<CEN_JobField> CEN_JobField { get; set; }
        public DbSet<CEN_LocationThailand> CEN_LocationThailand { get; set; }
        public DbSet<CEN_MarriageStatus> CEN_MarriageStatus { get; set; }
        public DbSet<CEN_Nationality> CEN_Nationality { get; set; }
        public DbSet<CEN_Positionlevel> CEN_Positionlevel { get; set; }
        public DbSet<CEN_StudyCategory> CEN_StudyCategory { get; set; }

        //Company Model
        public DbSet<CPN_CompanyIntroduction> CPN_CompanyIntroduction { get; set; }
        public DbSet<CPN_JobPosting> CPN_JobPosting { get; set; }

        //Employee Model
        public DbSet<EPY_Certificate> EPY_Certifiacte { get; set; }
        public DbSet<EPY_Education> EPY_Education { get; set; }
        public DbSet<EPY_Employee> EPY_Employee { get; set; }
        public DbSet<EPY_JobExp> EPY_JobExp { get; set; }
        public DbSet<EPY_RequiredJob> EPY_RequiredJob { get; set; }
        public DbSet<EPY_ShowResume> EPY_ShowResume { get; set; }
        public DbSet<EPY_SkillTraning> EPY_SkillTraning { get; set; }
        public DbSet<EPY_Training> EPY_Training { get; set; }

    }
}
