using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class UserTrailConstraintAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersTrails_AspNetUsers_ApplicationUserId",
                table: "UsersTrails");

            migrationBuilder.DropIndex(
                name: "IX_UsersTrails_ApplicationUserId",
                table: "UsersTrails");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UsersTrails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0403ab4a-18c4-4bf3-8112-89daaf2364d7", "AQAAAAEAACcQAAAAEGFpSQnksu0dv0XMQ7Zsl/W2hqGlxbDvyAg9vlLG+Lra8wshXtbzYmmEr1V2vD9afg==", "bc43523f-4aff-40f6-b350-eb9b94623488" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UsersTrails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec8bf2f0-9352-4884-806a-6eb4d170d5dd", "AQAAAAEAACcQAAAAEKhbL4gwZ4zz3YoIiQ5yuVFgR5JfBvJPqVSQbHZBWAgNvr2Cd0QyH1KI3rSOrX8aWg==", "bbc0b20b-7579-46e1-81af-4443ad03f924" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersTrails_ApplicationUserId",
                table: "UsersTrails",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTrails_AspNetUsers_ApplicationUserId",
                table: "UsersTrails",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
