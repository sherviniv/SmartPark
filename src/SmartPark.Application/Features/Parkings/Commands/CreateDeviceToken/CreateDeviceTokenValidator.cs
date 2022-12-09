using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Localization;

namespace SmartPark.Application.Features.Parkings.Commands.CreateDeviceToken;
public class AddParkingValidator : AbstractValidator<CreateDeviceTokenCommand>
{
    public AddParkingValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.DeviceId)
         .NotNull()
         .NotEmpty()
         .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);
    }
}
