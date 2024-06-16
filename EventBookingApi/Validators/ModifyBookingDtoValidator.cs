using EventBookingApi.Dtos;
using FluentValidation;

namespace EventBookingApi.Validators;

public class ModifyBookingDtoValidator : AbstractValidator<ModifyBookingDto>
{
    public ModifyBookingDtoValidator()
    {
        RuleFor(b => b.ActivityId)
            .NotEmpty().WithMessage("ActivityId is required.")
            .GreaterThan(0).WithMessage("ActivityId must be greater than 0.");

        RuleFor(b => b.AttendeeId)
            .NotEmpty().WithMessage("AttendeeId is required.")
            .GreaterThan(0).WithMessage("AttendeeId must be greater than 0.");

        RuleFor(b => b.Attended)
            .NotNull().WithMessage("Attended must not be null.")
            .Must(value => value == true || value == false)
            .WithMessage("Attended must be either true or false.");
    }
}