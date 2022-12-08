using MediatR;

namespace SmartPark.Application.Features.Authentication.Commands.RemoveUser;
public class RemoveUserCommand : IRequest<Unit>
{
    public required Guid UserId { get; set; }
    public RemoveUserCommand(Guid userId)
    {
        UserId = userId;
    }
}
