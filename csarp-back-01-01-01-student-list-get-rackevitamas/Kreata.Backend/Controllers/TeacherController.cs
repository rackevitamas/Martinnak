using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepo _teacherRepo;
        public TeacherController(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }
        [HttpGet]
        public async Task<IActionResult> SelectAllTeacherAsync()
        {
            List<Teacher>? teachers = new();
            if (_teacherRepo is not null)
            {
                teachers = await _teacherRepo.GetAll();
                return Ok(teachers);
            }
            return BadRequest("Tanár adatok elérhetetlen!");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy (Guid id)
        {
            Teacher? teacher = new();
            if (_teacherRepo is not null)
            {
                teacher = await _teacherRepo.GetBy(id);
                if (teacher is not null)
                {
                    return Ok(teacher);
                }
            }
            return BadRequest("Tanár adatok elérhetetlenek");
        }
    }
}
