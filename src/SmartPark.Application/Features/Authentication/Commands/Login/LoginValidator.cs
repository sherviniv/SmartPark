using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Localization;

namespace SmartPark.Application.Features.Authentication.Commands.Login;
public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);

        RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);
    }
}