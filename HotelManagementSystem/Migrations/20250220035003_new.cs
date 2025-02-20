using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationID", "CheckInDate", "CheckOutDate", "CustomerName", "RoomID", "Status" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie Brown", 3, 2 },
                    { 5, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eva Green", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "Availability", "Price", "RoomNumber", "Type" },
                values: new object[] { 4, true, 55m, "104", "Single" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationID", "CheckInDate", "CheckOutDate", "CustomerName", "RoomID", "Status" },
                values: new object[] { 4, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "David White", 4, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "Status",
                value: "Upcoming");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2,
                column: "Status",
                value: "Ongoing");
        }
    }
}
