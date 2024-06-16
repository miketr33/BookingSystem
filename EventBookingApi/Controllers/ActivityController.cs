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
public class ActivityController(
    IActivityService activityService,
    IMapper mapper,
    IValidator<ModifyActivityDto> validator) : ControllerBase
{
    // POST: api/activity
    [HttpPost]
    public async Task<IActionResult> CreateActivity(ModifyActivityDto? activityDto)
    {
        if (activityDto == null) return BadRequest();
        var validationResult = await validator.ValidateAsync(activityDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var activity = mapper.Map<ActivityDetails>(activityDto);

        await activityService.CreateActivity(activity);
        var createdDto = mapper.Map<ActivityDto>(activity);
        return Ok(createdDto);
    }

    // GET: api/activity
    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        var activities = await activityService.GetActivities();
        if (activities.Count == 0) return NotFound();

        var activitiesDto = mapper.Map<List<ActivityDto>>(activities);
        return Ok(activitiesDto);
    }

    // GET: api/activity/1
    [HttpGet("{activityId:int}")]
    public async Task<IActionResult> GetActivityById(int activityId)
    {
        if (activityId == 0) return BadRequest($"{nameof(activityId)} cannot be 0.");
        var activity = await activityService.GetActivityById(activityId);
        if (activity == null) return NotFound();

        return Ok(mapper.Map<ActivityDto>(activity));
    }

    // PUT: api/activity/1
    [HttpPut("{activityId:int}")]
    public async Task<IActionResult> UpdateActivity(int activityId, ModifyActivityDto activityDto)
    {
        if (activityId == 0) return BadRequest($"{nameof(activityId)} cannot be 0.");

        var validationResult = await validator.ValidateAsync(activityDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var existingActivity = await activityService.GetActivityById(activityId);
        if (existingActivity == null) return NotFound();

        mapper.Map(activityDto, existingActivity);

        await activityService.UpdateActivity(existingActivity);
        return NoContent();
    }

    // DELETE: api/activity/1
    [HttpDelete("{activityId:int}")]
    public async Task<IActionResult> DeleteActivity(int activityId)
    {
        if (activityId == 0) return BadRequest($"{nameof(activityId)} cannot be 0.");
        await activityService.DeleteActivity(activityId);
        return NoContent();
    }
}