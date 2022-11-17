using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningPersonal.Migrations
{
    public partial class IsActiveFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "WorkingSites",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Departments",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "WorkingSites",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Departments",
                newName: "Activo");
        }
    }
}
