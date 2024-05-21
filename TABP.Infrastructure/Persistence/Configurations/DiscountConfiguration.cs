using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.Property(rd => rd.DiscountId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        
        builder.Property(rd => rd.StartDate).HasColumnType("datetime2");
        builder.Property(rd => rd.EndDate).HasColumnType("datetime2");
    }
}