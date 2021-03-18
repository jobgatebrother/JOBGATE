using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEN_CertificateCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateID = table.Column<string>(type: "varchar(10)", nullable: true),
                    CertificateTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    CertificateEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_CertificateCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_Degrees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeID = table.Column<string>(type: "varchar(10)", nullable: true),
                    DegreeTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    DegreeEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_Degrees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_ForeignLanguage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguagelevelID = table.Column<string>(type: "varchar(10)", nullable: true),
                    LanguagelevelTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    LanguagelevelEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    ForeignLanguageID = table.Column<string>(type: "varchar(10)", nullable: true),
                    ForeignLanguageTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    ForeignLanguageEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_ForeignLanguage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_IndustryCodeList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", nullable: true),
                    IndustryNameTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    IndustryNameEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_IndustryCodeList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_JobField",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobFieldID = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobFieldTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    JobFieldEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    JobCategoryID = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobCategoryTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    JobCategoryEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_JobField", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_LocationThailand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDistrictID = table.Column<string>(type: "varchar(10)", nullable: true),
                    SubDistrictTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    SubDistrictEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "varchar(10)", nullable: true),
                    DistrictID = table.Column<string>(type: "varchar(10)", nullable: true),
                    DistrictTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    DistrictEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    ProvinceID = table.Column<string>(type: "varchar(10)", nullable: true),
                    ProvinceTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    ProvinceEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    RegionTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    RegionEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_LocationThailand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_MarriageStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarriageID = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MarriageNameTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarriageNameEN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_MarriageStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_Nationality",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<string>(type: "varchar(10)", nullable: true),
                    CountryTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    CountryEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    ContientID = table.Column<string>(type: "varchar(10)", nullable: true),
                    ContinentTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    ContinentEN = table.Column<string>(type: "varchar(max)", nullable: true),
                    NationalityID = table.Column<string>(type: "varchar(10)", nullable: true),
                    NationalityTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    NationalityEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_Nationality", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_Positionlevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionlevelID = table.Column<string>(type: "varchar(10)", nullable: true),
                    PositionlevelTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    PositionlevelEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_Positionlevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEN_StudyCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyCatID = table.Column<string>(type: "varchar(10)", nullable: true),
                    StudyCatTH = table.Column<string>(type: "varchar(max)", nullable: true),
                    StudyCatEN = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEN_StudyCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CPN_CompanyIntroduction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "varchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "varchar(10)", nullable: true),
                    Oversea = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "varchar(10)", nullable: true),
                    Province = table.Column<string>(type: "varchar(10)", nullable: true),
                    District = table.Column<string>(type: "varchar(10)", nullable: true),
                    SubDistrict = table.Column<string>(type: "varchar(10)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "varchar(max)", nullable: true),
                    Contract = table.Column<string>(type: "varchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(max)", nullable: true),
                    InternalPhone = table.Column<string>(type: "varchar(max)", nullable: true),
                    CompanyDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WelfareBenefit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPN_CompanyIntroduction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CPN_JobPosting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "varchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "varchar(10)", nullable: true),
                    Oversea = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "varchar(10)", nullable: true),
                    Province = table.Column<string>(type: "varchar(10)", nullable: true),
                    District = table.Column<string>(type: "varchar(10)", nullable: true),
                    SubDistrict = table.Column<string>(type: "varchar(10)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "varchar(max)", nullable: true),
                    Contract = table.Column<string>(type: "varchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "varchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", nullable: true),
                    CompanyDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WelfareBenefit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "varchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobField = table.Column<string>(type: "varchar(10)", nullable: true),
                    PositionLevel = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobExperience = table.Column<string>(type: "varchar(10)", nullable: true),
                    EducationDegree = table.Column<string>(type: "varchar(10)", nullable: true),
                    LanguageSkill = table.Column<string>(type: "varchar(10)", nullable: true),
                    Car = table.Column<bool>(type: "bit", nullable: false),
                    Motorbike = table.Column<bool>(type: "bit", nullable: false),
                    Truck = table.Column<bool>(type: "bit", nullable: false),
                    Trailer = table.Column<bool>(type: "bit", nullable: false),
                    Forklift = table.Column<bool>(type: "bit", nullable: false),
                    QualificationDetail = table.Column<string>(type: "varchar(max)", nullable: true),
                    AgeMin = table.Column<int>(type: "int", nullable: false),
                    AgeMax = table.Column<int>(type: "int", nullable: false),
                    SalaryMin = table.Column<int>(type: "int", nullable: false),
                    SalaryMax = table.Column<int>(type: "int", nullable: false),
                    ResumeType = table.Column<int>(type: "int", nullable: false),
                    JobAdvertise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPN_JobPosting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_Certifiacte",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillTraning = table.Column<string>(type: "varchar(10)", nullable: true),
                    CertCategory = table.Column<string>(type: "varchar(10)", nullable: true),
                    TitleName = table.Column<string>(type: "varchar(max)", nullable: true),
                    Issued_by = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_Certifiacte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_Education",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "varchar(10)", nullable: true),
                    SchoolName = table.Column<string>(type: "varchar(max)", nullable: true),
                    StudyCatagory = table.Column<string>(type: "varchar(10)", nullable: true),
                    MajorSubject = table.Column<string>(type: "varchar(max)", nullable: true),
                    GraduatationYear = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_Education", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "varchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    MobilePhone = table.Column<string>(type: "varchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "varchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "varchar(10)", nullable: true),
                    MarriageStatus = table.Column<string>(type: "varchar(10)", nullable: true),
                    Oversea = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "varchar(10)", nullable: true),
                    Province = table.Column<string>(type: "varchar(10)", nullable: true),
                    District = table.Column<string>(type: "varchar(10)", nullable: true),
                    SubDistrict = table.Column<string>(type: "varchar(10)", nullable: true),
                    Address = table.Column<string>(type: "varchar(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ImgPath = table.Column<string>(type: "varchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "varchar(20)", nullable: true),
                    Military = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_JobExp",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(max)", nullable: true),
                    DateStartWork = table.Column<DateTime>(type: "date", nullable: false),
                    DateEndWork = table.Column<DateTime>(type: "date", nullable: false),
                    Statuswork = table.Column<string>(type: "varchar(10)", nullable: true),
                    Industry = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobField = table.Column<string>(type: "varchar(10)", nullable: true),
                    Position = table.Column<string>(type: "varchar(10)", nullable: true),
                    WorkingDept = table.Column<string>(type: "varchar(max)", nullable: true),
                    Province = table.Column<string>(type: "varchar(10)", nullable: true),
                    District = table.Column<string>(type: "varchar(10)", nullable: true),
                    SubDistrict = table.Column<string>(type: "varchar(10)", nullable: true),
                    Oversea = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "varchar(10)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Jobduty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_JobExp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_RequiredJob",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobField1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobField2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    FullTime = table.Column<bool>(type: "bit", nullable: false),
                    PartTime = table.Column<bool>(type: "bit", nullable: false),
                    Freelance = table.Column<bool>(type: "bit", nullable: false),
                    Intern = table.Column<bool>(type: "bit", nullable: false),
                    WorkLocation = table.Column<string>(type: "varchar(10)", nullable: true),
                    ExpectedSalary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_RequiredJob", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_ShowResume",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee = table.Column<string>(type: "varchar(10)", nullable: true),
                    Education = table.Column<string>(type: "varchar(10)", nullable: true),
                    RequiredJob = table.Column<string>(type: "varchar(10)", nullable: true),
                    JobExp = table.Column<string>(type: "varchar(10)", nullable: true),
                    SkillTraning = table.Column<string>(type: "varchar(10)", nullable: true),
                    Date_create = table.Column<DateTime>(type: "datetime", nullable: false),
                    Date_update = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status_open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_ShowResume", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_SkillTraning",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    LevelLanguage1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    Language2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    LevelLanguage2 = table.Column<string>(type: "varchar(10)", nullable: true),
                    Language3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    LevelLanguage3 = table.Column<string>(type: "varchar(10)", nullable: true),
                    DrivingLicenseCar = table.Column<bool>(type: "bit", nullable: false),
                    DrivingLicenseMotorbike = table.Column<bool>(type: "bit", nullable: false),
                    DrivingLicenseTruck = table.Column<bool>(type: "bit", nullable: false),
                    DrivingLicenseTrailer = table.Column<bool>(type: "bit", nullable: false),
                    DrivingLicenseForklift = table.Column<bool>(type: "bit", nullable: false),
                    OwrCarForkCar = table.Column<bool>(type: "bit", nullable: false),
                    OwrCarForkMotorbike = table.Column<bool>(type: "bit", nullable: false),
                    OwrCarForkTruck = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_SkillTraning", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EPY_Training",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillID = table.Column<string>(type: "varchar(10)", nullable: true),
                    SkillTraning = table.Column<string>(type: "varchar(10)", nullable: true),
                    TrainingName = table.Column<string>(type: "varchar(max)", nullable: true),
                    Issued_by = table.Column<string>(type: "varchar(max)", nullable: true),
                    StartTraining = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTraining = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPY_Training", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEN_CertificateCategory");

            migrationBuilder.DropTable(
                name: "CEN_Degrees");

            migrationBuilder.DropTable(
                name: "CEN_ForeignLanguage");

            migrationBuilder.DropTable(
                name: "CEN_IndustryCodeList");

            migrationBuilder.DropTable(
                name: "CEN_JobField");

            migrationBuilder.DropTable(
                name: "CEN_LocationThailand");

            migrationBuilder.DropTable(
                name: "CEN_MarriageStatus");

            migrationBuilder.DropTable(
                name: "CEN_Nationality");

            migrationBuilder.DropTable(
                name: "CEN_Positionlevel");

            migrationBuilder.DropTable(
                name: "CEN_StudyCategory");

            migrationBuilder.DropTable(
                name: "CPN_CompanyIntroduction");

            migrationBuilder.DropTable(
                name: "CPN_JobPosting");

            migrationBuilder.DropTable(
                name: "EPY_Certifiacte");

            migrationBuilder.DropTable(
                name: "EPY_Education");

            migrationBuilder.DropTable(
                name: "EPY_Employee");

            migrationBuilder.DropTable(
                name: "EPY_JobExp");

            migrationBuilder.DropTable(
                name: "EPY_RequiredJob");

            migrationBuilder.DropTable(
                name: "EPY_ShowResume");

            migrationBuilder.DropTable(
                name: "EPY_SkillTraning");

            migrationBuilder.DropTable(
                name: "EPY_Training");
        }
    }
}
