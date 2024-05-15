using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistance.Configurations;

public class HotelDiscountConfiguration : IEntityTypeConfiguration<HotelDiscount>
{
    public void Configure(EntityTypeBuilder<HotelDiscount> builder)
    {
        builder.Property(hd => hd.HotelDiscountId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
    }
}