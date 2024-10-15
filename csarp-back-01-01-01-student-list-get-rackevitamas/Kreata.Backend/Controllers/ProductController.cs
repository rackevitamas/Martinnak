using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> SelectAllProductAsync()
        {
            List<Product>? products = new();
            if (_productRepo is not null)
            {
                products = await _productRepo.GetAll();
                return Ok(products);
            }
            return BadRequest("Termék adatok elérhetetlen");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Product? product = new();
            if (product is not null)
            {
                product = await _productRepo.GetBy(id);
                if (product is not null)
                {
                    return Ok(product);
                }
            }
            return BadRequest("Termék adatok elérhetetlen");
        }
    }
}
