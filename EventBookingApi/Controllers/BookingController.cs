using AutoMapper;
using EventBookingApi.Dtos;
using EventBookingApi.Models;
using EventBookingApi.Services;
using EventBookingShared.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController(
    IBookingService bookingService,
    IAttendeeService attendeeService,
    IActivityService activityService,
    IMapper mapper,
    IValidator<ModifyBookingDto> validator) : ControllerBase
{
    // POST: api/booking
    [HttpPost]
    public async Task<IActionResult> CreateBooking(ModifyBookingDto? bookingDto)
    {
        if (bookingDto == null) return BadRequest();
        var validationResult = await validator.ValidateAsync(bookingDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        // Check if the activity exists
        var activity = await activityService.GetActivityById(bookingDto.ActivityId);
        if (activity == null) return BadRequest($"ActivityDetails with ID {bookingDto.ActivityId} does not exist.");

        // Check if the attendee exists
        var attendee = await attendeeService.GetAttendeeById(bookingDto.AttendeeId);
        if (attendee == null) return BadRequest($"Attendee with ID {bookingDto.AttendeeId} does not exist.");

        var booking = mapper.Map<Booking>(bookingDto);

        await bookingService.CreateBooking(booking);
        var createdDto = mapper.Map<BookingDto>(booking);
        return Ok(createdDto);
    }

    // GET: api/booking
    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await bookingService.GetAllBookings();
        if (bookings.Count == 0) return NotFound();

        var bookingDtos = mapper.Map<List<BookingDto>>(bookings);
        return Ok(bookingDtos);
    }

    // GET: api/booking/activity/1
    [HttpGet("activity/{activityId:int}")]
    public async Task<IActionResult> GetBookingByActivityId(int activityId)
    {
        if (activityId == 0) return BadRequest($"{nameof(activityId)} cannot be 0.");
        var bookings = await bookingService.GetBookingsByActivityId(activityId);
        if (bookings.Count == 0) return NotFound();

        var bookingDtos = mapper.Map<List<BookingDto>>(bookings);
        return Ok(bookingDtos);
    }

    // GET: api/booking/attendee/1
    [HttpGet("attendee/{attendeeId:int}")]
    public async Task<IActionResult> GetBookingByAttendeeId(int attendeeId)
    {
        if (attendeeId == 0) return BadRequest($"{nameof(attendeeId)} cannot be 0.");
        var bookings = await bookingService.GetBookingsByAttendeeId(attendeeId);
        if (bookings.Count == 0) return NotFound();

        var bookingDtos = mapper.Map<List<BookingDto>>(bookings);
        return Ok(bookingDtos);
    }

    // GET: api/booking/attendee/1/activity/1
    [HttpGet("attendee/{attendeeId:int}/activity/{activityId:int}")]
    public async Task<IActionResult> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId)
    {
        if (attendeeId == 0) return BadRequest($"{nameof(attendeeId)} cannot be 0.");
        if (activityId == 0) return BadRequest($"{nameof(activityId)} cannot be 0.");
        var booking = await bookingService.GetBookingByAttendeeIdAndActivityId(attendeeId, activityId);
        if (booking == null) return NotFound();

        var bookingDto = mapper.Map<BookingDto>(booking);
        return Ok(bookingDto);
    }

    // GET: api/booking/1
    [HttpGet("{bookingId:int}")]
    public async Task<IActionResult> GetBookingByBookingId(int bookingId)
    {
        if (bookingId == 0) return BadRequest($"{nameof(bookingId)} cannot be 0.");
        var booking = await bookingService.GetBookingByBookingId(bookingId);
        if (booking == null) return NotFound();

        var bookingDto = mapper.Map<BookingDto>(booking);
        return Ok(bookingDto);
    }

    // PUT: api/booking/1
    [HttpPut("{bookingId:int}")]
    public async Task<IActionResult> UpdateBooking(int bookingId, ModifyBookingDto bookingDto)
    {
        if (bookingId == 0) return BadRequest($"{nameof(bookingId)} cannot be 0.");
        var validationResult = await validator.ValidateAsync(bookingDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var existingBooking = await bookingService.GetBookingByBookingId(bookingId);
        if (existingBooking == null) return NotFound();

        mapper.Map(bookingDto, existingBooking);

        existingBooking.Id = bookingId;
        await bookingService.UpdateBooking(existingBooking);

        return NoContent();
    }

    // DELETE: api/booking/1
    [HttpDelete("{bookingId:int}")]
    public async Task<IActionResult> DeleteBooking(int bookingId)
    {
        if (bookingId == 0) return BadRequest($"{nameof(bookingId)} cannot be 0.");
        await bookingService.DeleteBooking(bookingId);
        return NoContent();
    }
}