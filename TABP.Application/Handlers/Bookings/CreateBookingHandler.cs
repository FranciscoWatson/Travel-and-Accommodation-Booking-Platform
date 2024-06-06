using MediatR;
using TABP.Application.Commands.Bookings;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Application.Responses;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Bookings;

public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Result<BookingDto>>
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

    public async Task<Result<BookingDto>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return Result<BookingDto>.Fail("User not found.");
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
            var roomtype = await _roomTypeRepository.GetByIdAsync(roomTypeId);
            if (roomtype == null)
            {
                return Result<BookingDto>.Fail("Room type not found.");
            }
            var availableRooms = await _roomRepository.GetAvailableRoomsByTypeIdAsync(roomTypeId, request.CheckIn, request.CheckOut);
            if (availableRooms.Count == 0)
            {
                return Result<BookingDto>.Fail("No available rooms for the selected dates.");
            }

            var room = availableRooms.First();
            booking.BookingRooms.Add(new BookingRoom
            {
                RoomId = room.RoomId,
                BookingId = booking.BookingId,
                Room = room
            });

            var priceResult = await CalculatePrice(room.RoomTypeId, request.CheckIn, request.CheckOut);
            if (!priceResult.IsSuccess)
            {
                return Result<BookingDto>.Fail(priceResult.ErrorMessage);
            }
            booking.PriceAtBooking += priceResult.Data;
        }
        
        await _bookingRepository.CreateAsync(booking);
        
        return Result<BookingDto>.Success(new BookingDto
        {
            BookingId = booking.BookingId,
            UserId = booking.UserId,
            CheckIn = booking.CheckIn,
            CheckOut = booking.CheckOut,
            SpecialRequest = booking.SpecialRequest,
            PaymentMethod = booking.Payment.PaymentMethod.ToString(),
            PriceAtBooking = booking.PriceAtBooking
        });
    }

    private async Task<Result<decimal>> CalculatePrice(Guid roomTypeId, DateTime checkIn, DateTime checkOut)
    {
        var roomType = await _roomTypeRepository.GetByIdAsync(roomTypeId);
        if (roomType == null)
        {
            return Result<decimal>.Fail("Room type not found.");
        }
        var price = roomType.Price;
        var applicableDiscounts = await _discountRepository.GetActiveDiscountsByRoomTypeIdAsync(roomType.RoomTypeId, checkIn, checkOut);
        var maxDiscount = applicableDiscounts.MaxBy(d => d.Percentage);
        if (maxDiscount != null)
        {
            price -= price * (decimal)(maxDiscount.Percentage / 100.0);
        }
        return Result<decimal>.Success(price);
    }
}