using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2000, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1998, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1986, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Patients",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateOnly(2000, 8, 10));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateOnly(1998, 5, 24));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "BirthDate",
                value: new DateOnly(1986, 12, 1));
        }
    }
}
