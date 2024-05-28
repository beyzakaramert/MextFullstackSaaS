using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderDescriptionFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1fe28f33-5e9d-42ff-b293-8c17e188866a", "AQAAAAIAAYagAAAAEOD8OwRUVinR8bVxnb077Wpk6/Avs3b23pewUbkNl9QuQqNuMjgsDFnV1fhidcDxFQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af0ab31d-e400-44ce-b791-fc81881e400a", "AQAAAAIAAYagAAAAEEXAKchjVdn0aRi26jdR48GaFCTHXHVo6I/KEHHYem2mjlciK5VGfTU+l5poLawSiw==" });
        }
    }
}
