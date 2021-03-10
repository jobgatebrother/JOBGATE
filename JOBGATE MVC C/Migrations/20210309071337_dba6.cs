using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE_MVC_C.Migrations
{
    public partial class dba6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationEPY",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DegreeId = table.Column<string>(nullable: true),
                    ResumeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationEPY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationEPY_DegreeEPY_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "DegreeEPY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationEPY_ResumeEPY_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "ResumeEPY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationEPY_DegreeId",
                table: "EducationEPY",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationEPY_ResumeId",
                table: "EducationEPY",
                column: "ResumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationEPY");
        }
    }
}
