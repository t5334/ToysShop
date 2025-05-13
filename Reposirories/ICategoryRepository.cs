using Entities;

namespace Reposirories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
    }
}