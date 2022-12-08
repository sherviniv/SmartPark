using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Exceptions;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Application.Common.Localization;
using SmartPark.Domain.Entities;
using System.Data;

namespace SmartPark.Application.Features.Authentication.Commands.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtHandler _jwtHandler;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public LoginCommandHandler(
        UserManager<ApplicationUser> userManager,
        IJwtHandler jwtHandler,
        IStringLocalizer<MessagesLocalizer> localizer)
    {
        _userManager = userManager;
        _jwtHandler = jwtHandler;
        _localizer = localizer;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
            throw new SmartParkException(MessageCodes.InvalidCredentials,
                      _localizer.GetString(MessageCodes.InvalidCredentials)?.Value ?? "", System.Net.HttpStatusCode.BadRequest);

        var result = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!result)
            throw new SmartParkException(MessageCodes.InvalidCredentials,
                      _localizer.GetString(MessageCodes.InvalidCredentials)?.Value ?? "", System.Net.HttpStatusCode.BadRequest);

        var token = _jwtHandler.GenerateUserToken(user);
        return token;
    }
}