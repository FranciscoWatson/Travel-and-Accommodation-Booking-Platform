using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJoinTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoom_Bookings_BookingsBookingId",
                table: "BookingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoom_Rooms_RoomsRoomId",
                table: "BookingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomRoomImage_RoomImages_RoomImagesRoomImageId",
                table: "RoomRoomImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomRoomImage_Rooms_RoomsRoomId",
                table: "RoomRoomImage");

            migrationBuilder.DropTable(
                name: "AmenityHotel");

            migrationBuilder.RenameColumn(
                name: "RoomsRoomId",
                table: "RoomRoomImage",
                newName: "RoomImageId");

            migrationBuilder.RenameColumn(
                name: "RoomImagesRoomImageId",
                table: "RoomRoomImage",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomRoomImage_RoomsRoomId",
                table: "RoomRoomImage",
                newName: "IX_RoomRoomImage_RoomImageId");

            migrationBuilder.RenameColumn(
                name: "RoomsRoomId",
                table: "BookingRoom",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "BookingsBookingId",
                table: "BookingRoom",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingRoom_RoomsRoomId",
                table: "BookingRoom",
                newName: "IX_BookingRoom_RoomId");

            migrationBuilder.CreateTable(
                name: "HotelAmenity",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmenityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenity", x => new { x.HotelId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_HotelAmenity_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelAmenity_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenity_AmenityId",
                table: "HotelAmenity",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoom_Bookings_BookingId",
                table: "BookingRoom",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoom_Rooms_RoomId",
                table: "BookingRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRoomImage_RoomImages_RoomImageId",
                table: "RoomRoomImage",
                column: "RoomImageId",
                principalTable: "RoomImages",
                principalColumn: "RoomImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRoomImage_Rooms_RoomId",
                table: "RoomRoomImage",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoom_Bookings_BookingId",
                table: "BookingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoom_Rooms_RoomId",
                table: "BookingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomRoomImage_RoomImages_RoomImageId",
                table: "RoomRoomImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomRoomImage_Rooms_RoomId",
                table: "RoomRoomImage");

            migrationBuilder.DropTable(
                name: "HotelAmenity");

            migrationBuilder.RenameColumn(
                name: "RoomImageId",
                table: "RoomRoomImage",
                newName: "RoomsRoomId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomRoomImage",
                newName: "RoomImagesRoomImageId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomRoomImage_RoomImageId",
                table: "RoomRoomImage",
                newName: "IX_RoomRoomImage_RoomsRoomId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "BookingRoom",
                newName: "RoomsRoomId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "BookingRoom",
                newName: "BookingsBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingRoom_RoomId",
                table: "BookingRoom",
                newName: "IX_BookingRoom_RoomsRoomId");

            migrationBuilder.CreateTable(
                name: "AmenityHotel",
                columns: table => new
                {
                    AmenitiesAmenityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelsHotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityHotel", x => new { x.AmenitiesAmenityId, x.HotelsHotelId });
                    table.ForeignKey(
                        name: "FK_AmenityHotel_Amenities_AmenitiesAmenityId",
                        column: x => x.AmenitiesAmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityHotel_Hotels_HotelsHotelId",
                        column: x => x.HotelsHotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityHotel_HotelsHotelId",
                table: "AmenityHotel",
                column: "HotelsHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoom_Bookings_BookingsBookingId",
                table: "BookingRoom",
                column: "BookingsBookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoom_Rooms_RoomsRoomId",
                table: "BookingRoom",
                column: "RoomsRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRoomImage_RoomImages_RoomImagesRoomImageId",
                table: "RoomRoomImage",
                column: "RoomImagesRoomImageId",
                principalTable: "RoomImages",
                principalColumn: "RoomImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomRoomImage_Rooms_RoomsRoomId",
                table: "RoomRoomImage",
                column: "RoomsRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
