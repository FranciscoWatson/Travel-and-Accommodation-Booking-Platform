using AutoMapper;
using MediatR;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Queries.Rooms;
using TABP.Application.Responses;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdQuery, Result<RoomForAdminResponseDto>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetRoomByIdHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<Result<RoomForAdminResponseDto>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAdminAsync(request.RoomId);
        return room == null ? 
            Result<RoomForAdminResponseDto>.Fail("Room not found.") 
            : Result<RoomForAdminResponseDto>.Success(_mapper.Map<RoomForAdminResponseDto>(room));
    }
}