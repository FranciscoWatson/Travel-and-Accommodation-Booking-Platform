namespace TABP.Application.DTOs.HotelDTOs;

public class HotelSearchRequestDto
{
    public DateTime CheckIn { get; set; } = DateTime.UtcNow.Date;
    public DateTime CheckOut { get; set; } = DateTime.UtcNow.Date.AddDays(1);
    public int NumberOfAdults { get; set; } = 2;
    public int NumberOfChildren { get; set; } = 0;
    public int NumberOfRooms { get; set; } = 1;
    public string? RoomType { get; set; }
    public string? HotelName { get; set; }
    public string? City { get; set; }
    public decimal? MaxPrice { get; init; }
    public float? MinRating { get; init; }
    public List<Guid>? Amenities { get; init; }
}