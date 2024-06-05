using FluentValidation;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Validators.CityValidators;

public class CityForCreationRequestDtoValidator : AbstractValidator<CityForCreationRequestDto>
{
    public CityForCreationRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(1, 100).WithMessage("Name is required.");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description is too long.");
        RuleFor(x => x.PostalCode).NotEmpty().Length(4, 10).WithMessage("PostalCode is required.");
        RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId is required.");
    }
}