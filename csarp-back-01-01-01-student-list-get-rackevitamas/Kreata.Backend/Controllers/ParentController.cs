using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepo _parentRepo;
        public ParentController(IParentRepo parentRepo)
        {
            _parentRepo = parentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> SelectAllParentAsync()
        {
            List<Parent>? parents = new();
            if (_parentRepo is not null)
            {
                parents = await _parentRepo.GetAll();
                return Ok(parents);
            }
            return BadRequest("Szülő adatok elérhetetlen");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy (Guid id)
        {
            Parent? parent = new();
            if (_parentRepo is not null)
            {
                parent = await _parentRepo.GetBy(id);
                if (parent is not null)
                {
                    return Ok(parent);
                }
            }
            return BadRequest("Szülő adatok elérhetetlen");
        }
    }
}
