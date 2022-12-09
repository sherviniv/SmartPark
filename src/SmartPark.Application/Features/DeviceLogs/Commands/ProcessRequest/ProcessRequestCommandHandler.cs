using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Application.Features.DeviceLogs.Commands.LogVehicle;
using SmartPark.Application.Features.DeviceLogs.Commands.TrustVehicle;
using SmartPark.Domain.Entities;
using SmartPark.Domain.Enums;

namespace SmartPark.Application.Features.DeviceLogs.Commands.ProcessRequest;
public class ProcessRequestCommandHandler : IRequestHandler<ProcessRequestCommand, Unit>
{
    private readonly ISmartParkContext _context;
    private readonly IMediator _mediator;

    public ProcessRequestCommandHandler(ISmartParkContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(ProcessRequestCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.CameraLogs.FirstAsync(c => c.Id == request.LogId);
        model.ActionTaked = request.Action;
        await _context.SaveChangesAsync();

        if(DoorAction.SaveAsTrustedVehicle == request.Action) 
        {
            var smartDevice = await _context.SmartDevices.FirstAsync(c => c.Id == model.SmartDeviceId);
            await _mediator.Send(new TrustVehicleCommand(model.PlateNumber, smartDevice.ParkingId));
        }

        return Unit.Value;
    }
}