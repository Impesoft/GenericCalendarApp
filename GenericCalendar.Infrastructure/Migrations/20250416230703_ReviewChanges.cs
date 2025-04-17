using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericCalendar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReviewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                column: "Type",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                column: "Type",
                value: 1);
        }
    }
}
