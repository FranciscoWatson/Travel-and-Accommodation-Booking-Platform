using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.Property(b => b.PriceAtBooking)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(b => b.BookingId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
    }
}