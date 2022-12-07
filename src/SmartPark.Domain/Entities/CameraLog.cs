namespace SmartPark.Domain.Entities;
public class CameraLog
{
    public int Id { get; set; }
    public DateTime LoggedAt { get; set; }
    public int SmartDeviceId { get; set; }
    public SmartDevice? SmartDevice { get; set; }
}