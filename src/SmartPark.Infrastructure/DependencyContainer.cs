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
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = jwtOptions.Issuer, // site that makes the token
                ValidateIssuer = false, // change this to avoid forwarding attacks
                ValidAudience = "Any", // site that consumes the token
                ValidateAudience = false, // change this to avoid forwarding attacks
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
                ValidateIssuerSigningKey = true,  // verify signature to avoid tampering
                ValidateLifetime = true, // validate the expiration
                ClockSkew = TimeSpan.Zero, // tolerance for the expiration date
                TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
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
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedDefaultUserAsync(userManager);
        }
    }

    static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "admin",
        };

        if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
        {
            await userManager.CreateAsync(defaultUser, "Pass@123456");
        }
    }
}