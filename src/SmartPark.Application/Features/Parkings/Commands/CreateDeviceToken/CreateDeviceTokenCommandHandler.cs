using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;

namespace SmartPark.Application.Features.Parkings.Commands.CreateDeviceToken;
public class CreateDeviceTokenCommandHandler : IRequestHandler<CreateDeviceTokenCommand, string>
{
    private readonly ISmartParkContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IJwtHandler _jwtHandler;

    public CreateDeviceTokenCommandHandler(
        ISmartParkContext context,
        ICurrentUserService currentUserService,
        IJwtHandler jwtHandler)
    {
        _context = context;
        _currentUserService = currentUserService;
        _jwtHandler = jwtHandler;
    }

    public async Task<string> Handle(CreateDeviceTokenCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.SmartDevices
            .AsNoTracking()
            .FirstAsync(c => c.Id == request.DeviceId);

        string token = _jwtHandler.GenerateDeviceToken(model.Id, model.ParkingId, request.ExpireAt);

        return token;
    }
}