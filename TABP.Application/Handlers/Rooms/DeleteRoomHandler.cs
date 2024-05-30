using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        await _roomRepository.DeleteAsync(request.RoomId);
    }
}