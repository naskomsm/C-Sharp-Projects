namespace Sabv.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedImageNameProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Image",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
