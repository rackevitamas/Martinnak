using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class ParentRepo : IParentRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public ParentRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<List<Parent>> IParentRepo.GetAll()
        {
            return await _dbContext.Parents.ToListAsync();
        }

        async Task<Parent?> IParentRepo.GetBy(Guid id)
        {
            return await _dbContext.Parents.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
