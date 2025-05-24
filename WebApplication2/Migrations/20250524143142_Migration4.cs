using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateOnly(2000, 8, 10), new DateOnly(2001, 1, 1) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateOnly(2001, 5, 12), new DateOnly(2001, 5, 31) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateOnly(2002, 3, 11), new DateOnly(2003, 9, 27) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateOnly(2007, 4, 14), new DateOnly(2008, 2, 29) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2000, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2002, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2007, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
