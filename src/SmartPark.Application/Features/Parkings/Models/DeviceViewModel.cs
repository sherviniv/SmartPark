using SmartPark.Domain.Enums;

namespace SmartPark.Application.Features.Parkings.Models;
public class DeviceViewModel
{
    public int DeviceId { get; set; }
    public string Name { get; set; }
    public DeviceType Type { get; set; }

    public DeviceViewModel(int deviceId, string name, DeviceType type)
    {
        DeviceId = deviceId;
        Name = name;
        Type = type;
    }
}