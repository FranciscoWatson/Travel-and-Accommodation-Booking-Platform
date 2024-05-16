using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class RoomDiscountConfiguration : IEntityTypeConfiguration<RoomDiscount>
{
    public void Configure(EntityTypeBuilder<RoomDiscount> builder)
    {
        builder.Property(rd => rd.RoomDiscountId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        
        builder.Property(rd => rd.StartDate).HasColumnType("datetime2");
        builder.Property(rd => rd.EndDate).HasColumnType("datetime2");
    }
}