using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore03.Migrations
{
    /// <inheritdoc />
    public partial class SeedStaticData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, null, "Programming", null },
                    { 2, null, "Design", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinedAt" },
                values: new object[,]
                {
                    { 1, "Backend Instructor", "ahmed@example.com", "Ahmed Hassan", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Programming Instructor", "mona@example.com", "Mona Ali", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "omar@example.com", "Omar Samir", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 3, null, "Backend", 1 },
                    { 4, null, "Frontend", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedAt", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Learn C# basics", 1, true, "Beginner", 500m, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals" },
                    { 6, 2, "Design principles", 3, false, "Beginner", 550m, null, "UI Design Basics" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 5, null, "ASP.NET", 3 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedAt", "Title" },
                values: new object[,]
                {
                    { 2, 3, "Object oriented programming", 1, true, "Intermediate", 650m, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "OOP with C#" },
                    { 4, 4, "Web foundations", 2, true, "Beginner", 400m, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML and CSS" },
                    { 5, 3, "Database querying", 3, false, "Advanced", 750m, null, "Advanced SQL" },
                    { 3, 5, "Build APIs", 2, true, "Advanced", 900m, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
