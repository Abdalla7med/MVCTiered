using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removeInstrcutorDepartmentUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors");

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 1,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 2,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 4,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 5,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 6,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 7,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 8,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 9,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 10,
                column: "GradeDate",
                value: new DateTime(2024, 9, 24, 23, 41, 27, 346, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors");

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 1,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 2,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 3,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 4,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 5,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 6,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 7,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 8,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 9,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "CourseResult",
                keyColumn: "Id",
                keyValue: 10,
                column: "GradeDate",
                value: new DateTime(2024, 9, 23, 23, 35, 13, 317, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                unique: true,
                filter: "[DepartmentId] IS NOT NULL");
        }
    }
}
