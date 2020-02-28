namespace Sabv.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeparetedAdditionalInfoProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABS",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "AirSuspension",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "Airbags",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "AllWheelDrive",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "Barter",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ClimateControl",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ElectricMirrors",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ElectricWindows",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "FiveDoors",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "GPS",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "Parktronic",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "RainSensor",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "StartStopFunction",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ThreeDoors",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "TractionControl",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "Tuned",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "USBAudio",
                table: "AdditionalInfos");

            migrationBuilder.AddColumn<int>(
                name: "ComfortInfoId",
                table: "AdditionalInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ComfortInfoId1",
                table: "AdditionalInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExteriorInfoId",
                table: "AdditionalInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExteriorInfoId1",
                table: "AdditionalInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherInfoId",
                table: "AdditionalInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OtherInfoId1",
                table: "AdditionalInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SafetyInfoId",
                table: "AdditionalInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SafetyInfoId1",
                table: "AdditionalInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComfortInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    StartStopFunction = table.Column<bool>(nullable: false),
                    AirSuspension = table.Column<bool>(nullable: false),
                    ClimateControl = table.Column<bool>(nullable: false),
                    RainSensor = table.Column<bool>(nullable: false),
                    ElectricMirrors = table.Column<bool>(nullable: false),
                    ElectricWindows = table.Column<bool>(nullable: false),
                    USBAudio = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComfortInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ThreeDoors = table.Column<bool>(nullable: false),
                    FiveDoors = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AllWheelDrive = table.Column<bool>(nullable: false),
                    Barter = table.Column<bool>(nullable: false),
                    Tuned = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    GPS = table.Column<bool>(nullable: false),
                    ABS = table.Column<bool>(nullable: false),
                    TractionControl = table.Column<bool>(nullable: false),
                    Parktronic = table.Column<bool>(nullable: false),
                    Airbags = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyInfo", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ComfortInfo_IsDeleted",
                table: "ComfortInfo",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExteriorInfo_IsDeleted",
                table: "ExteriorInfo",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OtherInfo_IsDeleted",
                table: "OtherInfo",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyInfo_IsDeleted",
                table: "SafetyInfo",
                column: "IsDeleted");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "ComfortInfo");

            migrationBuilder.DropTable(
                name: "ExteriorInfo");

            migrationBuilder.DropTable(
                name: "OtherInfo");

            migrationBuilder.DropTable(
                name: "SafetyInfo");

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
                name: "ComfortInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ComfortInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ExteriorInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "ExteriorInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "OtherInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "OtherInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "SafetyInfoId",
                table: "AdditionalInfos");

            migrationBuilder.DropColumn(
                name: "SafetyInfoId1",
                table: "AdditionalInfos");

            migrationBuilder.AddColumn<bool>(
                name: "ABS",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AirSuspension",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Airbags",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllWheelDrive",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Barter",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ClimateControl",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ElectricMirrors",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ElectricWindows",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FiveDoors",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GPS",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parktronic",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RainSensor",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StartStopFunction",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ThreeDoors",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TractionControl",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tuned",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "USBAudio",
                table: "AdditionalInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
