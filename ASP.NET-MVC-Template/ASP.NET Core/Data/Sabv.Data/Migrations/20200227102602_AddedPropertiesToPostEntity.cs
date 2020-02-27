using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabv.Data.Migrations
{
    public partial class AddedPropertiesToPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Posts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Posts");
        }
    }
}
