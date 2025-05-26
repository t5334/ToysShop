using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Reposirories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class ProductRepositoryUnitTest
    {
        [Fact]
        public async Task GetProduct_ValidRequest_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Toy Car", Price = 10, Description = "A small toy car" },
                new Product { ProductId = 2, ProductName = "Doll", Price = 15, Description = "A beautiful doll" }
            };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            var productRepository = new ProductRepository(mockContext.Object);

            // Act
            var result = await productRepository.GetProduct();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Toy Car", result[0].ProductName);
            Assert.Equal("Doll", result[1].ProductName);
        }
        [Fact]
        public async Task GetProduct_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var products = new List<Product>();
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            var productRepository = new ProductRepository(mockContext.Object);

            // Act
            var result = await productRepository.GetProduct();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
