namespace TABP.Application.DTOs.HotelDTOs;

public class RecentlyVisitedHotelResponseDto
{
    public Guid HotelId { get; set; }
    public string HotelName { get; set; }
    public decimal PricePaid { get; set; }
    public DateTime LastVisited { get; set; }

}