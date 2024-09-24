using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Trainees",
                newName: "address");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Computer Science" },
                    { 2, 2, "Mathematics" },
                    { 3, 3, "Physics" },
                    { 4, 4, "Chemistry" },
                    { 5, 5, "Biology" },
                    { 6, 6, "Business" },
                    { 7, 7, "Economics" },
                    { 8, 8, "Electrical Engineering" },
                    { 9, 9, "Mechanical Engineering" },
                    { 10, 10, "Civil Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DepartmentId", "DepartmentId1", "ImageURL", "Name", "Salary", "address" },
                values: new object[,]
                {
                    { 1, 1, null, "alice.jpg", "Alice Johnson", 75000.0, "123 Main St" },
                    { 2, 2, null, "bob.jpg", "Bob Smith", 80000.0, "456 High St" },
                    { 3, 3, null, "catherine.jpg", "Catherine Williams", 82000.0, "789 Elm St" },
                    { 4, 4, null, "david.jpg", "David Johnson", 78000.0, "321 Maple Ave" },
                    { 5, 5, null, "emily.jpg", "Emily Davis", 76000.0, "654 Pine St" },
                    { 6, 6, null, "frank.jpg", "Frank Miller", 90000.0, "987 Oak St" },
                    { 7, 7, null, "grace.jpg", "Grace Lee", 85000.0, "111 Cedar St" },
                    { 8, 8, null, "henry.jpg", "Henry Brown", 88000.0, "222 Birch St" },
                    { 9, 9, null, "isabelle.jpg", "Isabelle Wilson", 86000.0, "333 Spruce St" },
                    { 10, 10, null, "jack.jpg", "Jack Thomas", 92000.0, "444 Ash St" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "DepartmentId", "ImageUrl", "Name", "address" },
                values: new object[,]
                {
                    { 1, 1, "john.jpg", "John Doe", "101 Apple St" },
                    { 2, 2, "jane.jpg", "Jane Smith", "102 Orange St" },
                    { 3, 3, "samuel.jpg", "Samuel Green", "103 Banana St" },
                    { 4, 4, "natalie.jpg", "Natalie Brown", "104 Peach St" },
                    { 5, 5, "michael.jpg", "Michael Johnson", "105 Grape St" },
                    { 6, 6, "sophia.jpg", "Sophia Lee", "106 Plum St" },
                    { 7, 7, "william.jpg", "William Martinez", "107 Pear St" },
                    { 8, 8, "olivia.jpg", "Olivia Anderson", "108 Cherry St" },
                    { 9, 9, "ethan.jpg", "Ethan Scott", "109 Kiwi St" },
                    { 10, 10, "emma.jpg", "Emma Davis", "110 Mango St" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "DepartmentId", "InstructorId", "MinDegree", "Name", "TotalHours" },
                values: new object[,]
                {
                    { 1, 100, 1, 1, 50, "Intro to Programming", 40 },
                    { 2, 100, 1, 1, 60, "Data Structures", 45 },
                    { 3, 100, 1, 1, 65, "Algorithms", 50 },
                    { 4, 100, 2, 2, 55, "Linear Algebra", 40 },
                    { 5, 100, 2, 2, 50, "Calculus I", 42 },
                    { 6, 100, 3, 3, 60, "Quantum Mechanics", 45 },
                    { 7, 100, 4, 4, 65, "Thermodynamics", 50 },
                    { 8, 100, 4, 4, 55, "Organic Chemistry", 40 },
                    { 9, 100, 6, 6, 50, "Business Strategy", 42 },
                    { 10, 100, 6, 6, 60, "Financial Accounting", 45 }
                });

            migrationBuilder.InsertData(
                table: "CourseResult",
                columns: new[] { "Id", "CourseId", "Grade", "GradeDate", "GradeLetter", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 90.5m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8358), "A", 1 },
                    { 2, 2, 85.0m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8495), "B", 2 },
                    { 3, 3, 78.5m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8510), "C", 3 },
                    { 4, 4, 88.0m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8523), "B", 4 },
                    { 5, 5, 92.5m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8535), "A", 5 },
                    { 6, 6, 80.0m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8547), "B", 6 },
                    { 7, 7, 74.5m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8559), "C", 7 },
                    { 8, 8, 89.0m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8571), "B", 8 },
                    { 9, 9, 95.0m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8582), "A", 9 },
                    { 10, 10, 91.5m, new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8595), "A", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 10);

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
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trainees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

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
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Trainees",
                newName: "Address");
        }
    }
}
