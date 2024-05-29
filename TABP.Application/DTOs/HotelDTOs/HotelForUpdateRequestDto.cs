namespace TABP.Application.DTOs.HotelDTOs;

public class HotelForUpdateRequestDto
{
    public string Name { get; set; }
    public Guid CityId { get; set; }
    public Guid OwnerId { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}