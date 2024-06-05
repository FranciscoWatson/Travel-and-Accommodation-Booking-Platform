using AutoMapper;
using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class UpdateHotelHandler : IRequestHandler<UpdateHotelCommand, Result<object>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public UpdateHotelHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Result<object>> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.HotelId);
        if (hotel == null)
        {
            return Result<object>.Fail("Hotel not found.");
        }
        
        _mapper.Map(request, hotel);
        
        await _hotelRepository.UpdateAsync(hotel);
        return Result<object>.Success();
    }
}