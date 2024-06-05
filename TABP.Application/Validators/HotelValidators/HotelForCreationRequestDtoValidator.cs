using System.Text.RegularExpressions;
using FluentValidation;
using TABP.Application.DTOs.HotelDTOs;

namespace TABP.Application.Validators.HotelValidators;

public class HotelForCreationRequestDtoValidator : AbstractValidator<HotelForCreationRequestDto>
{
    public HotelForCreationRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(1, 100).WithMessage("Name is required.");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description is too long.");
        RuleFor(x => x.PhoneNumber).Matches(new Regex(@"^\+[1-9]{1}[0-9]{3,14}$")).WithMessage("PhoneNumber is invalid.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid.");
        RuleFor(x => x.StarRating).InclusiveBetween(1, 5).WithMessage("StarRating is invalid.");
        RuleFor(x => x.Address).NotEmpty().Length(1, 100).WithMessage("Address is required.");
        RuleFor(x => x.CityId).NotEmpty().WithMessage("CityId is required.");
        RuleFor(x => x.OwnerId).NotEmpty().WithMessage("OwnerId is required.");
    }
}