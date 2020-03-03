using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabv.Data.Migrations
{
    public partial class modelPropertyToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ModelId",
                table: "Posts",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Models_ModelId",
                table: "Posts",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Models_ModelId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ModelId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Posts");
        }
    }
}
