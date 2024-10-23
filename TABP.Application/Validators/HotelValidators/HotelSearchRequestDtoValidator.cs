using FluentValidation;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Validators.HotelValidators;

public class HotelSearchRequestDtoValidator : AbstractValidator<HotelSearchRequestDto>
{
    public HotelSearchRequestDtoValidator()
    {
        RuleFor(x => x.CheckIn).LessThan(x => x.CheckOut)
            .WithMessage("Check-in date must be earlier than check-out date.");

        RuleFor(x => x.NumberOfAdults).GreaterThan(0)
            .WithMessage("At least one adult must be specified.");

        RuleFor(x => x.NumberOfChildren).GreaterThanOrEqualTo(0)
            .WithMessage("Number of children cannot be negative.");

        RuleFor(x => x.NumberOfRooms).GreaterThan(0)
            .WithMessage("At least one room must be specified.");

        RuleFor(x => x.MaxPrice).GreaterThan(0).When(x => x.MaxPrice.HasValue)
            .WithMessage("Maximum price must be greater than zero.");

        RuleFor(x => x.MinRating).InclusiveBetween(1, 5).When(x => x.MinRating.HasValue)
            .WithMessage("Minimum rating must be between 1 and 5.");
    }
}