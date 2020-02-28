namespace Sabv.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangedAdditionalInfoForeignKeysFromIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_ComfortInfo_ComfortInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_ExteriorInfo_ExteriorInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_OtherInfo_OtherInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_SafetyInfo_SafetyInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_ComfortInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_ExteriorInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_OtherInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_SafetyInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ComfortInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ExteriorInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "OtherInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "SafetyInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.AlterColumn<string>(
                name: "SafetyInfoId",
                table: "AdditionalInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OtherInfoId",
                table: "AdditionalInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ExteriorInfoId",
                table: "AdditionalInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ComfortInfoId",
                table: "AdditionalInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_ComfortInfoId",
                table: "AdditionalInfos",
                column: "ComfortInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_ExteriorInfoId",
                table: "AdditionalInfos",
                column: "ExteriorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_OtherInfoId",
                table: "AdditionalInfos",
                column: "OtherInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_SafetyInfoId",
                table: "AdditionalInfos",
                column: "SafetyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_ComfortInfo_ComfortInfoId",
                table: "AdditionalInfos",
                column: "ComfortInfoId",
                principalTable: "ComfortInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_ExteriorInfo_ExteriorInfoId",
                table: "AdditionalInfos",
                column: "ExteriorInfoId",
                principalTable: "ExteriorInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_OtherInfo_OtherInfoId",
                table: "AdditionalInfos",
                column: "OtherInfoId",
                principalTable: "OtherInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_SafetyInfo_SafetyInfoId",
                table: "AdditionalInfos",
                column: "SafetyInfoId",
                principalTable: "SafetyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_ComfortInfo_ComfortInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_ExteriorInfo_ExteriorInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_OtherInfo_OtherInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfos_SafetyInfo_SafetyInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_ComfortInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_ExteriorInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_OtherInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfos_SafetyInfoId",
                table: "AdditionalInfos");

            migrationBuilder.AlterColumn<int>(
                name: "SafetyInfoId",
                table: "AdditionalInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OtherInfoId",
                table: "AdditionalInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExteriorInfoId",
                table: "AdditionalInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComfortInfoId",
                table: "AdditionalInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComfortInfoId1",
                table: "AdditionalInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExteriorInfoId1",
                table: "AdditionalInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherInfoId1",
                table: "AdditionalInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyInfoId1",
                table: "AdditionalInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_ComfortInfoId1",
                table: "AdditionalInfos",
                column: "ComfortInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_ExteriorInfoId1",
                table: "AdditionalInfos",
                column: "ExteriorInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_OtherInfoId1",
                table: "AdditionalInfos",
                column: "OtherInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfos_SafetyInfoId1",
                table: "AdditionalInfos",
                column: "SafetyInfoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_ComfortInfo_ComfortInfoId1",
                table: "AdditionalInfos",
                column: "ComfortInfoId1",
                principalTable: "ComfortInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_ExteriorInfo_ExteriorInfoId1",
                table: "AdditionalInfos",
                column: "ExteriorInfoId1",
                principalTable: "ExteriorInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_OtherInfo_OtherInfoId1",
                table: "AdditionalInfos",
                column: "OtherInfoId1",
                principalTable: "OtherInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfos_SafetyInfo_SafetyInfoId1",
                table: "AdditionalInfos",
                column: "SafetyInfoId1",
                principalTable: "SafetyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
