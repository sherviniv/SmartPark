using SmartPark.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartPark.Domain.Entities;
public class SmartDevice
{
    public int Id { get; set; }

    [StringLength(255)]
    public required string Name { get; set; }
    public DeviceType DeviceType { get; set; }

    public int ParkingId { get; set; }
    public Parking? Parking { get; set; }
}