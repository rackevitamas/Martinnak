using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IDrinkRepo
    {
        Task<List<Drink>> GetAll();
        Task<Drink?> GetBy(Guid id);
        Task<bool> Update(Drink existingDrink);
    }
}