using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposirories
{
    public class CategoryRepository : ICategoryRepository
    {
        ToysContext _toysContext;
        public CategoryRepository(ToysContext toysContext)
        {
            _toysContext = toysContext;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _toysContext.Categories.ToListAsync();
        }
    }
}
