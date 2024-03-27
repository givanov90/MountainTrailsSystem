using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class TrailEntitiesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false, comment: "Region identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Region name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                },
                comment: "Region entity");

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Mountain identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Mountain name"),
                    RegionId = table.Column<int>(type: "int", nullable: false, comment: "Region identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mountains_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mountain entity");

            migrationBuilder.CreateTable(
                name: "Peaks",
                columns: table => new
                {
                    PeakId = table.Column<int>(type: "int", nullable: false, comment: "Peak identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Peak name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Peak description"),
                    Elevation = table.Column<int>(type: "int", nullable: false, comment: "Peak elevation"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image URL of the peak"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Mountain identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peaks", x => x.PeakId);
                    table.ForeignKey(
                        name: "FK_Peaks_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mountain peak");

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "int", nullable: false, comment: "Trail identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Trail name"),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false, comment: "Trail description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image URL of the trail"),
                    ElevationGain = table.Column<int>(type: "int", nullable: false, comment: "Elevation gained on the trail"),
                    Distance = table.Column<double>(type: "float", nullable: false, comment: "Distance of the trail"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Duration of the trail"),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false, comment: "Difficulty level of the trail"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of last update of the trail's actual state"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Rating of the trail"),
                    MountainId = table.Column<int>(type: "int", nullable: false, comment: "Mountain identifier"),
                    RegionId = table.Column<int>(type: "int", nullable: false, comment: "Region identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                    table.ForeignKey(
                        name: "FK_Trails_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trails_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Mountain trail");

            migrationBuilder.CreateTable(
                name: "TrailsPeaks",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "int", nullable: false, comment: "Trail identifier"),
                    PeakId = table.Column<int>(type: "int", nullable: false, comment: "Peak identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailsPeaks", x => new { x.TrailId, x.PeakId });
                    table.ForeignKey(
                        name: "FK_TrailsPeaks_Peaks_PeakId",
                        column: x => x.PeakId,
                        principalTable: "Peaks",
                        principalColumn: "PeakId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrailsPeaks_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Connection between trail and peak entities");

            migrationBuilder.CreateIndex(
                name: "IX_Mountains_RegionId",
                table: "Mountains",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Peaks_MountainId",
                table: "Peaks",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_MountainId",
                table: "Trails",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_RegionId",
                table: "Trails",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrailsPeaks_PeakId",
                table: "TrailsPeaks",
                column: "PeakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailsPeaks");

            migrationBuilder.DropTable(
                name: "Peaks");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
