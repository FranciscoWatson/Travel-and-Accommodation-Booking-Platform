using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class DeleteHotelHandler : IRequestHandler<DeleteHotelCommand, Result<object>>
{
    private readonly IHotelRepository _hotelRepository;

    public DeleteHotelHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<Result<object>> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.ExistsAsync(request.HotelId);
        if (!hotel)
        {
            return Result<object>.Fail("Hotel not found.");
        }
        await _hotelRepository.DeleteAsync(request.HotelId);
        
        return Result<object>.Success();
    }
}