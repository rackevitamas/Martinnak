using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Student>? users = new();

            if (_studentRepo != null)
            {
                users = await _studentRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Student? entity = new();
            if (_studentRepo is not null)
            {
                entity = await _studentRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] Student updatedStudent)
        {
            if (_studentRepo == null)
                return BadRequest("Az adatok elérhetetlenek!");

            var existingStudent = await _studentRepo.GetBy(id);
            if (existingStudent == null)
                return NotFound("A diák nem található!");

            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.BirthsDay = updatedStudent.BirthsDay;
            existingStudent.SchoolYear = updatedStudent.SchoolYear;
            existingStudent.SchoolClass = updatedStudent.SchoolClass;
            existingStudent.EducationLevel = updatedStudent.EducationLevel;
            existingStudent.IsWoomen = updatedStudent.IsWoomen;

            var result = await _studentRepo.Update(existingStudent);
            if (result)
                return Ok(existingStudent);

            return StatusCode(StatusCodes.Status500InternalServerError, "A frissítés sikertelen volt.");
        }

    }
}
