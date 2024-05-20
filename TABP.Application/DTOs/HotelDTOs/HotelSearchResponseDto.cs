using TABP.Domain.Entities;

namespace TABP.Application.DTOs.HotelDTOs;

public class HotelSearchResponseDto
{
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public float StarRating { get; set; }
    public string CityName { get; set; }
    public List<Amenity> Amenities { get; set; }
    public List<HotelImage> HotelImages { get; set; }
}