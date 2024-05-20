using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class RoomRoomImageConfiguration : IEntityTypeConfiguration<RoomRoomImage>
{
    public void Configure(EntityTypeBuilder<RoomRoomImage> builder)
    {
        builder.ToTable("RoomRoomImage");

        builder.HasKey(e => new { e.RoomId, e.RoomImageId });

        builder.HasOne(rri => rri.Room)
            .WithMany(r => r.RoomRoomImages)
            .HasForeignKey(rri => rri.RoomId);

        builder.HasOne(rri => rri.RoomImage)
            .WithMany(ri => ri.RoomRoomImages)
            .HasForeignKey(rri => rri.RoomImageId);

        builder.Property(rri => rri.RoomId).HasColumnName("RoomId");
        builder.Property(rri => rri.RoomImageId).HasColumnName("RoomImageId");
    }
    
}