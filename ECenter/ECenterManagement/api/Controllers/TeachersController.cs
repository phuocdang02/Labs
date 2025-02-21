using api.Models;
using api.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

/// <summary>
/// Teacher API controller
/// </summary>
[Route("api/teachers")]
//[Authorize]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _service;
    //private readonly FakeDataService _fakeDataService;

    /// <summary>
    /// Initializes a new instance of service
    /// </summary>
    /// <param name="service"></param>
    public TeachersController(ITeacherService service)
    {
        //_fakeDataService = fakeDataService;
        _service = service;
    }

    /// <summary>
    /// Get all teachers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teacher = await _service.GetAllAsync();
        return Ok(teacher);
    }

    /// <summary>
    /// Get teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var teacher = await _service.GetByIdAsync(id);
        return teacher is not null ? Ok(teacher) : NotFound();
    }

    /// <summary>
    /// Create a new teacher
    /// </summary>
    /// <param name="teacher"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(Teacher teacher)
    {
        var newTeacher = await _service.AddAsync(teacher);
        return CreatedAtAction(nameof(GetById), new { id = newTeacher.Id }, newTeacher);
    }

    /// <summary>
    /// Update an existing teacher
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedTeacher"></param>
    /// <returns></returns>
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, Teacher updatedTeacher)
    {
        var teacher = await _service.GetByIdAsync(id);
        if (teacher is null) return NotFound();

        teacher.FullName = updatedTeacher.FullName;
        teacher.Phone = updatedTeacher.Phone;
        teacher.PersonalEmailAddress = updatedTeacher.PersonalEmailAddress;
        teacher.BusinessEmailAddress = updatedTeacher.BusinessEmailAddress;

        return await _service.UpdateAsync(id, updatedTeacher) ? NoContent() : NotFound();
    }

    /// <summary>
    /// Delete teacher by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }

    //[HttpGet]
    //public ActionResult<List<Teacher>> GetTeachers()
    //{
    //    var teachers = _fakeDataService.GenerateFakeTeachers(10);
    //    return Ok(teachers);
    //}

    //[HttpGet("schedules")]
    //public ActionResult<List<Schedule>> GetSchedules()
    //{
    //    var teachers = _fakeDataService.GenerateFakeTeachers(10);

    //    var schedules = _fakeDataService.GenerateFakeSchedules(10, teachers);
    //    return Ok(schedules);
    //}
}
