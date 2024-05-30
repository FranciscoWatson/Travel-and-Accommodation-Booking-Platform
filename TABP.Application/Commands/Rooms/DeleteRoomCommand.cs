using MediatR;

namespace TABP.Application.Commands.Rooms;

public class DeleteRoomCommand : IRequest
{
    public Guid RoomId { get; set; }
}