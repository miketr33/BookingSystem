using Bunit;
using EventBookingShared.Dtos;
using EventBookingWebApp.Components.Shared;
using EventBookingWebApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace EventBookingWebAppTests;

/// <summary>
/// A suite of unit tests to test the Activities Blazor component validation.
/// Note: Not all unit test have been created, so complete code coverage is not available (out of time).
/// 
/// The general idea is that for each property in the ActivityDto that the Activities component accesses
/// we have tests covering all possible validation messages (required, length checks etc) as well
/// as if the input is valid.
///
/// As well as full input checks for the Create Activity dialog, the Activities component will also require unit
/// tests for the UpdateActivity form. 
///
/// Walkthrough:
/// First we create a mock service using Moq and is set up to return a list of sample activities
/// when GetAllActivitiesAsync() is called.
///
/// The mock service instance (mockActivityService.Object) is then registered with the BUnit TestContext
/// using Services.AddSingleton() method. This ensures that when the Activities component or any other
/// component using IActivityService is rendered, it will use the mocked instance.
/// 
/// From here each test follows a fairly regular pattern. Checking that when "Create Activity" is
/// clicked, the form that loads displays the correct validation error messages depending on the input
/// for a given input field.
/// </summary>
public class ActivitiesComponentTests : TestContext
{
    public ActivitiesComponentTests()
    {
        var mockActivityService = new Mock<IActivityService>();
        mockActivityService.Setup(service => service.GetAllActivitiesAsync())
            .ReturnsAsync(new List<ActivityDto>
            {
                    new()
                    {
                        Id = 1,
                        Name = "Sample Activity",
                        Description = "This is a sample activity",
                        AddressLine1 = "123 Main St",
                        AddressLine2 = "Apt 4",
                        AddressLine3 = "",
                        Postcode = "12345",
                        ActivityStart = DateTime.Now.AddDays(1),
                        ActivityEnd = DateTime.Now.AddDays(2)
                    }
            });

        Services.AddSingleton(mockActivityService.Object);
    }

