using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE.Migrations
{
    public partial class UpdateTableJobPosting3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "CPN_JobPosting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CPN_JobPosting");
        }
    }
}
