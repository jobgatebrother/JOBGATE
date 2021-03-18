using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE.Migrations
{
    public partial class UpdateTableJobPosting4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResumeType",
                table: "CPN_JobPosting",
                type: "varchar(2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "JobAdvertise",
                table: "CPN_JobPosting",
                type: "varchar(2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ResumeType",
                table: "CPN_JobPosting",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobAdvertise",
                table: "CPN_JobPosting",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true);
        }
    }
}
