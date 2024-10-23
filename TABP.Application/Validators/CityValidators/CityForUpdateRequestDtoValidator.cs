using FluentValidation;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Validators.CityValidators;

public class CityForUpdateRequestDtoValidator : AbstractValidator<CityForUpdateRequestDto>
{
    public CityForUpdateRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(1, 100).WithMessage("Name is required.");
        RuleFor(x => x.PostalCode).NotEmpty().Length(4, 10).WithMessage("PostalCode is required.");
        RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId is required");
    }
}