    [Fact]
    public void Empty_Name_ShouldShowValidationError()
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); // Click the "Create Activity" button

        // Act
        component.Find("#name").Change("");
        component.Find("form").Submit(); // Submit the form

        // Assert
        var validationMessage = component.Find(".validation-message").TextContent;
        Assert.Contains("Name is required", validationMessage); // Check for the validation message
    }

    [Theory]
    [InlineData("This name exceeds the limit of one hundred characters in length and should therefore be invalid for this test")]
    [InlineData("This name exceeds the limit of one hundred characters in length and should therefore be invalid test.")]
    public async Task LongName_ShouldShowValidationError(string name)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var postcodeInput = component.Find("#name");
        postcodeInput.Change(name);
        component.Find("form").Submit(); 
        await component.InvokeAsync(() => { });

        // Assert
        var validationMessage = component.Find("#name + .validation-message");
        Assert.Contains("Name length can't be more than 100 characters", validationMessage.InnerHtml); 
    }

    [Fact]
    public async Task Empty_Description_ShouldShowValidationError()
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); 

        // Act
        var descriptionInput = component.Find("#description");
        descriptionInput.Change(""); 
        component.Find("form").Submit(); 
        await component.InvokeAsync(() => { }); 

        // Assert
        var validationMessage = component.Find("#description + .validation-message");
        Assert.Contains("Description is required", validationMessage.InnerHtml); 
    }

    [Theory]
    [InlineData("Experience the rhythm of a lifetime at the Harmony Fest 2024! Join us for three unforgettable days of music, culture, and community from July 12th to July 14th in the serene foothills of Oak Valley. Harmony Fest is more than just a music festival; it's a celebration of creativity and togetherness, where people from all walks of life come together to share in the joy of live music and arts.\r\n\r\nThroughout the festival grounds, you'll discover multiple stages buzzing with energy, featuring over 50 live performances by top-tier international headliners, emerging artists poised to make their mark, and beloved local talents. From the infectious beats of indie rock and pulsating rhythms of electronic dance music to the soulful melodies of jazz and the eclectic sounds of world music, Harmony Fest offers a diverse lineup that promises something for every music lover.\r\n\r\nIndulge your taste buds with an array of culinary delights from our artisanal food vendors, showcasing gourmet treats and local delicacies that cater to all dietary preferences. Savor mouthwatering dishes while enjoying the immersive music experience, or relax in our chill-out zones with refreshing beverages and captivating street performances that add to the festival's vibrant atmosphere.\r\n\r\nBeyond the music, Harmony Fest invites you to explore interactive art installations that ignite the imagination and inspire creativity. Engage in hands-on workshops focused on sustainability, wellness, and arts and crafts, providing opportunities to learn and connect with like-minded individuals passionate about making a positive impact on the world.\r\n\r\nFamilies are welcome at Harmony Fest, with dedicated kids' zones offering entertainment and activities suitable for children of all ages. Parents can rest assured that the festival environment is safe, inclusive, and designed to ensure everyone has a memorable experience together.\r\n\r\nFor those seeking a deep connection with nature, Harmony Fest provides eco-friendly camping options available.")]
    [InlineData("Experience the rhythm of a lifetime at the Harmony Fest 2024! Join us for three unforgettable days of music, culture, and community from July 12th to July 14th in the serene foothills of Oak Valley. Harmony Fest is more than just a music festival; it's a celebration of creativity and togetherness, where people from all walks of life come together to share in the joy of live music and arts.\r\n\r\nThroughout the festival grounds, you'll discover multiple stages buzzing with energy, featuring over 50 live performances by top-tier international headliners, emerging artists poised to make their mark, and beloved local talents. From the infectious beats of indie rock and pulsating rhythms of electronic dance music to the soulful melodies of jazz and the eclectic sounds of world music, Harmony Fest offers a diverse lineup that promises something for every music lover.\r\n\r\nIndulge your taste buds with an array of culinary delights from our artisanal food vendors, showcasing gourmet treats and local delicacies that cater to all dietary preferences. Savor mouthwatering dishes while enjoying the immersive music experience, or relax in our chill-out zones with refreshing beverages and captivating street performances that add to the festival's vibrant atmosphere.\r\n\r\nBeyond the music, Harmony Fest invites you to explore interactive art installations that ignite the imagination and inspire creativity. Engage in hands-on workshops focused on sustainability, wellness, and arts and crafts, providing opportunities to learn and connect with like-minded individuals passionate about making a positive impact on the world.\r\n\r\nFamilies are welcome at Harmony Fest, with dedicated kids' zones offering entertainment and activities suitable for children of all ages. Parents can rest assured that the festival environment is safe, inclusive, and designed to ensure everyone has a memorable experience together.\r\n\r\nFor those seeking a deeper connection with nature, Harmony Fest provides eco-friendly camping options nestled amidst Oak Valley's picturesque landscapes. Spend your nights under the stars, surrounded by the tranquility of nature, and wake up to breathtaking views that rejuvenate the soul.")]
    public async Task LongDescription_ShouldShowValidationError(string description)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var postcodeInput = component.Find("#description");
        postcodeInput.Change(description); 
        component.Find("form").Submit(); 
        await component.InvokeAsync(() => { }); 

        // Assert
        var validationMessage = component.Find("#description + .validation-message");
        Assert.Contains("Description length can't be more than 2000 characters", validationMessage.InnerHtml); 
    }

    [Fact]
    public async Task Empty_AddressLine1_ShouldShowValidationError()
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); 

        // Act
        var addressLine1Input = component.Find("#addressLine1");
        addressLine1Input.Change("");
        component.Find("form").Submit(); 
        await component.InvokeAsync(() => { }); 

        // Assert
        var validationMessage = component.Find("#addressLine1 + .validation-message");
        Assert.Contains("Address Line 1 is required", validationMessage.InnerHtml);
    }

    [Fact]
    public async Task EmptyPostcode_ShouldShowValidationError()
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); 

        // Act
        var postcodeInput = component.Find("#postcode");
        postcodeInput.Change(""); 
        component.Find("form").Submit(); 
        await component.InvokeAsync(() => { }); 

        // Assert
        var validationMessage = component.Find("#postcode + .validation-message");
        Assert.Contains("Postcode is required", validationMessage.InnerHtml); 
    }

    [Theory]
    [InlineData("NotAPostcode")]
    [InlineData("MK87 7BYS")]
    public async Task LongPostcode_ShouldShowValidationError(string postcode)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var postcodeInput = component.Find("#postcode");
        postcodeInput.Change(postcode); 
        component.Find("form").Submit();
        await component.InvokeAsync(() => { }); 

        // Assert
        var validationMessage = component.Find("#postcode + .validation-message");
        Assert.Contains("Postcode length can't be more than 8 characters", validationMessage.InnerHtml); // Check for the validation message
    }

    [Theory]
    [InlineData("CV1 2LJ")]
    [InlineData("SW1A 2AB")]
    [InlineData("cv1 2lj")]
    [InlineData("sw1a 2ab")]
    [InlineData("CV12LJ")]
    [InlineData("SW1A2AB")]
    [InlineData("cv12lj")]
    [InlineData("sw1a2ab")]
    public async Task ValidPostCode_ShouldNotShowLengthValidationError(string postCode)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); 

        // Act
        var activityStartInput = component.Find("#postcode");
        activityStartInput.Change(postCode);
        component.Find("form").Submit();
        await component.InvokeAsync(() => { });
        await Task.Delay(100);

        // Assert
        var validationMessages = component.FindAll(".validation-message");
        var activityStartValidationMessageFound = validationMessages.Any(message => message.InnerHtml.Contains("Postcode length can't be more than 8 characters"));
        Assert.False(activityStartValidationMessageFound, "Validation message length violation for postcode should not be present.");
    }

    [Theory]
    [InlineData("CV1 2LJ")]
    [InlineData("SW1A 2AB")]
    [InlineData("cv1 2lj")]
    [InlineData("sw1a 2ab")]
    [InlineData("CV12LJ")]
    [InlineData("SW1A2AB")]
    [InlineData("cv12lj")]
    [InlineData("sw1a2ab")]
    public async Task ValidPostCode_ShouldNotShowRequiredValidationError(string postCode)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var activityStartInput = component.Find("#postcode");
        activityStartInput.Change(postCode);
        component.Find("form").Submit();
        await component.InvokeAsync(() => { }); 
        await Task.Delay(100); 

        // Assert
        var validationMessages = component.FindAll(".validation-message");
        var activityStartValidationMessageFound = validationMessages.Any(message => message.InnerHtml.Contains("Postcode is required"));
        Assert.False(activityStartValidationMessageFound, "Validation message for empty postcode should not be present.");
    }

    [Theory]
    [InlineData("2024-06-16")]
    [InlineData("10-10-2020")]
    public async Task InvalidActivityStart_NotInFuture_ShouldShowValidationError(string date)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); 

        // Act
        var activityStartInput = component.Find("#activityStart");
        activityStartInput.Change(date);
        component.Find("form").Submit();
        await component.InvokeAsync(() => { }); 

        // Assert
        var validationMessage = component.Find("#activityStart + .validation-message");
        Assert.Contains("Start date must be in the future", validationMessage.InnerHtml); 
    }

    [Theory]
    [InlineData("Not a date")]
    [InlineData("")]
    public async Task InvalidActivityStart_ShouldShowValidationError(string date)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click(); 

        // Act
        var activityStartInput = component.Find("#activityStart");
        activityStartInput.Change(date); 
        component.Find("form").Submit();
        await component.InvokeAsync(() => { });

        // Assert
        var validationMessage = component.Find("#activityStart + .validation-message");
        Assert.Contains("The ActivityStart field must be a date.", validationMessage.InnerHtml);
    }

    [Fact]
    public async Task ValidActivityStart_ShouldNotShowValidationError()
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var activityStartInput = component.Find("#activityStart");
        activityStartInput.Change(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")); 
        component.Find("form").Submit(); 
        await component.InvokeAsync(() => { });
        await Task.Delay(100);

        // Assert
        var validationMessages = component.FindAll(".validation-message");
        var activityStartValidationMessageFound = validationMessages.Any(message => message.InnerHtml.Contains("Start date must be in the future."));
        Assert.False(activityStartValidationMessageFound, "Validation message for activityStart should not be present.");
    }

    [Theory]
    [InlineData("2024-06-16")]
    [InlineData("10-10-2020")]
    public async Task InvalidActivityEnd_NotInFuture_ShouldShowValidationError(string date)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var activityStartInput = component.Find("#activityEnd");
        activityStartInput.Change(date);
        component.Find("form").Submit();
        await component.InvokeAsync(() => { });

        // Assert
        var validationMessage = component.Find("#activityEnd + .validation-message");
        Assert.Contains("End date must be in the future", validationMessage.InnerHtml);
    }

    [Theory]
    [InlineData("Not a date")]
    [InlineData("")]
    public async Task InvalidActivityEnd_ShouldShowValidationError(string date)
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var activityStartInput = component.Find("#activityEnd");
        activityStartInput.Change(date);
        component.Find("form").Submit();
        await component.InvokeAsync(() => { });

        // Assert
        var validationMessage = component.Find("#activityEnd + .validation-message");
        Assert.Contains("The ActivityEnd field must be a date.", validationMessage.InnerHtml);
    }

    [Fact]
    public async Task ValidActivityEnd_ShouldNotShowValidationError()
    {
        // Arrange
        var component = RenderComponent<Activities>();
        component.Find("button").Click();

        // Act
        var activityStartInput = component.Find("#activityEnd");
        activityStartInput.Change(DateTime.Now.AddDays(2).ToString("yyyy-MM-dd"));
        component.Find("form").Submit();
        await component.InvokeAsync(() => { });
        await Task.Delay(100);

        // Assert
        var validationMessages = component.FindAll(".validation-message");
        var activityStartValidationMessageFound = validationMessages.Any(message => message.InnerHtml.Contains("Start date must be in the future."));
        Assert.False(activityStartValidationMessageFound, "Validation message for activityEnd should not be present.");
    }
}
