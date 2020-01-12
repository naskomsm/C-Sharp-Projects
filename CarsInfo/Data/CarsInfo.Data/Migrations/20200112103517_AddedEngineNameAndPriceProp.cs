using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsInfo.Data.Migrations
{
    public partial class AddedEngineNameAndPriceProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Engines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Engines",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Engines");
        }
    }
}
