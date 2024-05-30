using MediatR;
using TABP.Application.DTOs.RoomDTOs;

namespace TABP.Application.Queries.Rooms;

public class GetRoomByIdQuery : IRequest<RoomForAdminResponseDto>
{
    public Guid RoomId { get; init; }
}