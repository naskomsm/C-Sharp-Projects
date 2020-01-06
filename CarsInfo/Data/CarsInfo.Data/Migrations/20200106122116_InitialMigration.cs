using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsInfo.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(nullable: false),
                    CylindersDiameter = table.Column<double>(nullable: false),
                    CylindersStroke = table.Column<double>(nullable: false),
                    CylindersCount = table.Column<int>(nullable: false),
                    CylindersPosition = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    MaxPowerIn = table.Column<int>(nullable: false),
                    Torque = table.Column<int>(nullable: false),
                    FuelInjection = table.Column<int>(nullable: false),
                    Turbine = table.Column<int>(nullable: false),
                    CompressionRatio = table.Column<double>(nullable: false),
                    NumberOfValvesPerCylinder = table.Column<int>(nullable: false),
                    FuelType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(maxLength: 20, nullable: false),
                    ImageData = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brakes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brakes_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    CarBrandMadeFor = table.Column<string>(maxLength: 20, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suspensions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suspensions_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wheels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Color = table.Column<string>(maxLength: 25, nullable: false),
                    FrontAxleSize = table.Column<string>(nullable: false),
                    RearAxleSize = table.Column<string>(nullable: false),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wheels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wheels_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    Generation = table.Column<string>(maxLength: 50, nullable: false),
                    Color = table.Column<string>(maxLength: 25, nullable: false),
                    YearStart = table.Column<int>(nullable: false),
                    YearEnd = table.Column<int>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    Doors = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    FuelConsumption = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    MaxWeight = table.Column<double>(nullable: false),
                    EmissionStandard = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    EngineId = table.Column<int>(nullable: false),
                    BrakesId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: true),
                    ABS = table.Column<bool>(nullable: false),
                    WheelDrive = table.Column<int>(nullable: false),
                    WheelsId = table.Column<int>(nullable: false),
                    SuspensionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brakes_BrakesId",
                        column: x => x.BrakesId,
                        principalTable: "Brakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Suspensions_SuspensionId",
                        column: x => x.SuspensionId,
                        principalTable: "Suspensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Wheels_WheelsId",
                        column: x => x.WheelsId,
                        principalTable: "Wheels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrakesOrder",
                columns: table => new
                {
                    BrakesId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrakesOrder", x => new { x.BrakesId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_BrakesOrder_Brakes_BrakesId",
                        column: x => x.BrakesId,
                        principalTable: "Brakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrakesOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EngineOrder",
                columns: table => new
                {
                    EngineId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineOrder", x => new { x.EngineId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_EngineOrder_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuspensionOrder",
                columns: table => new
                {
                    SuspensionId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspensionOrder", x => new { x.OrderId, x.SuspensionId });
                    table.ForeignKey(
                        name: "FK_SuspensionOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuspensionOrder_Suspensions_SuspensionId",
                        column: x => x.SuspensionId,
                        principalTable: "Suspensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WheelsOrder",
                columns: table => new
                {
                    WheelsId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelsOrder", x => new { x.OrderId, x.WheelsId });
                    table.ForeignKey(
                        name: "FK_WheelsOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WheelsOrder_Wheels_WheelsId",
                        column: x => x.WheelsId,
                        principalTable: "Wheels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarOrder",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrder", x => new { x.CarId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_CarOrder_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brakes_ImageId",
                table: "Brakes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BrakesOrder_OrderId",
                table: "BrakesOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOrder_OrderId",
                table: "CarOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrakesId",
                table: "Cars",
                column: "BrakesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImageId",
                table: "Cars",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SuspensionId",
                table: "Cars",
                column: "SuspensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_WheelsId",
                table: "Cars",
                column: "WheelsId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineOrder_OrderId",
                table: "EngineOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuspensionOrder_SuspensionId",
                table: "SuspensionOrder",
                column: "SuspensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_CategoryId",
                table: "Suspensions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_ImageId",
                table: "Suspensions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wheels_ImageId",
                table: "Wheels",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WheelsOrder_WheelsId",
                table: "WheelsOrder",
                column: "WheelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrakesOrder");

            migrationBuilder.DropTable(
                name: "CarOrder");

            migrationBuilder.DropTable(
                name: "EngineOrder");

            migrationBuilder.DropTable(
                name: "SuspensionOrder");

            migrationBuilder.DropTable(
                name: "WheelsOrder");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brakes");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "Wheels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
