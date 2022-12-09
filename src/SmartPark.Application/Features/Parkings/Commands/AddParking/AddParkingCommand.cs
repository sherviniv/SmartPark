using MediatR;

namespace SmartPark.Application.Features.Parkings.Commands.AddParking;
public class AddParkingCommand : IRequest<int>
{
    public required string Name { get; set; }
}
