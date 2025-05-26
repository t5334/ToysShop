using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Reposirories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;



namespace Repositories.Tests
{
    public class CategoryRepositoryTests
    {
        [Fact]
        public async Task GetCategories_ValidRequest_ReturnsAllCategories()
        {
            // Arrange
            var categories = new List<Category>
    {
        new Category { CategoryId = 1, CategoryName = "Dolls" },
        new Category { CategoryId = 2, CategoryName = "Building Blocks" },
        new Category { CategoryId = 3, CategoryName = "Board Games" }
    };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);
            var categoryRepository = new CategoryRepository(mockContext.Object);

            // Act
            var result = await categoryRepository.GetCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("Dolls", result[0].CategoryName);
            Assert.Equal("Building Blocks", result[1].CategoryName);
            Assert.Equal("Board Games", result[2].CategoryName);
        }
        [Fact]
        public async Task GetCategories_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var categories = new List<Category>();
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);
            var categoryRepository = new CategoryRepository(mockContext.Object);

            // Act
            var result = await categoryRepository.GetCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
