using FluentValidation;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Validators.HotelValidators;

public class HotelForUpdateRequestDtoValidator : AbstractValidator<HotelForUpdateRequestDto>
{
    public HotelForUpdateRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(1, 100).WithMessage("Name is required.");
        RuleFor(x => x.CityId).NotEmpty().WithMessage("CityId is required.");
        RuleFor(x => x.OwnerId).NotEmpty().WithMessage("OwnerId is required.");
    }
}