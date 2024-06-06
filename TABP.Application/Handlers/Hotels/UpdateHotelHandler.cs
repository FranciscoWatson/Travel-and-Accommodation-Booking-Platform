using AutoMapper;
using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class UpdateHotelHandler : IRequestHandler<UpdateHotelCommand, Result<object>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public UpdateHotelHandler(IHotelRepository hotelRepository, IMapper mapper, IOwnerRepository ownerRepository, ICityRepository cityRepository)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
        _ownerRepository = ownerRepository;
        _cityRepository = cityRepository;
    }

    public async Task<Result<object>> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var cityExists = await _cityRepository.ExistsAsync(request.CityId);
        if (!cityExists)
        {
            return Result<object>.Fail("City not found.");
        }
        
        var ownerExists = await _ownerRepository.ExistsAsync(request.OwnerId);
        if (!ownerExists)
        {
            return Result<object>.Fail("Owner not found.");
        }
        
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