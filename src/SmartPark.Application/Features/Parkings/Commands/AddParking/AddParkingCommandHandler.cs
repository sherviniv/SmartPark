using MediatR;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;

namespace SmartPark.Application.Features.Parkings.Commands.AddParking;
public class AddParkingCommandHandler : IRequestHandler<AddParkingCommand, int>
{
    private readonly ISmartParkContext _context;
    private readonly ICurrentUserService _currentUserService;
    public AddParkingCommandHandler(
        ISmartParkContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(AddParkingCommand request, CancellationToken cancellationToken)
    {
        var model = new Parking() { Name = request.Name, UserId = _currentUserService.UserId!.Value };
        _context.Parkings.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}