using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Application.Features.DeviceLogs.Models;
using SmartPark.Domain.Enums;

namespace SmartPark.Application.Features.DeviceLogs.Queries.GetLogState;
public class GetLogStateQueryHandler : IRequestHandler<GetLogStateQuery, DoorAction>
{
    private readonly ISmartParkContext _context;
    public GetLogStateQueryHandler(ISmartParkContext context)
    {
        _context = context;
    }

    public async Task<DoorAction> Handle(GetLogStateQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.CameraLogs.FirstOrDefaultAsync(c => c.Id == request.LogId);
        return model!.ActionTaked;
    }
}