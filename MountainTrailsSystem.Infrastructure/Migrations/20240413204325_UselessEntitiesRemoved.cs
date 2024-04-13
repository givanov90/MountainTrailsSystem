using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class UselessEntitiesRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4b7152d-b19c-4b1d-bb2c-a67538cb63ba", "AQAAAAEAACcQAAAAEKY/e//lSqpy8FPANf02zydkfOgCemPYgzTCRZh/hkg5NywjWU8LEetEJbM1p75Kcw==", "1b27be2c-8638-4634-90a6-245c7c46cc9f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false, comment: "Article identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Article description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image URL of the article"),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the article is published"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Article title")
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
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false, comment: "Event description"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the event ends"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the event starts"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Event title")
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a38342c3-8dbd-46da-8f6f-160b7dc7e1e6", "AQAAAAEAACcQAAAAEOkzyni18YISaBpI576gEa+DcOxCXwtcSGmAYsuB5raXqTk446sp61AepturtCmg7w==", "0d1f2647-f784-4a6e-abfe-c4e345fc293b" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId");
        }
    }
}
