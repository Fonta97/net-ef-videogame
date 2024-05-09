using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "software_houses",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    software_house_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    software_house__tax_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    software_house_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    software_house_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software_houses", x => x.HouseID);
                });

            migrationBuilder.CreateTable(
                name: "videogame",
                columns: table => new
                {
                    VideogameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    videogame_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    videogame_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    videogame_release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftwareHouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videogame", x => x.VideogameID);
                    table.ForeignKey(
                        name: "FK_videogame_software_houses_SoftwareHouseID",
                        column: x => x.SoftwareHouseID,
                        principalTable: "software_houses",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_software_houses_software_house__tax_id",
                table: "software_houses",
                column: "software_house__tax_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_videogame_SoftwareHouseID",
                table: "videogame",
                column: "SoftwareHouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videogame");

            migrationBuilder.DropTable(
                name: "software_houses");
        }
    }
}
