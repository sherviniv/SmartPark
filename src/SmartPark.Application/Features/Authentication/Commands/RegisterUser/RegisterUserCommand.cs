using MediatR;

namespace SmartPark.Application.Features.Authentication.Commands.RegisterUser;
public class RegisterUserCommand : IRequest<Guid>
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
