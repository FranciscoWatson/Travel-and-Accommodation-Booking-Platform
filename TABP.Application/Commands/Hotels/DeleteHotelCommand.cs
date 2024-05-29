using MediatR;

namespace TABP.Application.Commands.Hotels;

public class DeleteHotelCommand : IRequest
{
    public Guid HotelId { get; init; }
}