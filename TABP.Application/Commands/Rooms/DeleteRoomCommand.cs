using MediatR;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Rooms;

public class DeleteRoomCommand : IRequest<Result<object>>
{
    public Guid RoomId { get; set; }
}