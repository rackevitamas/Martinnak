using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DolgozoController : ControllerBase
    {
        private readonly IDolgozoRepo _dolgozoRepo;
        public DolgozoController(IDolgozoRepo dolgozoRepo)
        {
            _dolgozoRepo = dolgozoRepo;
        }
        [HttpGet]
        public async Task<IActionResult> SelectAllDrinkAsync()
        {
            List<Dolgozo>? dolgozok = new();
            if (_dolgozoRepo is not null)
            {
                dolgozok = await _dolgozoRepo.GetAll();
                return Ok(dolgozok);
            }
            return BadRequest("Dolgoz� adatok el�rhetetlen");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Dolgozo? dolgozo = new();
            if (_dolgozoRepo is not null)
            {
                dolgozo = await _dolgozoRepo.GetBy(id);
                if (dolgozo is not null)
                {
                    return Ok(dolgozo);
                }
            }
            return BadRequest("Dolgoz� adatok el�rhetetlen");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDolgozo(Guid id, [FromBody] Dolgozo updatedDolgozo)
        {
            if (_dolgozoRepo== null)
                return BadRequest("Az adatok elérhetetlenek!");

            var existingDolgozo= await _dolgozoRepo.GetBy(id);
            if (existingDolgozo == null)
                return NotFound("A diák nem található!");

            existingDolgozo.Name = updatedDolgozo.Name;
            existingDolgozo.Age = updatedDolgozo.Age;
            existingDolgozo.Hataskor = updatedDolgozo.Hataskor;

            var result = await _dolgozoRepo.Update(existingDolgozo);
            if (result)
                return Ok(existingDolgozo);

            return StatusCode(StatusCodes.Status500InternalServerError, "A frissítés sikertelen volt.");
        }

    }

}