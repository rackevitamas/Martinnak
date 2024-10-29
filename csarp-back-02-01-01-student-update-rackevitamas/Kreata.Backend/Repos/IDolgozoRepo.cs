using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IDolgozoRepo
    {
        Task<List<Dolgozo>> GetAll();
        Task<Dolgozo?> GetBy(Guid id);
        Task<bool> Update(Dolgozo existingDolgozo);
    }
}