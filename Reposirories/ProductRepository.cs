using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposirories
{
    public class ProductRepository : IProductRepository
    {
        ToysContext _toysContext;

        public ProductRepository(ToysContext toysContext)
        {
            _toysContext = toysContext;
        }
        public async Task<List<Product>> GetProduct()
        {
            return await _toysContext.Products.ToListAsync();
        }
    }
}
