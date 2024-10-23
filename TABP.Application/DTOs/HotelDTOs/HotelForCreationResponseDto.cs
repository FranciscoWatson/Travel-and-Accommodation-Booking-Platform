namespace TABP.Application.DTOs.HotelDTOs;

public class HotelForCreationResponseDto
{
    public Guid HotelId { get; set; }
    public Guid CityId { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public float StarRating { get; set; }
    public string Address { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string? ThumbnailUrl { get; set; }
}