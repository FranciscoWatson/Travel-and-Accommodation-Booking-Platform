using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Users;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Users;

public class GetRecentlyVisitedHotelsHandler : IRequestHandler<GetRecentlyVisitedHotelsQuery, Result<List<RecentlyVisitedHotelResponseDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetRecentlyVisitedHotelsHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<RecentlyVisitedHotelResponseDto>>> Handle(GetRecentlyVisitedHotelsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return Result<List<RecentlyVisitedHotelResponseDto>>.Fail("User not found.");
        }
        var recentlyVisitedHotels = await _userRepository.GetRecentlyVisitedHotelsAsync(request.UserId, request.Count);
        return Result<List<RecentlyVisitedHotelResponseDto>>.Success(_mapper.Map<List<RecentlyVisitedHotelResponseDto>>(recentlyVisitedHotels));
    }
}