using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : Controller
    {
        private readonly FakeDataService _fakeDataService;

        public TeachersController(FakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;
        }

        [HttpGet]
        public ActionResult<List<Teachers>> GetTeachers()
        {
            var teachers = _fakeDataService.GenerateFakeTeachers(10);
            return Ok(teachers);
        }

        [HttpGet("schedules")]
        public ActionResult<List<Schedules>> GetSchedules()
        {
            var teachers = _fakeDataService.GenerateFakeTeachers(10);

            var schedules = _fakeDataService.GenerateFakeSchedules(10, teachers);
            return Ok(schedules);
        }
    }
}
