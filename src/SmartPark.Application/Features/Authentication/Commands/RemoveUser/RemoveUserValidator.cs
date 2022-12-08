using FluentValidation;

namespace SmartPark.Application.Features.Authentication.Commands.RemoveUser;
public class RemoveUserValidator : AbstractValidator<RemoveUserCommand>
{
    public RemoveUserValidator()
    {
    }
}
