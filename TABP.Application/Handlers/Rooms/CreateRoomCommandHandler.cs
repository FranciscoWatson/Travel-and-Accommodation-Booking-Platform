using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Responses;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result<RoomForCreationResponseDto>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper, IRoomTypeRepository roomTypeRepository)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _roomTypeRepository = roomTypeRepository;
    }

    public async Task<Result<RoomForCreationResponseDto>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var roomTypeExists = await _roomTypeRepository.ExistsAsync(request.RoomTypeId);
        if (!roomTypeExists)
        {
            return Result<RoomForCreationResponseDto>.Fail("Room type not found.");
        }
        var room = _mapper.Map<Room>(request);

        var createdRoom = await _roomRepository.CreateAsync(room);
        
        return Result<RoomForCreationResponseDto>.Success(_mapper.Map<RoomForCreationResponseDto>(createdRoom));
    }
}