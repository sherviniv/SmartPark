using MediatR;
using SmartPark.Domain.Enums;

namespace SmartPark.Application.Features.DeviceLogs.Commands.ProcessRequest;
public class ProcessRequestCommand : IRequest<Unit>
{
    public required int LogId { get; set; }
    public required DoorAction Action { get; set; }
}
