using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.Property(o => o.OwnerId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        builder.Property(o => o.FirstName).HasMaxLength(50);
        builder.Property(o => o.LastName).HasMaxLength(50);
        builder.Property(o => o.Email).HasMaxLength(256).HasColumnType("varchar(256)");;
        builder.Property(o => o.PhoneNumber).HasMaxLength(20).HasColumnType("varchar(20)");
    }
}

