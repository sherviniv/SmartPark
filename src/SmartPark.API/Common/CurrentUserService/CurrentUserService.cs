using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Interfaces;
using System.Security.Claims;

namespace SmartPark.API.Common.CurrentUserService;
public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var httpUserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        UserId = string.IsNullOrEmpty(httpUserId) ? null : Guid.Parse(httpUserId);

        var deviceId = httpContextAccessor.HttpContext?.User?.FindFirstValue(CustomClaims.DeviceId);
        DeviceId = string.IsNullOrEmpty(deviceId) ? null : int.Parse(deviceId);

        var parkingId = httpContextAccessor.HttpContext?.User?.FindFirstValue(CustomClaims.ParkingId);
        ParkingId = string.IsNullOrEmpty(parkingId) ? null : int.Parse(parkingId);
    }

    public Guid? UserId { get; }
    public int? DeviceId { get; set; }
    public int? ParkingId { get; set; }
}