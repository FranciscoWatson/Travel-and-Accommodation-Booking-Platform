using FluentValidation;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Validators.HotelValidators;

public class HotelFeaturedDealsRequestDtoValidator : AbstractValidator<HotelFeaturedDealsRequestDto>
{
    public HotelFeaturedDealsRequestDtoValidator()
    {
        RuleFor(x => x.Count).GreaterThan(0).WithMessage("Count must be greater than 0.");
    }
}