﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningPersonal.Migrations
{
    public partial class WorkingSiteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkingSites",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkingSites");
        }
    }
}
