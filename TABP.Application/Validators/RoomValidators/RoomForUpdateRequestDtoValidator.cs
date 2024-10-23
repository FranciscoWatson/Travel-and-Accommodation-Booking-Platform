using FluentValidation;
using TABP.Application.DTOs.RoomDTOs;

namespace TABP.Application.Validators.RoomValidators;

public class RoomForUpdateRequestDtoValidator : AbstractValidator<RoomForUpdateRequestDto>
{
    public RoomForUpdateRequestDtoValidator()
    {
        RuleFor(x => x.RoomTypeId).NotEmpty().WithMessage("Room type ID must be specified.");
        RuleFor(x => x.RoomNumber).GreaterThan(0).WithMessage("Room number must be greater than zero.");
    }
}