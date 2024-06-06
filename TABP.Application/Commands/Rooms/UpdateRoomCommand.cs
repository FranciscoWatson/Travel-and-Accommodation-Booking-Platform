using MediatR;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Rooms;

public class UpdateRoomCommand : IRequest<Result<object>>
{
    public Guid RoomId { get; init; }
    public Guid RoomTypeId { get; set; }
    public int RoomNumber { get; set; }
}