using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 50, nullable: false),
                    CarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parked",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    RequestStatusId = table.Column<long>(nullable: false),
                    ParkingSpaceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parked", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpaces",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    ParkingTypeId = table.Column<long>(nullable: false),
                    RateId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Zone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentPanels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayedForHours = table.Column<int>(nullable: false),
                    ChargingStart = table.Column<DateTime>(nullable: false),
                    ParkedId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPanels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuedAt = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    PaymentPanelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceHourly = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { 1L, "Chevrolet Aveo" },
                    { 2L, "Opel Corsa" },
                    { 3L, "Renault Clio" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CarId", "LicensePlate" },
                values: new object[,]
                {
                    { 1L, 1L, "lalalalal" },
                    { 2L, 1L, "nanananna" },
                    { 3L, 1L, "blblblbl" }
                });

            migrationBuilder.InsertData(
                table: "Parked",
                columns: new[] { "Id", "DriverId", "From", "ParkingSpaceId", "RequestStatusId", "To" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 1L, new DateTime(2020, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 1L, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "Id", "Lat", "Lng", "ParkingTypeId", "RateId" },
                values: new object[,]
                {
                    { 1L, 20.300000000000001, 13.300000000000001, 1L, 1L },
                    { 2L, 40.299999999999997, 30.300000000000001, 1L, 1L },
                    { 3L, -13.300000000000001, 40.299999999999997, 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "ParkingTypes",
                columns: new[] { "Id", "Type", "Zone" },
                values: new object[,]
                {
                    { 3L, "handicapped", 2 },
                    { 2L, "regular", 2 },
                    { 1L, "handicapped", 2 }
                });

            migrationBuilder.InsertData(
                table: "PaymentPanels",
                columns: new[] { "Id", "ChargingStart", "ParkedId", "PayedForHours" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2 },
                    { 2L, new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 4 },
                    { 3L, new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "IssuedAt", "PaymentPanelId", "Status" },
                values: new object[,]
                {
                    { 1L, 3000.5m, new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "status" },
                    { 2L, 1066.1m, new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "status2" },
                    { 3L, 3111.9m, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "status3" }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "PriceHourly" },
                values: new object[,]
                {
                    { 1L, 6.1m },
                    { 2L, 2.1m },
                    { 3L, 4.6m }
                });

            migrationBuilder.InsertData(
                table: "RequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "neki status" },
                    { 2L, "drugi status" },
                    { 3L, "treci status" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Parked");

            migrationBuilder.DropTable(
                name: "ParkingSpaces");

            migrationBuilder.DropTable(
                name: "ParkingTypes");

            migrationBuilder.DropTable(
                name: "PaymentPanels");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "RequestStatuses");
        }
    }
}
