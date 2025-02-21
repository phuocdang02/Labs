using api.DbContexts;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

/// <summary>
/// Schedule repository
/// </summary>
public class ScheduleRepository: IRepository<Schedule>
{
    private readonly ECenterDbContext _context;

    /// <summary>
    /// Initializes a new instance of the context
    /// </summary>
    /// <param name="context"></param>
    public ScheduleRepository(ECenterDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all schedules from database
    /// </summary>
    /// <returns></returns>
    public async Task<List<Schedule>> GetAllAsync()
    {
        return await _context.Schedules.ToListAsync();
    }

    /// <summary>
    /// Gets a schedule by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Schedule?> GetByIdAsync(Guid id)
    {
        return await _context.Schedules.FindAsync(id);
    }

    /// <summary>
    /// Adds a new schedule to database
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    public async Task<Schedule> AddAsync(Schedule schedule)
    {
        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();
        return schedule;
    }

    /// <summary>
    /// Updates an existing schedule
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
        return await _context.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Deletes a schedule by ID 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null) return false;

        _context.Schedules.Remove(schedule);
        return await _context.SaveChangesAsync() > 0;
    }
}
