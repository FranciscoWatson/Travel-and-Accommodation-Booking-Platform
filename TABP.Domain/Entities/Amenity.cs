namespace TABP.Domain.Entities;

public class Amenity
{
    public Guid AmenityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<HotelAmenity> HotelAmenities { get; set; }

}