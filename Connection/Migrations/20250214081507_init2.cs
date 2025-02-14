using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connection.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CategoryId", "CityId", "CustomerId", "SetAt", "Status", "Title", "WantedPrice", "WantedTime" },
                values: new object[] { 1, 9, 3, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "درخواست برای کاغذ دیواری خانه", 10000, new DateTime(2025, 12, 12, 10, 12, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
