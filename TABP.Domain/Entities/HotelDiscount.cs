namespace TABP.Domain.Entities;

public class HotelDiscount
{
    public Guid HotelDiscountId { get; set; }
    public float Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Hotel> Hotels { get; set; }
}