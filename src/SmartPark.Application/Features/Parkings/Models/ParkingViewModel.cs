namespace SmartPark.Application.Features.Parkings.Models;
public class ParkingViewModel
{
    public required int ParkingId { get; set; }
    public required string Name { get; set; }
    public int NumberOfDevices { get; set; }
    public IList<DeviceViewModel>? Devices { get; set; }
}