using TABP.Domain.Entities;

namespace TABP.Domain.Models;

public class HotelSearch
{
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public string? ThumbnailUrl { get; set; }
    public float StarRating { get; set; }
    public decimal AveragePricePerNight { get; set; }
    public string Description { get; set; }
    public string CityName { get; set; }
    public List<Amenity> Amenities { get; set; }
    public List<HotelImage> HotelImages { get; set; }
}