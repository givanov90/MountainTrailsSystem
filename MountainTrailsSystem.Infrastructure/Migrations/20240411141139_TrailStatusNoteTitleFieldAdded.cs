using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class TrailStatusNoteTitleFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TrailStatusNotes",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                comment: "Title of the trail status note");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a38342c3-8dbd-46da-8f6f-160b7dc7e1e6", "AQAAAAEAACcQAAAAEOkzyni18YISaBpI576gEa+DcOxCXwtcSGmAYsuB5raXqTk446sp61AepturtCmg7w==", "0d1f2647-f784-4a6e-abfe-c4e345fc293b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TrailStatusNotes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0403ab4a-18c4-4bf3-8112-89daaf2364d7", "AQAAAAEAACcQAAAAEGFpSQnksu0dv0XMQ7Zsl/W2hqGlxbDvyAg9vlLG+Lra8wshXtbzYmmEr1V2vD9afg==", "bc43523f-4aff-40f6-b350-eb9b94623488" });
        }
    }
}
