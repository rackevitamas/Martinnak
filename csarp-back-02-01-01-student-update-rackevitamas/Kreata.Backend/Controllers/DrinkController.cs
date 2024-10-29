using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkRepo _drinkrepo;
        public DrinkController(IDrinkRepo drinkRepo)
        {
            _drinkrepo = drinkRepo;
        }
        [HttpGet]
        public async Task<IActionResult> SelectAllDrinkAsync()
        {
            List<Drink>? drinks = new();
            if (_drinkrepo is not null)
            {
                drinks = await _drinkrepo.GetAll();
                return Ok(drinks);
            }
            return BadRequest("Ital adatok el�rhetetlen");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Drink? drink = new();
            if (_drinkrepo is not null)
            {
                drink = await _drinkrepo.GetBy(id);
                if (drink is not null)
                {
                    return Ok(drink);
                }
            }
            return BadRequest("Ital adatok el�rhetetlen");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrink(Guid id, [FromBody] Drink updatedDrink)
        {
            if (_drinkrepo == null)
                return BadRequest("Az adatok elérhetetlenek!");

            var existingDrink= await _drinkrepo.GetBy(id);
            if (existingDrink == null)
                return NotFound("A diák nem található!");

            existingDrink.Name = updatedDrink.Name;
            existingDrink.ItalCsalad = updatedDrink.ItalCsalad;
            existingDrink.IsAlcohol = updatedDrink.IsAlcohol;
            existingDrink.Price = updatedDrink.Price;

            var result = await _drinkrepo.Update(existingDrink);
            if (result)
                return Ok(existingDrink);

            return StatusCode(StatusCodes.Status500InternalServerError, "A frissítés sikertelen volt.");
        }
    }

}