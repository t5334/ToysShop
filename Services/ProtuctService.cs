using Entities;
using Reposirories;
using DTO;
using AutoMapper
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;
        IMapper _Mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
           List<Product> products= await _ProductRepository.GetProduct();
            return _Mapper.Map<List<ProductDTO>>(products);
        }
    }
}
