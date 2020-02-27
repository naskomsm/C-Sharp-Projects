using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabv.Data.Migrations
{
    public partial class AddedCurrencyEnumToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Posts");
        }
    }
}
