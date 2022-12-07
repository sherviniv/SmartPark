using Microsoft.EntityFrameworkCore;
using SmartPark.Domain.Entities;

namespace SmartPark.Application.Common.Interfaces;
public interface ISmartParkContext
{
    DbSet<CameraLog> CameraLogs { get; set; }
    DbSet<Parking> Parkings { get; set; }
    DbSet<SmartDevice> SmartDevices { get; set; }
    DbSet<TrustedVehicle> TrustedVehicles { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}