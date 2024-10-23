namespace TABP.Domain.Models;

public record FeaturedDeal
{
    public Guid HotelId { get; set; }
    public string HotelName { get; set; }
    public string CityName { get; set; }
    public float StarRating { get; set; }
    public string? ThumbnailUrl { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    public float DiscountPercentage { get; set; }
}