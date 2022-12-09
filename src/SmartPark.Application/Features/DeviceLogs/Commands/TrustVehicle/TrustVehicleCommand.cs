using MediatR;

namespace SmartPark.Application.Features.DeviceLogs.Commands.TrustVehicle;
public class TrustVehicleCommand : IRequest<Unit>
{
    public string PlateNumber { get; set; }
    public int ParkingId { get; set; }

    public TrustVehicleCommand(string plateNumber, int parkingId)
    {
        PlateNumber = plateNumber;
        ParkingId = parkingId;
    }
}
