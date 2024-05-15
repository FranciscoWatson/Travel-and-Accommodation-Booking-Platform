using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistance.Configurations;

public class RoomDiscountConfiguration : IEntityTypeConfiguration<RoomDiscount>
{
    public void Configure(EntityTypeBuilder<RoomDiscount> builder)
    {
        builder.Property(rd => rd.RoomDiscountId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
    }
}