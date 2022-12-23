using Microsoft.AspNetCore.Mvc;
using SmartPark.Application.Features.Authentication.Commands.Login;
using SmartPark.Application.Features.Authentication.Commands.RegisterUser;
using SmartPark.Application.Features.Authentication.Commands.RemoveUser;
using SmartPark.WebUI.Common.Controller;

namespace SmartPark.WebUI.Controllers;
public class AuthenticateController : ApiControllerBase
{
    public AuthenticateController()
    {
    }

    [HttpPost("Login")]
    public async Task<string> Login([FromBody] LoginCommand command)
     => await Mediator.Send(command);

    [HttpPost("RegisterUser")]
    public async Task<Guid> RegisterUser([FromBody] RegisterUserCommand command)
     => await Mediator.Send(command);

    [HttpPost("RemoveUser")]
    public async Task<ActionResult> RemoveUser([FromBody] RemoveUserCommand command)
     => Ok(await Mediator.Send(command));
}