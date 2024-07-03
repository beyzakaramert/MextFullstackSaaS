using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfileImageFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfileImage" },
                values: new object[] { "a746c849-33b7-424a-9753-3c3e4b24e715", "AQAAAAIAAYagAAAAEF++9E/Q6Wh80KdamIQ7mXcUOQGVcbMisR99JI19RaDPYMmOlydzSeDrVCFUW39Adg==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1fe28f33-5e9d-42ff-b293-8c17e188866a", "AQAAAAIAAYagAAAAEOD8OwRUVinR8bVxnb077Wpk6/Avs3b23pewUbkNl9QuQqNuMjgsDFnV1fhidcDxFQ==" });
        }
    }
}
