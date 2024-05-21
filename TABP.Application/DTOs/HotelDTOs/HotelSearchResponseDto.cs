using TABP.Application.DTOs.AmenityDTOs;
using TABP.Application.DTOs.HotelImageDTOs;

namespace TABP.Application.DTOs.HotelDTOs;

public class HotelSearchResponseDto
{
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public float StarRating { get; set; }
    public string CityName { get; set; }
    public List<AmenityDto> Amenities { get; set; }
    public List<HotelImageDto> HotelImages { get; set; }
}