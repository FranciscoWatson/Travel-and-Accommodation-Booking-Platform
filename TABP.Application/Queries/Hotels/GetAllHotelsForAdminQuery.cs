using MediatR;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Queries.Hotels;

public class GetAllHotelsForAdminQuery : IRequest<IEnumerable<HotelForAdminResponseDto>>
{
    
}