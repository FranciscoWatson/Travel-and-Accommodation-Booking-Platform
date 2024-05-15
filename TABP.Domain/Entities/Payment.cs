﻿using TABP.Domain.Enums;

namespace TABP.Domain.Entities;

public class Payment
{
    public Guid PaymentId { get; set; }
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime? PaymentDate { get; set; }
}