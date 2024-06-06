using MediatR;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Rooms;

public class CreateRoomCommand : IRequest<Result<RoomForCreationResponseDto>>
{
    public Guid RoomTypeId { get; set; }
    public int RoomNumber { get; set; }
}