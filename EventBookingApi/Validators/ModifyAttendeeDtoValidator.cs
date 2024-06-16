using EventBookingApi.Dtos;
using FluentValidation;

namespace EventBookingApi.Validators;

public class ModifyAttendeeDtoValidator : AbstractValidator<ModifiedAttendeeDto>
{
    public ModifyAttendeeDtoValidator()
    {
        RuleFor(a => a.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .MaximumLength(50).WithMessage("First Name cannot be longer than 50 characters.");

        RuleFor(a => a.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .MaximumLength(50).WithMessage("Last Name cannot be longer than 50 characters.");

        RuleFor(a => a.AddressLine1)
            .MaximumLength(100).WithMessage("Address Line 1 cannot be longer than 100 characters.");

        RuleFor(a => a.AddressLine2)
            .MaximumLength(100).WithMessage("Address Line 2 cannot be longer than 100 characters.");

        RuleFor(a => a.AddressLine3)
            .MaximumLength(100).WithMessage("Address Line 3 cannot be longer than 100 characters.");

        RuleFor(a => a.Postcode)
            .MaximumLength(8).WithMessage("Postcode cannot be longer than 8 characters.");

        RuleFor(a => a.Phone)
            .MaximumLength(13).WithMessage("Phone number cannot be longer than 13 characters.");

        RuleFor(a => a.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(200).WithMessage("Email cannot be longer than 200 characters.")
            .EmailAddress().WithMessage("Invalid Email format.");

        RuleFor(a => a.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .Must(dob => dob.Date < DateTime.Today).WithMessage("Date of Birth must be in the past.");
    }
}