using EventBookingApi.Dtos;
using EventBookingApi.Validators;
using FluentValidation.TestHelper;

namespace EventBookingApiTests;

public class ModifyAttendeeDtoValidatorTests
{
    private readonly ModifyAttendeeDtoValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_FirstName_ShouldHaveError(string firstName)
    {
        var model = new ModifiedAttendeeDto { FirstName = firstName };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Theory]
    [InlineData("John")]
    public void Validate_FirstName_ShouldNotHaveError(string firstName)
    {
        var model = new ModifiedAttendeeDto { FirstName = firstName };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_LastName_ShouldHaveError(string lastName)
    {
        var model = new ModifiedAttendeeDto { LastName = lastName };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Theory]
    [InlineData("Doe")]
    public void Validate_LastName_ShouldNotHaveError(string lastName)
    {
        var model = new ModifiedAttendeeDto { LastName = lastName };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.LastName);
    }

    [Theory]
    [InlineData("Valid Address Line 1")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_AddressLine1_ShouldNotHaveError(string addressLine1)
    {
        var model = new ModifiedAttendeeDto { AddressLine1 = addressLine1 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AddressLine1);
    }

    [Theory]
    [InlineData("Valid Address Line 2")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_AddressLine2_ShouldNotHaveError(string addressLine2)
    {
        var model = new ModifiedAttendeeDto { AddressLine2 = addressLine2 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AddressLine2);
    }

    [Theory]
    [InlineData("Valid Address Line 3")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_AddressLine3_ShouldNotHaveError(string addressLine3)
    {
        var model = new ModifiedAttendeeDto { AddressLine3 = addressLine3 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AddressLine3);
    }

    [Theory]
    [InlineData("1234567")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_Postcode_ShouldNotHaveError(string postcode)
    {
        var model = new ModifiedAttendeeDto { Postcode = postcode };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Postcode);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_Email_ShouldHaveError(string email)
    {
        var model = new ModifiedAttendeeDto { Email = email };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData("test@example.com")]
    public void Validate_Email_ShouldNotHaveError(string email)
    {
        var model = new ModifiedAttendeeDto { Email = email };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData(null)]
    public void Validate_DateOfBirth_ShouldHaveError(DateTime? dateOfBirth)
    {
        var model = new ModifiedAttendeeDto { DateOfBirth = dateOfBirth ?? DateTime.MinValue };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
    }

    [Theory]
    [InlineData("2000-01-01")]
    public void Validate_DateOfBirth_ShouldNotHaveError(string dateOfBirth)
    {
        var model = new ModifiedAttendeeDto { DateOfBirth = DateTime.Parse(dateOfBirth) };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.DateOfBirth);
    }

    [Theory]
    [InlineData("1234567890123")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_Phone_ShouldNotHaveError(string phone)
    {
        var model = new ModifiedAttendeeDto { Phone = phone };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Phone);
    }
}