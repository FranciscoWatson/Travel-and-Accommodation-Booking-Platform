using AutoMapper;
using MediatR;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Application.Queries.Bookings;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Bookings;

public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, BookingDto>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;

    public GetBookingByIdHandler(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task<BookingDto> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdDetailedAsync(request.BookingId);
        
        return _mapper.Map<BookingDto>(booking);
    }
}