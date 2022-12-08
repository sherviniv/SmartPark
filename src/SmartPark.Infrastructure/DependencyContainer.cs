using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;
using SmartPark.Infrastructure.Identity;
using SmartPark.Infrastructure.Persistence;
using SmartPark.Infrastructure.Services.DateTimeService;
using SmartPark.Infrastructure.Services.TextRecognition;
using System.Text;

namespace SmartPark.Infrastructure;
public static class DependencyContainer
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("JwtOptions");
        services.Configure<JwtOptions>(jwtSection);
        var jwtOptions = jwtSection.Get<JwtOptions>();

        services.AddEntityFrameworkNpgsql();
        services.AddDbContextPool<SmartParkContext>((serviceProvider, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                      builder => builder.MigrationsAssembly(typeof(SmartParkContext).Assembly.FullName));
            options.UseInternalServiceProvider(serviceProvider);
        });

        services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<SmartParkContext>();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
            };
        });

        services.AddScoped<ISmartParkContext>(provider => provider.GetService<SmartParkContext>()!);
        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<IDateTime, DateTimeService>();
        services.AddSingleton<ITextRecognitionService, TextRecognitionService>();
    }

    public static async Task SeedDatabaseAsync(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SmartParkContext>();
            if (context.Database.IsRelational())
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}