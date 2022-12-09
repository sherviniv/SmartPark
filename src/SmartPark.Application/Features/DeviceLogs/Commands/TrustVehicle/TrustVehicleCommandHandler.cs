using MediatR;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;

namespace SmartPark.Application.Features.DeviceLogs.Commands.TrustVehicle;
public class TrustVehicleCommandHandler : IRequestHandler<TrustVehicleCommand, Unit>
{
    private readonly ISmartParkContext _context;

    public TrustVehicleCommandHandler(ISmartParkContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(TrustVehicleCommand request, CancellationToken cancellationToken)
    {
        var model = new TrustedVehicle() { PlateNumber = request.PlateNumber.ToUpper(), ParkingId = request.ParkingId };
        _context.TrustedVehicles.Add(model);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}