using MediatR;
using Microsoft.AspNetCore.Http;

namespace SmartPark.Application.Features.DeviceLogs.Commands.LogVehicle;
public class LogVehicleCommand : IRequest<int>
{
    public required IFormFile CaputredImage { get; set; }
}
