using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sam.CarInfo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarMake",
                columns: table => new
                {
                    CarMakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarMakeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMake", x => x.CarMakeId);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    CarModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarModelName = table.Column<string>(nullable: true),
                    CarMakeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.CarModelId);
                    table.ForeignKey(
                        name: "FK_CarModel_CarMake_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "CarMake",
                        principalColumn: "CarMakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarModelId = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageBase64 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_CarModel_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModel",
                        principalColumn: "CarModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarMake",
                columns: new[] { "CarMakeId", "CarMakeName" },
                values: new object[] { 1, "Ford" });

            migrationBuilder.InsertData(
                table: "CarMake",
                columns: new[] { "CarMakeId", "CarMakeName" },
                values: new object[] { 2, "Tesla" });

            migrationBuilder.InsertData(
                table: "CarMake",
                columns: new[] { "CarMakeId", "CarMakeName" },
                values: new object[] { 3, "Honda" });

            migrationBuilder.InsertData(
                table: "CarModel",
                columns: new[] { "CarModelId", "CarMakeId", "CarModelName" },
                values: new object[,]
                {
                    { 1, 1, "F-150" },
                    { 2, 1, "Fusion" },
                    { 3, 1, "Escape" },
                    { 4, 2, "Model S" },
                    { 5, 2, "Model 3" },
                    { 6, 3, "C-RV" },
                    { 7, 3, "Explorer" },
                    { 8, 3, "Accord" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarModelId",
                table: "Car",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_CarMakeId",
                table: "CarModel",
                column: "CarMakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "CarMake");
        }
    }
}
