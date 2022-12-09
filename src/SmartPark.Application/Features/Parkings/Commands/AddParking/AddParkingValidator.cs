using FluentValidation;
using Microsoft.Extensions.Localization;
using SmartPark.Application.Common.Constants;
using SmartPark.Application.Common.Localization;

namespace SmartPark.Application.Features.Parkings.Commands.AddParking;
public class AddParkingValidator : AbstractValidator<AddParkingCommand>
{
    public AddParkingValidator(IStringLocalizer<MessagesLocalizer> localizer)
    {
        RuleFor(p => p.Name)
         .NotNull()
         .NotEmpty()
         .WithMessage(localizer.GetString(MessageCodes.IsRequired)?.Value);
    }
}
