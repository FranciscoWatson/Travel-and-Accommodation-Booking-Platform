using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class BookingRoomConfiguration : IEntityTypeConfiguration<BookingRoom>
{
    public void Configure(EntityTypeBuilder<BookingRoom> builder)
    {
        builder.ToTable("BookingRoom");

        builder.HasKey(e => new { e.BookingId, e.RoomId });

        builder.HasOne(br => br.Booking)
            .WithMany(b => b.BookingRooms)
            .HasForeignKey(br => br.BookingId);

        builder.HasOne(br => br.Room)
            .WithMany(r => r.BookingRooms)
            .HasForeignKey(br => br.RoomId);

        builder.Property(br => br.BookingId).HasColumnName("BookingId");
        builder.Property(br => br.RoomId).HasColumnName("RoomId");
    }
}