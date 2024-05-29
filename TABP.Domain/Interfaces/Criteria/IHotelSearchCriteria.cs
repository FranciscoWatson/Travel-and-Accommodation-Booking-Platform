namespace TABP.Domain.Interfaces.Criteria;

public interface IHotelSearchCriteria
{
    DateTime CheckIn { get; }
    DateTime CheckOut { get; }
    int NumberOfAdults { get; }
    int NumberOfChildren { get; }
    int NumberOfRooms { get; }
    string? RoomType { get; }
    string? HotelName { get; }
    string? City { get; }
    decimal? MaxPrice { get; }
    int? MinRating { get; }
    List<Guid>? Amenities { get; }
}