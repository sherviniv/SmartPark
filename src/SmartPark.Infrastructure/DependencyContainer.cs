using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;
using SmartPark.Infrastructure.Persistence;
using SmartPark.Infrastructure.Services.TextRecognition;

namespace SmartPark.Infrastructure;
public static class DependencyContainer
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFrameworkNpgsql();
        services.AddDbContextPool<SmartParkContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                  builder => builder.MigrationsAssembly(typeof(SmartParkContext).Assembly.FullName)));

        services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SmartParkContext>();

        services.AddScoped<ISmartParkContext>(provider => provider.GetService<SmartParkContext>()!);

        services.AddSingleton<ITextRecognitionService, TextRecognitionService>();
    }
}