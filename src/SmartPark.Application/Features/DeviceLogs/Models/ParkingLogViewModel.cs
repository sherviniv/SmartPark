namespace SmartPark.Application.Features.DeviceLogs.Models;
public class ParkingLogViewModel
{
    public string PlateNumber { get; set; }
    public string ActionTaked { get; set; }
    public string ImageUrl { get; set; }
    public string CapturedByDevice { get; set; }
    public int CapturedByDeviceId { get; set; }
    public DateTime DateTimeLogged { get; set; }

    public ParkingLogViewModel(string plateNumber, string actionTaked, string imageUrl, string capturedByDevice, int capturedByDeviceId, DateTime dateTimeLogged)
    {
        PlateNumber = plateNumber;
        ActionTaked = actionTaked;
        ImageUrl = imageUrl;
        CapturedByDevice = capturedByDevice;
        CapturedByDeviceId = capturedByDeviceId;
        DateTimeLogged = dateTimeLogged;
    }

}