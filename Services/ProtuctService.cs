using Entities;
using Reposirories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;//_productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _ProductRepository.GetProduct();
        }
    }
}
