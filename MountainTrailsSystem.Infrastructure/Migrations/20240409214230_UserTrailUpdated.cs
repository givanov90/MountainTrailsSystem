using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MountainTrailsSystem.Infrastructure.Migrations
{
    public partial class UserTrailUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSaved",
                table: "UsersTrails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is trail saved by user");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisited",
                table: "UsersTrails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is trail visited by user");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec8bf2f0-9352-4884-806a-6eb4d170d5dd", "AQAAAAEAACcQAAAAEKhbL4gwZ4zz3YoIiQ5yuVFgR5JfBvJPqVSQbHZBWAgNvr2Cd0QyH1KI3rSOrX8aWg==", "bbc0b20b-7579-46e1-81af-4443ad03f924" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaved",
                table: "UsersTrails");

            migrationBuilder.DropColumn(
                name: "IsVisited",
                table: "UsersTrails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3483b5-6152-4b74-a0fe-00fc4a0a77a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a74805-4ea3-47e3-91b4-b9e9e8549bde", "AQAAAAEAACcQAAAAEFPkST1x5V8oCZDgrWHS0MKAQ3693QUhOjgIbhPJWcPAXqan0U6TYrK5PLSS7ftG8Q==", "965b7793-d8a9-4303-9b95-6a9ac93754ae" });
        }
    }
}
