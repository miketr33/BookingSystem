
# Introduction
This project is a event booking system that uses combines the usage of a web Application Programming Interface (API) in the backend with a Blazor web application in the frontend to allow a user to to manage attendees, activities and bookings for events. 

The focus is currently on functionality over appearance, therefore little time has been spent on look-and-feel at this point. 

_Note: In this project the word 'Activity' is used in place of 'Event' this is to reduce confusion as event has a different meaning in many programming languages. This could be changed at a later date._
# Setup & Usage

### Database
To create the relevant database and tables in your local environment, follow these steps:

1. Open the solution in Visual Studio.
2. Open the Package Manager Console.
3. Enter: `UPDATE-DATABASE`
4. Once the console says `Done.`, check that your database exists in SQL Server Management Studio or similar.
5. Get the connection string for you new databse and add it to `appsettings.json` within the `EventBookingApi` project. Make sure that TrustServerCerticate=True and ConnectionTimeout=30 (this may change in the future). Example: `data source=<MACHINE-NAME>;initial catalog=<DATABASE-NAME>;trusted_connection=true;TrustServerCertificate=True;Connection Timeout=30;`

If you make any changes to the `EventBookingShared/Models` folder or wish to add other SQL functionality such as Stored Procedures, you will need to create a new migration. This can be done by using the `ADD-MIGRATION` command. More info on EF Core Code-First databases can be found [here](https://medium.com/@vndpal/how-to-connect-net-web-api-with-sql-server-using-entity-framework-code-first-approach-8564192485c9).

_Please Note: The database is not seeded with test data, so on first load get requests will not return any results. Please make create new entries before running get/put requests._

### Startup Projects

In order for the WebApp to connect with the API, you must start both projects. To do this in Visual Studio:

1. Right-click the solution in the Solution Explorer.
2. Select `Configure Startup Projects`.
3. Ensure that both `EventBookingApi` and `EventBookingWebApp` are set to `Start`. The rest should be set to `None`.
4. Click the Start button to compile and run your code. You should see two browser windows: one showing the Swagger/OpenApi specification for the API and the other showing the Blazor Web App frontend. You can interact with both windows to test the functionality.

### Swagger/OpenApi Spec

This specification shows all the endpoints for the API, separated into Activity (aka an Event), Attendee, and Booking sections with Create, Read, Update, Delete (CRUD) operations available for each. There are four ways to test these endpoints:

- Using the Swagger/OpenApi spec itself, click `Try it out`.
- Using the provided Blazor Web App.
- Using a third-party application such as Postman to make a request to a given endpoint.
- Additional applications could also be written to utilize this API.

# Technologies Used

This project was created using .NET 8, [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor), SQL Server, and [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) (EF Core) Microsoft technologies. EF Core is an Object Relational Mapper (ORM) that uses a code-first approach to create and map to the relevant database and tables required by this project. Follow the Setup & Usage steps above to get a local database up and running.

In addition to key Microsoft technologies, the following were used:

- [FluentValidation](https://docs.fluentvalidation.net/en/latest/): For defining and enforcing validation rules on the API. Although there are some input validation rules on the Blazor front end, if someone uses another application (such as Postman) to make a request to the API, any inputs not matching the acceptance rules will be rejected. These validation rules are checked by corresponding unit tests.
- [AutoMapper](https://github.com/AutoMapper/AutoMapper): Used for automatically mapping Data Transfer Objects (DTOs), eliminating the need for manual mapping logic throughout.
- [xUnit](https://xunit.net/): An open-source unit testing tool. Examples of its usage can be found in the `EventBookingApiTests` and `EventBookingWebAppTests` projects.
- [bUnit](https://bunit.dev/): A testing library for Blazor components. It builds on top of xUnit and is used primarily for unit tests on input validation, but it has more functionality that could be useful in the future. Example unit tests can be found in `EventBookingWebAppTests`.
- [Moq](https://github.com/devlooped/moq): A mocking library for .NET. It can be used to mock classes and interfaces, providing consistent behavior during tests. Examples of its usage can be found in `EventBookingWebAppTests/ActivitiesComponentTests.cs` where the `ActivityService` is mocked.

# Future Improvements

Below are some improvements that can be made to the current solution. This list is not exhaustive, as the purpose of this effort was to create a Minimum Viable Product (MVP) to build upon.

- **Booking Component Checks**:
    
    - **Issue 1**: In the Booking component, there are is a check to ensure the activity and attendee exist, however this fails silently. Meaning if either do not exist the booking dialog just closes.
    	- **Proposed Resolution**: Add some logic to indicate to the user that a booking cannot be made as the activity/attendee does not exist.
    - **Issue 2**: It is currently possible to delete an activity or attendee that is attached to an existing booking.
    	- **Proposed Resolution**: Add logic to either prevent deletion, or cascade deletion so that if an activity/attendee is deleted, then any corresponding bookings will also be deleted. Either way the user should be informed. 
- **Logging**:
    
    - Currently, there is no logging implemented throughout the solution. Logging could be useful for audit and debugging processes. However, care must be taken around Personal Identifiable Information (PII), and GDPR rules must be followed.
- **Unit Tests**:
    
    - For the WebApi project, a suite of unit tests using xUnit has been created focusing on validation. These tests would benefit from rigorous scrutiny from multiple developers and testers.
    - For the WebApp project, a suite using xUnit with bUnit and Moq has been created. This suite currently focuses on input validation for the Activities component. Due to time constraints, they are not complete, and no other components have unit tests. It is strongly recommended that all components have in-depth unit tests offering as much code coverage as possible. Test should cover happy, unhappy and edge case paths to create confidence in the application. All unit tests can be built into the app pipeline so that no code is merged without first passing unit tests.

- **Look and Feel:**
	- As the focus has been on functionality over look and feel so far, some time should be spent devising a consistent style guide/theme for the Blazor web app. It should ensure a positive user experience that is easy to understand without excessive explanation. 
	- We may want to consider using third party component libraries in the future improved functionality and appearance, as well as reduced developer times. Some examples of libraries are: [BlazorStrap](https://blazorstrap.io/), [MudBlazor](https://mudblazor.com/) and [Syncfusion](https://www.syncfusion.com/blazor-components) 
