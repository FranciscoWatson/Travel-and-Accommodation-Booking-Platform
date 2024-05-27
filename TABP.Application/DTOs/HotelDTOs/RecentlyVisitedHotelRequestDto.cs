namespace TABP.Application.DTOs.HotelDTOs;

public class RecentlyVisitedHotelRequestDto
{
    public Guid UserId { get; set; }
    public int Count { get; set; } = 3;
}