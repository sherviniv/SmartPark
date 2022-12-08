using SmartPark.Domain.Entities;

namespace SmartPark.Application.Common.Interfaces;
public interface IJwtHandler
{
    string GenerateDeviceToken(int deviceId, int parkingId, DateTime expireTime);
    string GenerateUserToken(ApplicationUser user);
}