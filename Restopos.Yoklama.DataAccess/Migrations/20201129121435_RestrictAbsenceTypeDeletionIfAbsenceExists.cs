using Microsoft.EntityFrameworkCore.Migrations;

namespace Restopos.Yoklama.DataAccess.Migrations
{
    public partial class RestrictAbsenceTypeDeletionIfAbsenceExists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceStatuses_AbsenceTypes_AbsenceTypeId",
                table: "AbsenceStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceStatuses_AbsenceTypes_AbsenceTypeId",
                table: "AbsenceStatuses",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceStatuses_AbsenceTypes_AbsenceTypeId",
                table: "AbsenceStatuses");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceStatuses_AbsenceTypes_AbsenceTypeId",
                table: "AbsenceStatuses",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
