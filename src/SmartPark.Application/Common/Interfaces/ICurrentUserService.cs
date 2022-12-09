namespace SmartPark.Application.Common.Interfaces;
public interface ICurrentUserService
{
    Guid? UserId { get; }
    int? DeviceId { get; set; }
    int? ParkingId { get; set; }
}