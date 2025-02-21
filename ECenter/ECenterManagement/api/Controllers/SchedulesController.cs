using api.Models;
using api.Repositories;
using api.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

/// <summary>
/// Schedule API controller
/// </summary>
//[ApiController]
[Authorize]
[Route("api/schedules")]
public class SchedulesController : ControllerBase
{
    private readonly IScheduleService _service;

    /// <summary>
    /// Initializes a new instance of service
    /// </summary>
    /// <param name="service"></param>
    public SchedulesController(IScheduleService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get all schedules
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var schedules = await _service.GetAllAsync();
        return Ok(schedules);
    }

    /// <summary>
    /// Get schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var schedule = await _service.GetByIdAsync(id);
        return schedule is not null ? Ok(schedule) : NotFound();
    }

    /// <summary>
    /// Create a new schedule
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(Schedule schedule)
    {
        var newSchedule = await _service.AddAsync(schedule);
        return CreatedAtAction(nameof(GetById), new { id = newSchedule.Id }, newSchedule);
    }

    /// <summary>
    /// Update an existing schedule
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedSchedule"></param>
    /// <returns></returns>
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, Schedule updatedSchedule)
    {
        var schedule = await _service.GetByIdAsync(id);
        if (schedule is null) return NotFound();

        schedule.StartDate = updatedSchedule.StartDate;
        schedule.EndDate = updatedSchedule.EndDate;
        schedule.Subject = updatedSchedule.Subject;

        return await _service.UpdateAsync(id, updatedSchedule) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Delete schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
