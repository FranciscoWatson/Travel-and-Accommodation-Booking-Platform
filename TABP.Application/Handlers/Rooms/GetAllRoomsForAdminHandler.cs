using AutoMapper;
using MediatR;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Queries.Rooms;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class GetAllRoomsForAdminHandler : IRequestHandler<GetAllRoomsForAdminQuery, IEnumerable<RoomForAdminResponseDto>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetAllRoomsForAdminHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoomForAdminResponseDto>> Handle(GetAllRoomsForAdminQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _roomRepository.GetAllForAdminAsync();
        
        return _mapper.Map<IEnumerable<RoomForAdminResponseDto>>(hotels);
    }
}