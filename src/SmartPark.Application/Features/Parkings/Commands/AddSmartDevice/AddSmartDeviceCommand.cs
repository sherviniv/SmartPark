using MediatR;
using SmartPark.Domain.Enums;

namespace SmartPark.Application.Features.Parkings.Commands.AddSmartDevice;
public class AddSmartDeviceCommand : IRequest<int>
{
    public required string Name { get; set; }
    public required int ParkingId { get; set; }
    public required DeviceType DeviceType { get; set; }
}
