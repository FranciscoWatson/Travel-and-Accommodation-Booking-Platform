using FluentValidation;
using TABP.Application.DTOs.Authentication;

namespace TABP.Application.Validators.AuthenticationValidators;

public class LoginRequestBodyValidator : AbstractValidator<LoginRequestBody>
{
    public LoginRequestBodyValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}