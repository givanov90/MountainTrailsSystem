using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class TrailStatusNotesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrailStatusNotes",
                columns: table => new
                {
                    TrailStatusNoteId = table.Column<int>(type: "int", nullable: false, comment: "TrailStatusNote identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of the updated trail status"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image verifying the updated trail status"),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false, comment: "Flag showing if the given note is resolved"),
                    TrailId = table.Column<int>(type: "int", nullable: false, comment: "Trail identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailStatusNotes", x => x.TrailStatusNoteId);
                    table.ForeignKey(
                        name: "FK_TrailStatusNotes_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Request for update of the trail status");

            migrationBuilder.CreateIndex(
                name: "IX_TrailStatusNotes_TrailId",
                table: "TrailStatusNotes",
                column: "TrailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailStatusNotes");
        }
    }
}
