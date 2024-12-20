using TABP.Application.DTOs.AmenityDTOs;
using TABP.Application.DTOs.HotelImageDTOs;
using TABP.Application.DTOs.ReviewDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.DTOs.HotelDTOs;

public class HotelFullDetailsDto
{
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public float StarRating { get; set; }
    public string Address { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string CityName { get; set; }
    public string OwnerName { get; set; }
    
    public List<AmenityDto> Amenities { get; set; }
    public List<ReviewDto> Reviews { get; set; }
    public List<HotelImageDto> HotelImages { get; set; }
    
}