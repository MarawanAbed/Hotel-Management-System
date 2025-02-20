using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class newseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Name", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, "John Doe", "Manager", 5000m },
                    { 2, "Jane Smith", "Receptionist", 3000m },
                    { 3, "Mike Johnson", "Housekeeping", 2500m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "Availability", "Price", "RoomNumber", "Type" },
                values: new object[,]
                {
                    { 1, true, 50m, "101", "Single" },
                    { 2, false, 80m, "102", "Double" },
                    { 3, true, 150m, "103", "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationID", "CheckInDate", "CheckOutDate", "CustomerName", "RoomID", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", 2, "Upcoming" },
                    { 2, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Williams", 1, "Ongoing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 2);
        }
    }
}
