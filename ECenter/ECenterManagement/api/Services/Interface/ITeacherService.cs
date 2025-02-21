using api.Models;

namespace api.Services.Interface;

/// <summary>
/// Interface of schedule service
/// </summary>
public interface ITeacherService
{
    /// <summary>
    /// Gets all teachers
    /// </summary>
    /// <returns></returns>
    Task<List<Teacher>> GetAllAsync();

    /// <summary>
    /// Gets teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Teacher?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a new teacher
    /// </summary>
    /// <param name="teacher"></param>
    /// <returns></returns>
    Task<Teacher> AddAsync(Teacher teacher);

    /// <summary>
    /// Updates an existing teacher
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedTeacher"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(Guid id, Teacher updatedTeacher);

    /// <summary>
    /// Deletes teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);
}
