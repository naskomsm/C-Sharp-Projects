namespace Sabv.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixedIntProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId1",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_UserId1",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Favourites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favourites",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favourites",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Favourites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId1",
                table: "Favourites",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId1",
                table: "Favourites",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
