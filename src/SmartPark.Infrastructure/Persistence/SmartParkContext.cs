using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;

namespace SmartPark.Infrastructure.Persistence;
internal class SmartParkContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, ISmartParkContext
{
    public SmartParkContext(DbContextOptions<SmartParkContext> options) : base(options)
    {
    }

    public DbSet<CameraLog> CameraLogs { get; set; }
    public DbSet<Parking> Parkings { get; set; }
    public DbSet<SmartDevice> SmartDevices { get; set; }
    public DbSet<TrustedVehicle> TrustedVehicles { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
