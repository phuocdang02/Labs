using api.Models;
using api.Repositories;
using api.Services.Interface;

namespace api.Services;

/// <summary>
/// Schedule service
/// </summary>
public class ScheduleService : IScheduleService
{
    private readonly IRepository<Schedule> _repository;

    /// <summary>
    /// Initialize a new instance of the repository
    /// </summary>
    /// <param name="repository"></param>
    public ScheduleService(IRepository<Schedule> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets all schedules from repository
    /// </summary>
    /// <returns></returns>
    public async Task<List<Schedule>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /// <summary>
    /// Gets a schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Schedule?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    /// <summary>
    /// Adds a new schedule to repository
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Schedule> AddAsync(Schedule schedule)
    {
        if (schedule.StartDate >= schedule.EndDate)
        {
            throw new Exception("Start time must be before end date.");
        }

        return await _repository.AddAsync(schedule);
    }

    /// <summary>
    /// Updates an existing schedule
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedSchedule"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Guid id, Schedule updatedSchedule)
    {
        var schedule = await _repository.GetByIdAsync(id);
        if (schedule is null) return false;

        schedule.StartDate = updatedSchedule.StartDate;
        schedule.EndDate = updatedSchedule.EndDate;

        return await _repository.UpdateAsync(schedule);
    }

    /// <summary>
    /// Deletes a schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
