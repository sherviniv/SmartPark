using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Application.Features.Parkings.Models;

namespace SmartPark.Application.Features.Parkings.Queries.GetUserParkings;
public class GetUserParkingsQueryHandler : IRequestHandler<GetUserParkingsQuery, IList<ParkingViewModel>>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly ISmartParkContext _context;
    public GetUserParkingsQueryHandler(
        ICurrentUserService currentUserService,
        ISmartParkContext context)
    {
        _currentUserService = currentUserService;
        _context = context;
    }

    public async Task<IList<ParkingViewModel>> Handle(GetUserParkingsQuery request, CancellationToken cancellationToken)
    {
        Guid userId = _currentUserService.UserId!.Value;

        var vm = await _context.Parkings
         .Where(c => c.UserId == userId)
         .Include(c => c.SmartDevices)
         .AsNoTracking()
         .Select(c => new ParkingViewModel()
         {
             Name = c.Name,
             ParkingId = c.Id,
             NumberOfDevices = c.SmartDevices == null ? 0 : c.SmartDevices.Count,
             Devices = c.SmartDevices == null ? default : c.SmartDevices.Select(d => new DeviceViewModel(d.Id, d.Name, d.DeviceType)).ToList(),
         }).ToListAsync();
        return vm;
    }
}