using Microsoft.EntityFrameworkCore.Migrations;

namespace Restopos.Yoklama.DataAccess.Migrations
{
    public partial class AddPasswordColumnAndAddIsHourlyColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Privileges",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHourly",
                table: "AbsenceTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Privileges");

            migrationBuilder.DropColumn(
                name: "IsHourly",
                table: "AbsenceTypes");
        }
    }
}
