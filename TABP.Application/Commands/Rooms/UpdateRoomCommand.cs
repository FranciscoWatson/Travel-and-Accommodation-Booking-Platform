using MediatR;

namespace TABP.Application.Commands.Rooms;

public class UpdateRoomCommand : IRequest
{
    public Guid RoomId { get; init; }
    public Guid RoomTypeId { get; set; }
    public int RoomNumber { get; set; }
}