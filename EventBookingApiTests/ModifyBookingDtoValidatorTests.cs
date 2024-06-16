using EventBookingApi.Dtos;
using EventBookingApi.Validators;
using FluentValidation.TestHelper;

namespace EventBookingApiTests;

public class ModifyBookingDtoValidatorTests
{
    private readonly ModifyBookingDtoValidator _validator = new();

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_ActivityId_ShouldHaveError(int activityId)
    {
        var model = new ModifyBookingDto { ActivityId = activityId };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ActivityId);
    }

    [Theory]
    [InlineData(1)]
    public void Validate_ActivityId_ShouldNotHaveError(int activityId)
    {
        var model = new ModifyBookingDto { ActivityId = activityId };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.ActivityId);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_AttendeeId_ShouldHaveError(int attendeeId)
    {
        var model = new ModifyBookingDto { AttendeeId = attendeeId };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.AttendeeId);
    }

    [Theory]
    [InlineData(1)]
    public void Validate_AttendeeId_ShouldNotHaveError(int attendeeId)
    {
        var model = new ModifyBookingDto { AttendeeId = attendeeId };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.AttendeeId);
    }

    [Theory]
    [InlineData(null)]
    public void Validate_Attended_ShouldHaveError(bool? attended)
    {
        var model = new ModifyBookingDto { Attended = attended };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Attended);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Validate_Attended_ShouldNotHaveError(bool attended)
    {
        var model = new ModifyBookingDto { Attended = attended };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Attended);
    }
}