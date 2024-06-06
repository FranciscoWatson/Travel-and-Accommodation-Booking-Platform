using MediatR;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Queries.Rooms;

public class GetRoomByIdQuery : IRequest<Result<RoomForAdminResponseDto>>
{
    public Guid RoomId { get; init; }
}