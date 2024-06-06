using AutoMapper;
using MediatR;
using TABP.Application.Commands.Rooms;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Rooms;

public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, Result<object>>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<Result<object>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId);
        if (room == null)
        {
            return Result<object>.Fail("Room not found.");
        }
        await _roomRepository.DeleteAsync(request.RoomId);
        return Result<object>.Success();
    }
}