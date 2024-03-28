using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class ConnectionBetweenMountainsAndRegionsDefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mountains_Regions_RegionId",
                table: "Mountains");

            migrationBuilder.DropIndex(
                name: "IX_Mountains_RegionId",
                table: "Mountains");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Mountains");

            migrationBuilder.CreateTable(
                name: "MountainsRegions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false, comment: "Region identifier"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Mountain identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainsRegions", x => new { x.RegionId, x.MountainId });
                    table.ForeignKey(
                        name: "FK_MountainsRegions_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MountainsRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Connection between mountain and region entities");

            migrationBuilder.CreateIndex(
                name: "IX_MountainsRegions_MountainId",
                table: "MountainsRegions",
                column: "MountainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MountainsRegions");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Mountains",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Region identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Mountains_RegionId",
                table: "Mountains",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mountains_Regions_RegionId",
                table: "Mountains",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
