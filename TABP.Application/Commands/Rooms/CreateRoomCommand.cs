using MediatR;
using TABP.Application.DTOs.RoomDTOs;

namespace TABP.Application.Commands.Rooms;

public class CreateRoomCommand : IRequest<RoomForCreationResponseDto>
{
    public Guid RoomTypeId { get; set; }
    public int RoomNumber { get; set; }
}