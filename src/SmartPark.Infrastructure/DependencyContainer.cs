using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Infrastructure.Services.TextRecognition;

namespace SmartPark.Infrastructure;
public static class DependencyContainer
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITextRecognitionService, TextRecognitionService>();
    }
}