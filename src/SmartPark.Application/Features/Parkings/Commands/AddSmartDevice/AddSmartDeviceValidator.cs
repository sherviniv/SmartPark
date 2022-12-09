using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Localization;
using SmartPark.Application.Features.Parkings.Commands.AddParking;

namespace SmartPark.Application.Features.Parkings.Commands.AddSmartDevice;
public class AddSmartDeviceValidator : AbstractValidator<AddParkingCommand>
{
    public AddSmartDeviceValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Name)
         .NotNull()
         .NotEmpty()
         .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);
    }
}
