using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabv.Data.Migrations
{
    public partial class AddedDeletedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AdditionalInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdditionalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfo_IsDeleted",
                table: "AdditionalInfo",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfo_IsDeleted",
                table: "AdditionalInfo");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AdditionalInfo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdditionalInfo");
        }
    }
}
