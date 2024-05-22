namespace TABP.Domain.Entities;

public class Hotel : AuditableEntity
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
    
    public City City { get; set; }
    public Owner Owner { get; set; }
    public List<RoomType> RoomTypes  { get; set; }
    public List<Review> Reviews { get; set; }
    public List<HotelImage> HotelImages { get; set; }
    
    public ICollection<HotelAmenity> HotelAmenities { get; set; }
}