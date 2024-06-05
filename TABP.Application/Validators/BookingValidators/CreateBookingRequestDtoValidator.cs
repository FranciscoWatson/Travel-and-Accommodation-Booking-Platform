using FluentValidation;
using TABP.Application.DTOs.BookingDTOs;

namespace TABP.Application.Validators.BookingValidators;

public class CreateBookingRequestDtoValidator : AbstractValidator<CreateBookingRequestDto>
{
    public CreateBookingRequestDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.RoomTypeIds).NotEmpty().WithMessage("RoomTypeIds is required.");
        RuleFor(x => x.CheckIn).LessThan(x => x.Checkout).WithMessage("Check-in must be before Checkout.");
        RuleFor(x => x.Checkout).GreaterThan(x => x.CheckIn).WithMessage("Checkout must be after Check-in.");
        RuleFor(x => x.PaymentMethod).IsInEnum().WithMessage("PaymentMethod is invalid.");
    }
}