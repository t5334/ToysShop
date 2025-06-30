using Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Reposirories;
using DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        IMapper _mapper; 
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDTO>> GetCategories()
        {
            List<Category>categories= await _categoryRepository.GetCategories();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        Task<List<Category>> ICategoryService.GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
