using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class HotelDiscountConfiguration : IEntityTypeConfiguration<HotelDiscount>
{
    public void Configure(EntityTypeBuilder<HotelDiscount> builder)
    {
        builder.Property(hd => hd.HotelDiscountId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        builder.Property(hd => hd.StartDate).HasColumnType("datetime2");
        builder.Property(hd => hd.EndDate).HasColumnType("datetime2");
    }
}