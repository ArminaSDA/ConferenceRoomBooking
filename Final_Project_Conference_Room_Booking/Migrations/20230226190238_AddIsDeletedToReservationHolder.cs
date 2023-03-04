using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project_Conference_Room_Booking.Migrations
{
    public partial class AddIsDeletedToReservationHolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReservationHolder",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReservationHolder");
        }
    }
}
