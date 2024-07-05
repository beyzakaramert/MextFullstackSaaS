using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConversationIdFieldsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "UserPayments");

            migrationBuilder.AddColumn<string>(
                name: "ConversationId",
                table: "UserPaymentHistories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1d4a56e-557a-4e60-9a1a-7c6e5a6b9004", "AQAAAAIAAYagAAAAEBe5QmCTT5Cw7YFRbF2B5a563GGP+Hf4nQgGz1K1d5NmiJWzas7doZW+ovJ1lossAw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "UserPaymentHistories");

            migrationBuilder.AddColumn<string>(
                name: "ConversationId",
                table: "UserPayments",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0419bb61-604e-4097-938e-a015c0d97b67", "AQAAAAIAAYagAAAAEJPlr8y6qhqGINN69qv/jMDgo0/ifgnYSU+RqkrFjCPTJCj2bJ16R23+/UG97chKIA==" });
        }
    }
}
