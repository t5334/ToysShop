using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Reposirories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;



namespace Repositories.Tests
{
    public class CategoryRepositoryTests
    {
        private readonly Mock<DbSet<Category>> _mockCategoryDbSet;
        private readonly Mock<ToysContext> _mockToysContext;
        private readonly List<Category> _categories;

        public CategoryRepositoryTests()
        {
            // Initialize mock data
            _categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Dolls" },
                new Category { CategoryId = 2, CategoryName = "Building Blocks" },
                new Category { CategoryId = 3, CategoryName = "Board Games" }
            };

            // Mock DbSet
            _mockCategoryDbSet = new Mock<DbSet<Category>>();
            var queryableCategories = _categories.AsQueryable();
            _mockCategoryDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(queryableCategories.Provider);
            _mockCategoryDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(queryableCategories.Expression);
            _mockCategoryDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(queryableCategories.ElementType);
            _mockCategoryDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(queryableCategories.GetEnumerator());

            // Mock ToysContext
            _mockToysContext = new Mock<ToysContext>(new DbContextOptions<ToysContext>());
            _mockToysContext.Setup(c => c.Categories).Returns(_mockCategoryDbSet.Object);
        }

        [Fact]
        public async Task GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var repository = new CategoryRepository(_mockToysContext.Object);

            // Act
            var result = await repository.GetCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("Dolls", result[0].CategoryName);
            Assert.Equal("Building Blocks", result[1].CategoryName);
            Assert.Equal("Board Games", result[2].CategoryName);
        }
    }
}
