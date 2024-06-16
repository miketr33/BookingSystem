using EventBookingApi.Dtos;
using EventBookingApi.Models;
using EventBookingApi.Repositories;
using EventBookingApi.Services;
using EventBookingApi.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddTransient<IValidator<ModifiedAttendeeDto>, ModifyAttendeeDtoValidator>();
builder.Services.AddTransient<IValidator<ModifyActivityDto>, ModifyActivityDtoValidator>();
builder.Services.AddTransient<IValidator<ModifyBookingDto>, ModifyBookingDtoValidator>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EventBookingDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddLogging();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();