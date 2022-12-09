using MediatR;
using SmartPark.Application.Features.DeviceLogs.Models;

namespace SmartPark.Application.Features.DeviceLogs.Queries.GetParkingLogs;
public class GetParkingLogsQuery : IRequest<IList<ParkingLogViewModel>>
{
    public required int ParkingId { get; set; }
}