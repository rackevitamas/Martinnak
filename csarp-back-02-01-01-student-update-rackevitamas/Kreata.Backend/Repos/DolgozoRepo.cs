using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class DolgozoRepo : IDolgozoRepo
    {

        private readonly KretaInMemoryContext _dbContext;

        public DolgozoRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dolgozo>> GetAll()
        {
            return await _dbContext.Dolgozok.ToListAsync();
        }

        public async Task<Dolgozo?> GetBy(Guid id)
        {
            return await _dbContext.Dolgozok.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<bool> Update(Dolgozo dolgozo)
        {
            _dbContext.Dolgozok.Update(dolgozo);
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}