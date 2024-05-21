using MediatR;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Queries.Hotels;

public class SearchAndFilterHotelsQuery : IRequest<List<HotelSearchResponseDto>>
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
}