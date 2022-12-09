using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPark.API.Common.Controller;
using SmartPark.Application.Features.DeviceLogs.Commands.LogVehicle;
using SmartPark.Application.Features.DeviceLogs.Commands.ProcessRequest;
using SmartPark.Application.Features.DeviceLogs.Models;
using SmartPark.Application.Features.DeviceLogs.Queries.GetParkingLogs;

namespace SmartPark.API.Controllers;
public class DeviceController : ApiControllerBase
{
    public DeviceController()
    {
    }

    [Authorize]
    [HttpPost("LogVehicle")]
    public async Task<int> LogVehicle(IFormFile imageFile)
      => await Mediator.Send(new LogVehicleCommand() { CaputredImage = imageFile });

    [Authorize]
    [HttpPost("ProcessRequest")]
    public async Task ProcessRequest([FromBody] ProcessRequestCommand command)
         => await Mediator.Send(command);

    [Authorize]
    [HttpGet("GetParkingLogs")]
    public async Task<IList<ParkingLogViewModel>> GetParkingLogs([FromQuery] GetParkingLogsQuery query)
     => await Mediator.Send(query);
}
