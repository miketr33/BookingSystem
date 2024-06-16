using EventBookingApi.Dtos;
using FluentValidation;

namespace EventBookingApi.Validators;

public class ModifyActivityDtoValidator : AbstractValidator<ModifyActivityDto>
{
    public ModifyActivityDtoValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

        RuleFor(a => a.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(2000).WithMessage("Description cannot be longer than 2000 characters.");

        RuleFor(a => a.AddressLine1)
            .NotEmpty().WithMessage("Address Line 1 is required.")
            .MaximumLength(100).WithMessage("Address Line 1 cannot be longer than 100 characters.");

        RuleFor(a => a.AddressLine2)
            .MaximumLength(100).WithMessage("Address Line 2 cannot be longer than 100 characters.");

        RuleFor(a => a.AddressLine3)
            .MaximumLength(100).WithMessage("Address Line 3 cannot be longer than 100 characters.");

        RuleFor(a => a.Postcode)
            .NotEmpty().WithMessage("Postcode is required.")
            .MaximumLength(8).WithMessage("Postcode cannot be longer than 8 characters.");

        RuleFor(a => a.ActivityStart)
            .NotEmpty().WithMessage("ActivityDetails Start Date is required.")
            .Must(date => date > DateTime.Now).WithMessage("ActivityDetails Start Date must be in the future.");

        RuleFor(a => a.ActivityEnd)
            .NotEmpty().WithMessage("ActivityDetails End Date is required.")
            .Must((activity, end) => end > activity.ActivityStart)
            .WithMessage("ActivityDetails End Date must be after ActivityDetails Start Date.");
    }
}