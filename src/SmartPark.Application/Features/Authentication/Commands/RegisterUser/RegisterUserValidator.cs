using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartPark.Application.Common.Localization;

namespace SmartPark.Application.Features.Authentication.Commands.RegisterUser;
public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
    }
}
