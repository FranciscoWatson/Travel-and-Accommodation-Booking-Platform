using AutoMapper;
using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class UpdateHotelHandler : IRequestHandler<UpdateHotelCommand>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public UpdateHotelHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.HotelId);
        if (hotel == null)
        {
            throw new ApplicationException($"Hotel with id {request.HotelId} not found.");
        }
        
        _mapper.Map(request, hotel);
        
        await _hotelRepository.UpdateAsync(hotel);
        
    }
}