using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Domain.Interfaces;
using TABP.Domain.Interfaces.Criteria;

namespace TABP.Application.Queries.Hotels;

public class SearchAndFilterHotelsQuery : IRequest<List<HotelSearchResponseDto>>, IHotelSearchCriteria
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int NumberOfAdults { get; set; }
    public int NumberOfChildren { get; set; }
    public int NumberOfRooms { get; set; }
    public string? RoomType { get; set; }
    public string? HotelName { get; set; }
    public string? City { get; set; }
    public decimal? MaxPrice { get; init; }
    public int? MinRating { get; init; }
    public List<Guid>? Amenities { get; init; }
}