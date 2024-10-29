using Kreata.Backend.Datas.Entities;

namespace Kreata.Backend.Repos
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetBy(Guid id);
        Task<bool> Update(Product existingProduct);
    }
}