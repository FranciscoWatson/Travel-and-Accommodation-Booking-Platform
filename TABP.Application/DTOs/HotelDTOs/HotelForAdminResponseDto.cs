namespace TABP.Application.DTOs.HotelDTOs;

public class HotelForAdminResponseDto
{
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public float StarRating { get; set; }
    public string OwnerName { get; set; }
    public int NumberOfRooms { get; set; }
}