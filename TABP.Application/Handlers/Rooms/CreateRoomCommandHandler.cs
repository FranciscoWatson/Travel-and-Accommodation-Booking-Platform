using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomForCreationResponseDto>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<RoomForCreationResponseDto> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = _mapper.Map<Room>(request);

        var createdRoom = await _roomRepository.CreateAsync(room);

        return _mapper.Map<RoomForCreationResponseDto>(createdRoom);
    }
}