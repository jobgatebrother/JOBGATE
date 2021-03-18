using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE.Migrations
{
    public partial class UpdateTableJobposting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplyCount",
                table: "CPN_JobPosting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "CPN_JobPosting",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "CPN_JobPosting",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "CPN_JobPosting",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyCount",
                table: "CPN_JobPosting");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CPN_JobPosting");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "CPN_JobPosting");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "CPN_JobPosting");
        }
    }
}
