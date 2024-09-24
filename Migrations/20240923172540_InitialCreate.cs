using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smartfarm1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmStatus",
                columns: table => new
                {
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SFID = table.Column<int>(type: "int", nullable: false),
                    CO2 = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture = table.Column<int>(type: "int", nullable: false),
                    Light_0x5C = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmStatus", x => x.DateTime);
                });

            migrationBuilder.CreateTable(
                name: "FarmStatusNow",
                columns: table => new
                {
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SFID = table.Column<int>(type: "int", nullable: false),
                    CO2 = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture = table.Column<int>(type: "int", nullable: false),
                    Light_0x5C = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmStatusNow", x => x.DateTime);
                });

            migrationBuilder.CreateTable(
                name: "Smartfarm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartfarm", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmStatus");

            migrationBuilder.DropTable(
                name: "FarmStatusNow");

            migrationBuilder.DropTable(
                name: "Smartfarm");
        }
    }
}
