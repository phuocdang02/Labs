using api.Models;
using api.Repositories;
using api.Services.Interface;

namespace api.Services;

/// <summary>
/// Teacher service
/// </summary>
public class TeacherService : ITeacherService
{
    private readonly IRepository<Teacher> _repository;

    /// <summary>
    /// Initializes a new instance of the repository
    /// </summary>
    /// <param name="repository"></param>
    public TeacherService(IRepository<Teacher> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Gets all teachers from repository
    /// </summary>
    /// <returns></returns>
    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /// <summary>
    /// Gets a teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Teacher?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    /// <summary>
    /// Adds a new teacher
    /// </summary>
    /// <param name="teacher"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Teacher> AddAsync(Teacher teacher)
    {
        var existingTeachers = await _repository.GetAllAsync();
        if (existingTeachers.Any(x => x.PersonalEmailAddress == teacher.PersonalEmailAddress))
        {
            throw new Exception("A teacher with this email already exists.");
        }

        return await _repository.AddAsync(teacher);
    }

    /// <summary>
    /// Updates an existing teacher
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedTeacher"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Guid id, Teacher updatedTeacher)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher is null) return false;

        teacher.FullName = updatedTeacher.FullName;
        teacher.Phone = updatedTeacher.Phone;
        teacher.PersonalEmailAddress = updatedTeacher.PersonalEmailAddress;
        teacher.BusinessEmailAddress = updatedTeacher.BusinessEmailAddress;

        return await _repository.UpdateAsync(teacher);
    }

    /// <summary>
    /// Deletes a teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
