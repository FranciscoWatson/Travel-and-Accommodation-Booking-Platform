using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelHotelDiscount");

            migrationBuilder.DropTable(
                name: "RoomRoomDiscount");

            migrationBuilder.DropTable(
                name: "HotelDiscounts");

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "RoomDiscounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomTypeId",
                table: "RoomDiscounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RoomDiscounts_RoomId",
                table: "RoomDiscounts",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDiscounts_RoomTypeId",
                table: "RoomDiscounts",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDiscounts_RoomTypes_RoomTypeId",
                table: "RoomDiscounts",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDiscounts_Rooms_RoomId",
                table: "RoomDiscounts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDiscounts_RoomTypes_RoomTypeId",
                table: "RoomDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomDiscounts_Rooms_RoomId",
                table: "RoomDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_RoomDiscounts_RoomId",
                table: "RoomDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_RoomDiscounts_RoomTypeId",
                table: "RoomDiscounts");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomDiscounts");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "RoomDiscounts");

            migrationBuilder.CreateTable(
                name: "HotelDiscounts",
                columns: table => new
                {
                    HotelDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDiscounts", x => x.HotelDiscountId);
                });

            migrationBuilder.CreateTable(
                name: "RoomRoomDiscount",
                columns: table => new
                {
                    RoomDiscountsRoomDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomsRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRoomDiscount", x => new { x.RoomDiscountsRoomDiscountId, x.RoomsRoomId });
                    table.ForeignKey(
                        name: "FK_RoomRoomDiscount_RoomDiscounts_RoomDiscountsRoomDiscountId",
                        column: x => x.RoomDiscountsRoomDiscountId,
                        principalTable: "RoomDiscounts",
                        principalColumn: "RoomDiscountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRoomDiscount_Rooms_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelHotelDiscount",
                columns: table => new
                {
                    HotelDiscountsHotelDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelsHotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelHotelDiscount", x => new { x.HotelDiscountsHotelDiscountId, x.HotelsHotelId });
                    table.ForeignKey(
                        name: "FK_HotelHotelDiscount_HotelDiscounts_HotelDiscountsHotelDiscountId",
                        column: x => x.HotelDiscountsHotelDiscountId,
                        principalTable: "HotelDiscounts",
                        principalColumn: "HotelDiscountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelHotelDiscount_Hotels_HotelsHotelId",
                        column: x => x.HotelsHotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelHotelDiscount_HotelsHotelId",
                table: "HotelHotelDiscount",
                column: "HotelsHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRoomDiscount_RoomsRoomId",
                table: "RoomRoomDiscount",
                column: "RoomsRoomId");
        }
    }
}
