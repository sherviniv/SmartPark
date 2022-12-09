using MediatR;
using Microsoft.AspNetCore.Http;
using SmartPark.Application.Common.Interfaces;
using SmartPark.Domain.Entities;

namespace SmartPark.Application.Features.DeviceLogs.Commands.LogVehicle;
public class LogVehicleCommandHandler : IRequestHandler<LogVehicleCommand, int>
{
    private readonly ISmartParkContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly ITextRecognitionService _textRecognitionService;

    public LogVehicleCommandHandler(
        ISmartParkContext context,
        ICurrentUserService currentUserService,
        IDateTime dateTime,
        ITextRecognitionService textRecognitionService)
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTime = dateTime;
        _textRecognitionService = textRecognitionService;
    }

    public async Task<int> Handle(LogVehicleCommand request, CancellationToken cancellationToken)
    {
        var plateNumber = await GetPlateNumberFromImageAsync(request.CaputredImage);
        var model = new CameraLog() 
        {
            LoggedAt = _dateTime.UtcNow,
            SmartDeviceId = _currentUserService.DeviceId!.Value,
            ActionTaked = Domain.Enums.DoorAction.NoAction,
            PlateNumber = plateNumber.ToUpper()
        };
        _context.CameraLogs.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public Task<string> GetPlateNumberFromImageAsync(IFormFile image) 
    {
        using (var ms = new MemoryStream())
        {
            image.CopyTo(ms);
            var fileBytes = ms.ToArray();
            var plateNumber = _textRecognitionService.RecognizeFromImageAsync(fileBytes).Result;
            return Task.FromResult(plateNumber);
        }
    }
}