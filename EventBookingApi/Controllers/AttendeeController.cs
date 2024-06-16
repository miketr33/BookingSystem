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
public class AttendeeController(
    IAttendeeService attendeeService,
    IMapper mapper,
    IValidator<ModifiedAttendeeDto> validator) : ControllerBase
{
    // POST: api/attendee
    [HttpPost]
    public async Task<IActionResult> CreateAttendee(ModifiedAttendeeDto? attendeeDto)
    {
        if (attendeeDto == null) return BadRequest();

        var validationResult = await validator.ValidateAsync(attendeeDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var attendee = mapper.Map<Attendee>(attendeeDto);

        await attendeeService.CreateAttendee(attendee);
        var createdDto = mapper.Map<AttendeeDto>(attendee);
        return Ok(createdDto);
    }

    // GET: api/attendee
    [HttpGet]
    public async Task<IActionResult> GetAllAttendees()
    {
        var attendees = await attendeeService.GetAttendees();
        if (attendees.Count == 0) return NotFound();

        var attendeeDto = mapper.Map<List<AttendeeDto>>(attendees);
        return Ok(attendeeDto);
    }

    // GET: api/attendee/1
    [HttpGet("{attendeeId:int}")]
    public async Task<IActionResult> GetAttendeeById(int attendeeId)
    {
        if (attendeeId == 0) return BadRequest($"{nameof(attendeeId)} cannot be 0.");
        var attendee = await attendeeService.GetAttendeeById(attendeeId);
        if (attendee == null) return NotFound();

        var attendeeDto = mapper.Map<AttendeeDto>(attendee);
        return Ok(attendeeDto);
    }

    // PUT: api/attendee/1
    [HttpPut("{attendeeId:int}")]
    public async Task<IActionResult> UpdateAttendee(int attendeeId, ModifiedAttendeeDto attendeeDto)
    {
        if (attendeeId == 0) return BadRequest($"{nameof(attendeeId)} cannot be 0.");
        var validationResult = await validator.ValidateAsync(attendeeDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var existingAttendee = await attendeeService.GetAttendeeById(attendeeId);
        if (existingAttendee == null) return NotFound();

        mapper.Map(attendeeDto, existingAttendee);

        await attendeeService.UpdateAttendee(existingAttendee);
        return NoContent();
    }

    // DELETE: api/attendee/1
    [HttpDelete("{attendeeId:int}")]
    public async Task<IActionResult> DeleteAttendee(int attendeeId)
    {
        if (attendeeId == 0) return BadRequest($"{nameof(attendeeId)} cannot be 0.");
        await attendeeService.DeleteAttendee(attendeeId);
        return NoContent();
    }
}