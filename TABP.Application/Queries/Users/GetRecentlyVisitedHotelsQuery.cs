using MediatR;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Queries.Users;

public class GetRecentlyVisitedHotelsQuery : IRequest<List<RecentlyVisitedHotelResponseDto>>
{
    public int Count { get; set; }
}