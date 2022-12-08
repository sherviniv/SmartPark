using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Exceptions;
using SmartPark.Domain.Entities;

namespace SmartPark.Application.Features.Authentication.Commands.RemoveUser;
public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RemoveUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == request.UserId);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new ValidationException(result.Errors);
        }

        return Unit.Value;
    }
}