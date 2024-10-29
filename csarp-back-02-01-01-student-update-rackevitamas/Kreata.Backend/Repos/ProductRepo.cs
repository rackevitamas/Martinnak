using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly KretaInMemoryContext _dbContext;
        public ProductRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetBy(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Update(Product product)
        {
            _dbContext.Products.Update(product);
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}