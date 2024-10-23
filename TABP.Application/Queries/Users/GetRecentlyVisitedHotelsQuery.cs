using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Queries.Users;

public class GetRecentlyVisitedHotelsQuery : IRequest<Result<List<RecentlyVisitedHotelResponseDto>>>
{
    public Guid UserId { get; set; }
    public int Count { get; set; }
}