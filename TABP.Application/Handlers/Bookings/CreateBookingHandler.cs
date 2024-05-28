using MediatR;
using TABP.Application.Commands.Bookings;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Application.Handlers.Bookings;

public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, BookingDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;

    public CreateBookingHandler(IUserRepository userRepository, IRoomTypeRepository roomTypeRepository, IDiscountRepository discountRepository, IRoomRepository roomRepository, IBookingRepository bookingRepository)
    {
        _userRepository = userRepository;
        _roomTypeRepository = roomTypeRepository;
        _discountRepository = discountRepository;
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }
        
        var booking = new Booking
        {
            UserId = request.UserId,
            CheckIn = request.CheckIn,
            CheckOut = request.CheckOut,
            SpecialRequest = request.SpecialRequest,
            Payment = new Payment
            {
                PaymentMethod = request.PaymentMethod
            },
            BookingRooms = new List<BookingRoom>()
        };
        
        foreach (var roomTypeId in request.RoomTypeIds)
        {
            var availableRooms = await _roomRepository.GetAvailableRoomsByTypeIdAsync(roomTypeId, request.CheckIn, request.CheckOut);
            if (availableRooms.Count == 0)
            {
                throw new InvalidOperationException("No available rooms for the selected dates.");
            }

            var room = availableRooms.First();
            booking.BookingRooms.Add(new BookingRoom
            {
                RoomId = room.RoomId,
                BookingId = booking.BookingId,
                Room = room
            });

            var price = await CalculatePrice(room.RoomTypeId, request.CheckIn, request.CheckOut);
            booking.PriceAtBooking += price;
        }
        

        await _bookingRepository.CreateAsync(booking);
        
        return new BookingDto
        {
            BookingId = booking.BookingId,
            UserId = booking.UserId,
            CheckIn = booking.CheckIn,
            CheckOut = booking.CheckOut,
            SpecialRequest = booking.SpecialRequest,
            PaymentMethod = booking.Payment.PaymentMethod.ToString(),
            PriceAtBooking = booking.PriceAtBooking
        };
    }

    private async Task<decimal> CalculatePrice(Guid requestRoomTypeIds, DateTime requestCheckIn,
        DateTime requestCheckOut)
    {
        var roomType = await _roomTypeRepository.GetByIdAsync(requestRoomTypeIds);
        if (roomType == null)
        {
            throw new InvalidOperationException("Room type not found.");
        }
        var price = roomType.Price;
        var applicableDiscounts = await _discountRepository.GetActiveDiscountsByRoomTypeIdAsync(roomType.RoomTypeId, requestCheckIn, requestCheckOut);
        var maxDiscount = applicableDiscounts.MaxBy(d => d.Percentage);
        if (maxDiscount != null)
        {
            price -= price * (decimal)(maxDiscount.Percentage / 100.0);
        }
        return price;
    }
}