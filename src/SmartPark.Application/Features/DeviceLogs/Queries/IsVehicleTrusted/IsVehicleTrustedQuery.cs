using MediatR;

namespace SmartPark.Application.Features.DeviceLogs.Queries.IsVehicleTrusted;
public class IsVehicleTrustedQuery : IRequest<bool>
{
    public required int ParkingId { get; set; }
    public required string PlateNumber { get; set; }
}