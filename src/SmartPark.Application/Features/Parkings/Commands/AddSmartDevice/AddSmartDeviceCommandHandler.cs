using MediatR;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;

namespace SmartPark.Application.Features.Parkings.Commands.AddSmartDevice;
public class AddSmartDeviceCommandHandler : IRequestHandler<AddSmartDeviceCommand, int>
{
    private readonly ISmartParkContext _context;
    private readonly ICurrentUserService _currentUserService;
    public AddSmartDeviceCommandHandler(
        ISmartParkContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(AddSmartDeviceCommand request, CancellationToken cancellationToken)
    {
        var model = new SmartDevice() 
        {
            Name = request.Name,
            ParkingId = request.ParkingId ,
            DeviceType = request.DeviceType 
        };
        _context.SmartDevices.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}