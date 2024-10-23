using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoomIdFromRoomDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDiscounts_Rooms_RoomId",
                table: "RoomDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_RoomDiscounts_RoomId",
                table: "RoomDiscounts");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomDiscounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "RoomDiscounts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RoomDiscounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "RoomDiscounts");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "RoomDiscounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomDiscounts_RoomId",
                table: "RoomDiscounts",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDiscounts_Rooms_RoomId",
                table: "RoomDiscounts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }
    }
}
