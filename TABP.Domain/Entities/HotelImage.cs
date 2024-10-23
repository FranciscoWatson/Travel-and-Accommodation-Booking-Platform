namespace TABP.Domain.Entities;

public class HotelImage
{
    public Guid HotelImageId { get; set; }
    public Guid HotelId { get; set; }
    public string Url { get; set; }
}