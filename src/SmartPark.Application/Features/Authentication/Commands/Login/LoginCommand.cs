using MediatR;
namespace SmartPark.Application.Features.Authentication.Commands.Login;
public class LoginCommand : IRequest<string>
{
    public required string UserName { get; set; }
    public required string Password { get; set; }

    public LoginCommand(string username, string password)
    {
        UserName = username;
        Password = password;
    }
}