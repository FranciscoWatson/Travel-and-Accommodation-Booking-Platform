using MediatR;
using TABP.Application.DTOs.RoomDTOs;

namespace TABP.Application.Queries.Rooms;

public class GetAllRoomsForAdminQuery : IRequest<IEnumerable<RoomForAdminResponseDto>>
{
    
}