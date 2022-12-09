using MediatR;

namespace SmartPark.Application.Features.Parkings.Commands.CreateDeviceToken;
public class CreateDeviceTokenCommand : IRequest<string>
{
    public required int DeviceId { get; set; }
    public required DateTime ExpireAt { get; set; }
}
