using Microsoft.EntityFrameworkCore.Migrations;

namespace JOBGATE_MVC_C.Migrations
{
    public partial class ResumeEPY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobExpEPY_JobFieldEPY_JobFieldId",
                table: "JobExpEPY");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExpEPY_PositionlevelEPY_PositionId",
                table: "JobExpEPY");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExpEPY_Industry_industryId",
                table: "JobExpEPY");

            migrationBuilder.AlterColumn<int>(
                name: "industryId",
                table: "JobExpEPY",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "JobExpEPY",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobFieldId",
                table: "JobExpEPY",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExpEPY_JobFieldEPY_JobFieldId",
                table: "JobExpEPY",
                column: "JobFieldId",
                principalTable: "JobFieldEPY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExpEPY_PositionlevelEPY_PositionId",
                table: "JobExpEPY",
                column: "PositionId",
                principalTable: "PositionlevelEPY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExpEPY_Industry_industryId",
                table: "JobExpEPY",
                column: "industryId",
                principalTable: "Industry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobExpEPY_JobFieldEPY_JobFieldId",
                table: "JobExpEPY");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExpEPY_PositionlevelEPY_PositionId",
                table: "JobExpEPY");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExpEPY_Industry_industryId",
                table: "JobExpEPY");

            migrationBuilder.AlterColumn<int>(
                name: "industryId",
                table: "JobExpEPY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "JobExpEPY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "JobFieldId",
                table: "JobExpEPY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_JobExpEPY_JobFieldEPY_JobFieldId",
                table: "JobExpEPY",
                column: "JobFieldId",
                principalTable: "JobFieldEPY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExpEPY_PositionlevelEPY_PositionId",
                table: "JobExpEPY",
                column: "PositionId",
                principalTable: "PositionlevelEPY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExpEPY_Industry_industryId",
                table: "JobExpEPY",
                column: "industryId",
                principalTable: "Industry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
