using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class ApplicationUserArticleEventAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false, comment: "Article identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Article title"),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Article description"),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the article is published"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image URL of the article")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                },
                comment: "News article entity");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Event identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Event title"),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false, comment: "Event description"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the event starts"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the event ends"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                },
                comment: "Event entity");

            migrationBuilder.CreateTable(
                name: "UsersTrails",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    TrailId = table.Column<int>(type: "int", nullable: false, comment: "Trail identifier"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTrails", x => new { x.UserId, x.TrailId });
                    table.ForeignKey(
                        name: "FK_UsersTrails_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersTrails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersTrails_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Connection between ApplicationUser and Trail entities");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTrails_ApplicationUserId",
                table: "UsersTrails",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTrails_TrailId",
                table: "UsersTrails",
                column: "TrailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "UsersTrails");
        }
    }
}
