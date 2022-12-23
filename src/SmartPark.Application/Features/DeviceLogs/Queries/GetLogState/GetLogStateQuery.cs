using MediatR;
using SmartPark.Domain.Enums;

namespace SmartPark.Application.Features.DeviceLogs.Queries.GetLogState;
public class GetLogStateQuery : IRequest<DoorAction>
{
    public required int LogId { get; set; }
}