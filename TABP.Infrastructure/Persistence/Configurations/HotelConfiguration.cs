using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.Property(h => h.HotelId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        
        builder.Property(h => h.Name).HasMaxLength(100);
        builder.Property(h => h.Description).HasMaxLength(500);
        builder.Property(h => h.PhoneNumber).HasMaxLength(15);
        builder.Property(h => h.Email).HasMaxLength(100);
        builder.Property(h => h.Address).HasMaxLength(300);
        builder.Property(h => h.Latitude).HasMaxLength(50);
        builder.Property(h => h.Longitude).HasMaxLength(50);
        builder.Property(h => h.ThumbnailUrl).HasMaxLength(500);
    }
}