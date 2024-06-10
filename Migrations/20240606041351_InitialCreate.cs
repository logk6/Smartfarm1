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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CO2 = table.Column<int>(type: "int", nullable: false),
                    SoilMoisture = table.Column<int>(type: "int", nullable: false),
                    Light_0x5C = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmStatus", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmStatus");
        }
    }
}
