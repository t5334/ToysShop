using Entities;
using DTO;
namespace Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategories();
    }
}