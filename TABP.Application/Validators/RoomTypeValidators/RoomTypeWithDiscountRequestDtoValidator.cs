using FluentValidation;
using TABP.Application.DTOs.RoomTypeDTOs;

namespace TABP.Application.Validators.RoomTypeValidators;

public class RoomTypeWithDiscountRequestDtoValidator : AbstractValidator<RoomTypeWithDiscountRequestDto>
{
    public RoomTypeWithDiscountRequestDtoValidator()
    {
        When(x => x.CheckIn.HasValue && x.CheckOut.HasValue, () =>
        {
            RuleFor(x => x.CheckIn.Value)
                .LessThan(x => x.CheckOut.Value)
                .WithMessage("Check-in date must be before the check-out date.");

            RuleFor(x => x.CheckOut.Value)
                .GreaterThan(x => x.CheckIn.Value)
                .WithMessage("Check-out date must be after the check-in date.");
        });
    }
}