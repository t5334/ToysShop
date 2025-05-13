using Entities;

namespace Reposirories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct();
    }
}