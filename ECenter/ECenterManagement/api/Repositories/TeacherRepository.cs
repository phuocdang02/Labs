using api.DbContexts;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

/// <summary>
/// Teacher Repository
/// </summary>
public class TeacherRepository
{
    private readonly ECenterDbContext _context;

    /// <summary>
    /// Initializes a new instance of the context
    /// </summary>
    /// <param name="context"></param>
    public TeacherRepository(ECenterDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all teachers from database
    /// </summary>
    /// <returns></returns>
    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _context.Teachers.ToListAsync();
    }

    /// <summary>
    /// Gets a teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Teacher?> GetByIdAsync(Guid id)
    {
        return await _context.Teachers.FindAsync(id);
    }

    /// <summary>
    /// Adds a new teacher to database
    /// </summary>
    /// <param name="teacher"></param>
    /// <returns></returns>
    public async Task<Teacher> AddSync(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
        return teacher;
    }

    /// <summary>
    /// Updates an existing teacher
    /// </summary>
    /// <param name="teacher"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        return await _context.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Deletes a teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DelelteAsync(Guid id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null) return false;

        _context.Teachers.Remove(teacher);
        return await _context.SaveChangesAsync() > 0;
    }
}
