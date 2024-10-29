using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class DrinkRepo : IDrinkRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public DrinkRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Drink>> GetAll()
        {
            return await _dbContext.Drinks.ToListAsync();
        }

        public async Task<Drink?> GetBy(Guid id)
        {
            return await _dbContext.Drinks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Update(Drink drink)
        {
            _dbContext.Drinks.Update(drink);
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}