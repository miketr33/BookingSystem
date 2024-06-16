using EventBookingApi.Dtos;
using EventBookingApi.Validators;
using FluentValidation;
using FluentValidation.TestHelper;

namespace EventBookingApiTests;

public class ModifyActivityDtoValidatorTests
{
    private readonly ModifyActivityDtoValidator _validator = new();

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_Name_ShouldHaveError(string name)
    {
        var model = new ModifyActivityDto { Name = name };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Theory]
    [InlineData("Valid Name")]
    public void Validate_Name_ShouldNotHaveError(string name)
    {
        var model = new ModifyActivityDto { Name = name };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_Description_ShouldHaveError(string description)
    {
        var model = new ModifyActivityDto { Description = description };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Theory]
    [InlineData("Valid Description")]
    public void Validate_Description_ShouldNotHaveError(string description)
    {
        var model = new ModifyActivityDto { Description = description };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_AddressLine1_ShouldHaveError(string addressLine1)
    {
        var model = new ModifyActivityDto { AddressLine1 = addressLine1 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.AddressLine1);
    }

    [Theory]
    [InlineData("Valid Address Line 1")]
    public void Validate_AddressLine1_ShouldNotHaveError(string addressLine1)
    {
        var model = new ModifyActivityDto { AddressLine1 = addressLine1 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AddressLine1);
    }

    [Theory]
    [InlineData("Valid Address Line 2")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_AddressLine2_ShouldNotHaveError(string addressLine2)
    {
        var model = new ModifyActivityDto { AddressLine2 = addressLine2 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AddressLine2);
    }

    [Theory]
    [InlineData("Valid Address Line 3")]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_AddressLine3_ShouldNotHaveError(string addressLine3)
    {
        var model = new ModifyActivityDto { AddressLine3 = addressLine3 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AddressLine3);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Validate_Postcode_ShouldHaveError(string postcode)
    {
        var model = new ModifyActivityDto { Postcode = postcode };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Postcode);
    }

    [Theory]
    [InlineData("1234567")]
    public void Validate_Postcode_ShouldNotHaveError(string postcode)
    {
        var model = new ModifyActivityDto { Postcode = postcode };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Postcode);
    }

    [Fact]
    public void Validate_ActivityStart_ShouldHaveError()
    {
        var model = new ModifyActivityDto { ActivityStart = DateTime.MinValue };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ActivityStart);
    }

    [Fact]
    public void Validate_ActivityStart_ShouldNotHaveError()
    {
        var model = new ModifyActivityDto { ActivityStart = DateTime.Now.AddMinutes(1) };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.ActivityStart);
    }

    [Fact]
    public void Validate_ActivityEnd_ShouldHaveError()
    {
        var model = new ModifyActivityDto
            { ActivityStart = DateTime.Now.AddMinutes(10), ActivityEnd = DateTime.Now.AddMinutes(5) };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ActivityEnd);
    }

    [Fact]
    public void Validate_ActivityEnd_ShouldNotHaveError()
    {
        var model = new ModifyActivityDto
            { ActivityStart = DateTime.Now.AddMinutes(5), ActivityEnd = DateTime.Now.AddMinutes(10) };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.ActivityEnd);
    }
}