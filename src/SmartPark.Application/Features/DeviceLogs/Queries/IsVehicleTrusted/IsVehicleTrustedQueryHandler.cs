using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Application.Features.DeviceLogs.Models;
using SmartPark.Application.Features.DeviceLogs.Queries.GetParkingLogs;

namespace SmartPark.Application.Features.DeviceLogs.Queries.IsVehicleTrusted;
public class IsVehicleTrustedQueryHandler : IRequestHandler<IsVehicleTrustedQuery, bool>
{
    private readonly ISmartParkContext _context;
    public IsVehicleTrustedQueryHandler(ISmartParkContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(IsVehicleTrustedQuery request, CancellationToken cancellationToken)
    {
        var vm = await _context.TrustedVehicles
            .AnyAsync(c => c.ParkingId == request.ParkingId && c.PlateNumber == request.PlateNumber.ToUpper());
        return vm;
    }
}