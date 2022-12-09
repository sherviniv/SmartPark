using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Application.Features.DeviceLogs.Models;

namespace SmartPark.Application.Features.DeviceLogs.Queries.GetParkingLogs;
public class GetParkingLogsQueryHandler : IRequestHandler<GetParkingLogsQuery, IList<ParkingLogViewModel>>
{
    private readonly ISmartParkContext _context;
    public GetParkingLogsQueryHandler(ISmartParkContext context)
    {
        _context = context;
    }

    public async Task<IList<ParkingLogViewModel>> Handle(GetParkingLogsQuery request, CancellationToken cancellationToken)
    {
        var vm = await _context.SmartDevices
         .Where(c => c.ParkingId == request.ParkingId)
         .Join(_context.CameraLogs, device => device.Id, log => log.SmartDeviceId,
         (device, log) => new ParkingLogViewModel(log.PlateNumber, log.ActionTaked.ToString(), "", device.Name, device.Id, log.LoggedAt))
         .AsNoTracking()
         .ToListAsync();
        return vm;
    }
}