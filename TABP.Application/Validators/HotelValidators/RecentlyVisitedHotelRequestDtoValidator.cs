using FluentValidation;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Validators.HotelValidators;

public class RecentlyVisitedHotelRequestDtoValidator : AbstractValidator<RecentlyVisitedHotelRequestDto>
{
    public RecentlyVisitedHotelRequestDtoValidator()
    {
        RuleFor(x => x.Count).GreaterThan(0).WithMessage("Count must be greater than zero.");
    }
}