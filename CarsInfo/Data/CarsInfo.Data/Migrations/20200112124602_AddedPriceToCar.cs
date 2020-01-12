using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsInfo.Data.Migrations
{
    public partial class AddedPriceToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Images_ImageId",
                table: "Engines");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspensions_Categories_CategoryId",
                table: "Suspensions");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Cars",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Images_ImageId",
                table: "Engines",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspensions_Categories_CategoryId",
                table: "Suspensions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Images_ImageId",
                table: "Engines");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspensions_Categories_CategoryId",
                table: "Suspensions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Images_ImageId",
                table: "Engines",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspensions_Categories_CategoryId",
                table: "Suspensions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
