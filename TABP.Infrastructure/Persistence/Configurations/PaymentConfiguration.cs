﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistance.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(p => p.PaymentId)
            .HasDefaultValueSql("NEWID()")
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Amount)
            .HasColumnType("decimal(18,2)");
    }
}