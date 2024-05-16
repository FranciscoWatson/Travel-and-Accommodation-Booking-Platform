using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
{
    public void Configure(EntityTypeBuilder<HotelImage> builder)
    {
        builder.Property(hi => hi.HotelImageId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        builder.Property(hi => hi.Url).HasMaxLength(500);
    }
}