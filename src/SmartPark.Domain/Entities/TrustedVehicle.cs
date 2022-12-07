using System.ComponentModel.DataAnnotations;

namespace SmartPark.Domain.Entities;
public class TrustedVehicle
{
    public int Id { get; set; }

    [StringLength(12)]
    public required string PlateNumber { get; set; }

    public int ParkingId { get; set; }
    public Parking? Parking { get; set; }
}