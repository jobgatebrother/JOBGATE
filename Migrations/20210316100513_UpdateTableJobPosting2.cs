using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE.Migrations
{
    public partial class UpdateTableJobPosting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JobExperience",
                table: "CPN_JobPosting",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreshGraduated",
                table: "CPN_JobPosting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreshGraduated",
                table: "CPN_JobPosting");

            migrationBuilder.AlterColumn<string>(
                name: "JobExperience",
                table: "CPN_JobPosting",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
