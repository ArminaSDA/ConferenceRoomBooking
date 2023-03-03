using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project_Conference_Room_Booking.Migrations
{
    public partial class finalprojectsunday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferenceRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnavailabilityPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ConferenceRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailabilityPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnavailabilityPeriods_ConferenceRooms",
                        column: x => x.ConferenceRoomId,
                        principalTable: "ConferenceRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmedFromId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_ConferenceRooms",
                        column: x => x.RoomId,
                        principalTable: "ConferenceRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_User",
                        column: x => x.ConfirmedFromId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationHolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationHolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationHolders_Bookings",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ConfirmedFromId",
                table: "Bookings",
                column: "ConfirmedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationHolders_BookingId",
                table: "ReservationHolders",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailabilityPeriods_ConferenceRoomId",
                table: "UnavailabilityPeriods",
                column: "ConferenceRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationHolders");

            migrationBuilder.DropTable(
                name: "UnavailabilityPeriods");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ConferenceRooms");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
