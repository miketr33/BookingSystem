using EventBookingWebApp.Components;
using EventBookingWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddHttpClient<ActivityService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7200/");
});
builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddHttpClient<AttendeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7200/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
