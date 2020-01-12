using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsInfo.Data.Migrations
{
    public partial class AddedEngineDescriptionAndImageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wheels",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Engines",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Engines",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Engines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_ImageId",
                table: "Engines",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Images_ImageId",
                table: "Engines",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Images_ImageId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_ImageId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Engines");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wheels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Engines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
