using MediatR;
using TABP.Application.Responses;

namespace TABP.Application.Commands.Hotels;

public class DeleteHotelCommand : IRequest<Result<object>>
{
    public Guid HotelId { get; init; }
}