using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPark.Application.Features.Parkings.Commands.AddParking;
using SmartPark.Application.Features.Parkings.Commands.AddSmartDevice;
using SmartPark.Application.Features.Parkings.Commands.CreateDeviceToken;
using SmartPark.Application.Features.Parkings.Models;
using SmartPark.Application.Features.Parkings.Queries.GetUserParkings;
using SmartPark.WebUI.Common.Controller;

namespace SmartPark.WebUI.Controllers;
public class ParkingController : ApiControllerBase
{
    public ParkingController()
    {
    }

    [Authorize]
    [HttpPost("AddParking")]
    public async Task<int> AddParking([FromBody] AddParkingCommand command)
     => await Mediator.Send(command);

    [Authorize]
    [HttpPost("AddSmartDevice")]
    public async Task<int> RegisterUser([FromBody] AddSmartDeviceCommand command)
     => await Mediator.Send(command);

    [Authorize]
    [HttpPost("CreateDeviceToken")]
    public async Task<string> CreateDeviceToken([FromBody] CreateDeviceTokenCommand command)
     => await Mediator.Send(command);

    [Authorize]
    [HttpGet("GetUserParkings")]
    public async Task<IList<ParkingViewModel>> GetUserParkings()
     => await Mediator.Send(new GetUserParkingsQuery());
}