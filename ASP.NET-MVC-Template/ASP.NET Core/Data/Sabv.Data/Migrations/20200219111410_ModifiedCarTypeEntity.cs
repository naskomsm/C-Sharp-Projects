using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabv.Data.Migrations
{
    public partial class ModifiedCarTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "VehicleCategory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VehicleCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCategory_IsDeleted",
                table: "VehicleCategory",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleCategory_IsDeleted",
                table: "VehicleCategory");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "VehicleCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VehicleCategory");
        }
    }
}
