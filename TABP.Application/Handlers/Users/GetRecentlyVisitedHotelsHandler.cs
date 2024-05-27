using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Users;

namespace TABP.Application.Handlers.Users;

public class GetRecentlyVisitedHotelsHandler : IRequestHandler<GetRecentlyVisitedHotelsQuery, List<RecentlyVisitedHotelResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetRecentlyVisitedHotelsHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<RecentlyVisitedHotelResponseDto>> Handle(GetRecentlyVisitedHotelsQuery request, CancellationToken cancellationToken)
    {
        var recentlyVisitedHotels = await _userRepository.GetRecentlyVisitedHotelsAsync(request.UserId, request.Count);
        return _mapper.Map<List<RecentlyVisitedHotelResponseDto>>(recentlyVisitedHotels);
    }
}