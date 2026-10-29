using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment10._3.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVinToLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    GarageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.GarageID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VIN = table.Column<long>(type: "bigint", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    GarageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Cars_Garages_GarageID",
                        column: x => x.GarageID,
                        principalTable: "Garages",
                        principalColumn: "GarageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "GarageID", "Location" },
                values: new object[,]
                {
                    { 1, "WA" },
                    { 2, "CA" },
                    { 3, "NY" },
                    { 4, "FL" },
                    { 5, "TX" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "VIN", "GarageID", "Make", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 11111111L, 1, "Bugatti", "Chiron", 3000000.0, 2022 },
                    { 22222222L, 1, "Rolls-Royce", "Phantom", 500000.0, 2023 },
                    { 33333333L, 2, "Lamborghini", "Aventador", 450000.0, 2021 },
                    { 44444444L, 2, "Ferrari", "F40", 2500000.0, 2023 },
                    { 55555555L, 3, "Bentley", "Continental GT", 250000.0, 2024 },
                    { 66666666L, 3, "McLaren", "P1", 1800000.0, 2022 },
                    { 77777777L, 4, "Porsche", "911GT3 ", 200000.0, 2023 },
                    { 88888888L, 5, "Aston Martin", "DBS", 330000.0, 2022 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GarageID",
                table: "Cars",
                column: "GarageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Garages");
        }
    }
}
