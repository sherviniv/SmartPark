using SmartPark.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartPark.Domain.Entities;
public class CameraLog
{
    public int Id { get; set; }
    public DateTime LoggedAt { get; set; }
    public int SmartDeviceId { get; set; }

    [StringLength(12)]
    public required string PlateNumber { get; set; }

    public required DoorAction ActionTaked { get; set; }
    public SmartDevice? SmartDevice { get; set; }
}