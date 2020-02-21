namespace Sabv.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedRequiredFromPostPropInImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Image",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "Image",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
