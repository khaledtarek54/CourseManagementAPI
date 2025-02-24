using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManagementAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 23, 21, 56, 51, 876, DateTimeKind.Utc).AddTicks(4138), "Learn C# from scratch", 0, "C# Basics", 0m },
                    { 2, new DateTime(2025, 2, 23, 21, 56, 51, 876, DateTimeKind.Utc).AddTicks(4892), "Master building APIs with .NET", 0, "ASP.NET Core", 0m }
                });
        }
    }
}
