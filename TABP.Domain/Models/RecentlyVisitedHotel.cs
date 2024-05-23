namespace TABP.Domain.Models;

public class RecentlyVisitedHotel
{
    public Guid HotelId { get; set; }
    public string HotelName { get; set; }
    public decimal PricePaid { get; set; }
    public DateTime LastVisited { get; set; }
}