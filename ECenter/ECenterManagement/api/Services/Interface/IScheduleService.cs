using api.Models;

namespace api.Services.Interface;

/// <summary>
/// Interface of schedule service
/// </summary>
public interface IScheduleService
{
    /// <summary>
    /// Gets all schedules
    /// </summary>
    /// <returns></returns>
    Task<List<Schedule>> GetAllAsync();

    /// <summary>
    /// Gets schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Schedule?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Adds a new schedule
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    Task<Schedule> AddAsync(Schedule schedule);

    /// <summary>
    /// Updates an existing schedule
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedSchedule"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(Guid id, Schedule updatedSchedule);

    /// <summary>
    /// Deletes schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);
}
