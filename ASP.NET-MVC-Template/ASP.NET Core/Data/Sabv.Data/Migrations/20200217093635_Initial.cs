using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sabv.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    GPS = table.Column<bool>(nullable: false),
                    ABS = table.Column<bool>(nullable: false),
                    TractionControl = table.Column<bool>(nullable: false),
                    Parktronic = table.Column<bool>(nullable: false),
                    StartStopFunction = table.Column<bool>(nullable: false),
                    AirSuspension = table.Column<bool>(nullable: false),
                    ClimateControl = table.Column<bool>(nullable: false),
                    ThreeDoors = table.Column<bool>(nullable: false),
                    FiveDoors = table.Column<bool>(nullable: false),
                    AllWheelDrive = table.Column<bool>(nullable: false),
                    Barter = table.Column<bool>(nullable: false),
                    Tuned = table.Column<bool>(nullable: false),
                    RainSensor = table.Column<bool>(nullable: false),
                    ElectricMirrors = table.Column<bool>(nullable: false),
                    ElectricWindows = table.Column<bool>(nullable: false),
                    USBAudio = table.Column<bool>(nullable: false),
                    Airbags = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    VehicleCreatedOn = table.Column<DateTime>(nullable: false),
                    EngineType = table.Column<int>(nullable: false),
                    TransmissionType = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    Mileage = table.Column<double>(nullable: false),
                    Color = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 10000, nullable: true),
                    IsFavourite = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    MainInfoId = table.Column<string>(nullable: false),
                    AdditionalInfoId = table.Column<string>(nullable: false),
                    VehicleCategoryId = table.Column<string>(nullable: false),
                    PostCategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_AdditionalInfo_AdditionalInfoId",
                        column: x => x.AdditionalInfoId,
                        principalTable: "AdditionalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_MainInfo_MainInfoId",
                        column: x => x.MainInfoId,
                        principalTable: "MainInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_PostCategory_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_VehicleCategory_VehicleCategoryId",
                        column: x => x.VehicleCategoryId,
                        principalTable: "VehicleCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    PostId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IsDeleted",
                table: "Image",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Image_PostId",
                table: "Image",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AdditionalInfoId",
                table: "Post",
                column: "AdditionalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ApplicationUserId",
                table: "Post",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_IsDeleted",
                table: "Post",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Post_MainInfoId",
                table: "Post",
                column: "MainInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostCategoryId",
                table: "Post",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_VehicleCategoryId",
                table: "Post",
                column: "VehicleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AdditionalInfo");

            migrationBuilder.DropTable(
                name: "MainInfo");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "VehicleCategory");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");
        }
    }
}
