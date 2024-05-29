using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class DeleteHotelHandler : IRequestHandler<DeleteHotelCommand>
{
    private readonly IHotelRepository _hotelRepository;

    public DeleteHotelHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        await _hotelRepository.DeleteAsync(request.HotelId);
    }
}