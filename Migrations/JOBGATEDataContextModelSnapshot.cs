﻿// <auto-generated />
using System;
using JOBGATE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JOBGATE.Migrations
{
    [DbContext(typeof(JOBGATEDataContext))]
    partial class JOBGATEDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JOBGATE.Models.CEN_CertificateCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CertificateEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("CertificateID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CertificateTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_CertificateCategory");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_Degrees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DegreeEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DegreeID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DegreeTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_Degrees");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_ForeignLanguage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ForeignLanguageEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ForeignLanguageID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ForeignLanguageTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("LanguagelevelEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("LanguagelevelID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("LanguagelevelTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_ForeignLanguage");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_IndustryCodeList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("IndustryNameEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("IndustryNameTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_IndustryCodeList");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_JobField", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobCategoryEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("JobCategoryID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobCategoryTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("JobFieldEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("JobFieldID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobFieldTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_JobField");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_LocationThailand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DistrictEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DistrictID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DistrictTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ProvinceEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ProvinceID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ProvinceTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("RegionEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("RegionTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SubDistrictEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SubDistrictID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SubDistrictTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_LocationThailand");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_MarriageStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MarriageID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MarriageNameEN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarriageNameTH")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_MarriageStatus");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_Nationality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContientID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ContinentEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ContinentTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("CountryEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("CountryID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CountryTH")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("NationalityEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("NationalityID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("NationalityTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_Nationality");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_Positionlevel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionlevelEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PositionlevelID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PositionlevelTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_Positionlevel");
                });

            modelBuilder.Entity("JOBGATE.Models.CEN_StudyCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudyCatEN")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("StudyCatID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("StudyCatTH")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CEN_StudyCategory");
                });

            modelBuilder.Entity("JOBGATE.Models.CPN_CompanyIntroduction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Contract")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("District")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Industry")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("InternalPhone")
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("Oversea")
                        .HasColumnType("bit");

                    b.Property<string>("Province")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SubDistrict")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("WelfareBenefit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CPN_CompanyIntroduction");
                });

            modelBuilder.Entity("JOBGATE.Models.CPN_JobPosting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgeMax")
                        .HasColumnType("int");

                    b.Property<int>("AgeMin")
                        .HasColumnType("int");

                    b.Property<int>("ApplyCount")
                        .HasColumnType("int");

                    b.Property<bool>("Car")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Contract")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("District")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EducationDegree")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("Forklift")
                        .HasColumnType("bit");

                    b.Property<bool>("FreshGraduated")
                        .HasColumnType("bit");

                    b.Property<string>("Industry")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobAdvertise")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobExperience")
                        .HasColumnType("int");

                    b.Property<string>("JobField")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("LanguageSkill")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("Motorbike")
                        .HasColumnType("bit");

                    b.Property<bool>("Oversea")
                        .HasColumnType("bit");

                    b.Property<string>("PositionLevel")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Province")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("QualificationDetail")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ResumeType")
                        .HasColumnType("varchar(2)");

                    b.Property<int>("SalaryMax")
                        .HasColumnType("int");

                    b.Property<int>("SalaryMin")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SubDistrict")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("Trailer")
                        .HasColumnType("bit");

                    b.Property<bool>("Truck")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserID")
                        .HasColumnType("varchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("WelfareBenefit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CPN_JobPosting");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_Certificate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CertCategory")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Issued_by")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SkillTraning")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TitleName")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EPY_Certifiacte");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_Education", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("GPA")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int>("GraduatationYear")
                        .HasColumnType("int");

                    b.Property<string>("MajorSubject")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("StudyCatagory")
                        .HasColumnType("varchar(10)");

                    b.HasKey("ID");

                    b.ToTable("EPY_Education");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("District")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(4,2)");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("MarriageStatus")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Military")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Oversea")
                        .HasColumnType("bit");

                    b.Property<string>("Province")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Religion")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SubDistrict")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Tel")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("ID");

                    b.ToTable("EPY_Employee");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_JobExp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateEdit")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateEndWork")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateStartWork")
                        .HasColumnType("date");

                    b.Property<string>("District")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Industry")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobField")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Jobduty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Oversea")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Province")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Statuswork")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SubDistrict")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("WorkingDept")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EPY_JobExp");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_RequiredJob", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExpectedSalary")
                        .HasColumnType("int");

                    b.Property<bool>("Freelance")
                        .HasColumnType("bit");

                    b.Property<bool>("FullTime")
                        .HasColumnType("bit");

                    b.Property<bool>("Intern")
                        .HasColumnType("bit");

                    b.Property<string>("JobField1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobField2")
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("PartTime")
                        .HasColumnType("bit");

                    b.Property<string>("WorkLocation")
                        .HasColumnType("varchar(10)");

                    b.HasKey("ID");

                    b.ToTable("EPY_RequiredJob");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_ShowResume", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_create")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Date_update")
                        .HasColumnType("datetime");

                    b.Property<string>("Education")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Employee")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("JobExp")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("RequiredJob")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SkillTraning")
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Status_open")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("EPY_ShowResume");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_SkillTraning", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DrivingLicenseCar")
                        .HasColumnType("bit");

                    b.Property<bool>("DrivingLicenseForklift")
                        .HasColumnType("bit");

                    b.Property<bool>("DrivingLicenseMotorbike")
                        .HasColumnType("bit");

                    b.Property<bool>("DrivingLicenseTrailer")
                        .HasColumnType("bit");

                    b.Property<bool>("DrivingLicenseTruck")
                        .HasColumnType("bit");

                    b.Property<string>("Language1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Language2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Language3")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("LevelLanguage1")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("LevelLanguage2")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("LevelLanguage3")
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("OwrCarForkCar")
                        .HasColumnType("bit");

                    b.Property<bool>("OwrCarForkMotorbike")
                        .HasColumnType("bit");

                    b.Property<bool>("OwrCarForkTruck")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("EPY_SkillTraning");
                });

            modelBuilder.Entity("JOBGATE.Models.EPY_Training", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTraining")
                        .HasColumnType("datetime");

                    b.Property<string>("Issued_by")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SkillID")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SkillTraning")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("StartTraining")
                        .HasColumnType("datetime");

                    b.Property<string>("TrainingName")
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EPY_Training");
                });
#pragma warning restore 612, 618
        }
    }
}
