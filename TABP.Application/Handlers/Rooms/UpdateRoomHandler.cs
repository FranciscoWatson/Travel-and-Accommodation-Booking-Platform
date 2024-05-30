using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public UpdateRoomHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId);
        if (room == null)
        {
            throw new ApplicationException($"Room with id {request.RoomId} not found.");
        }

        _mapper.Map(request, room);

        await _roomRepository.UpdateAsync(room);
    }
}

