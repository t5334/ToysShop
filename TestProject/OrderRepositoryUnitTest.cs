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
    public class OrderRepositoryUnitTest
    {
        [Fact]
        public async Task AddOrder_ValidOrder_ReturnsOrder()
        {
            // Arrange
            var order = new Order { OrderId = 1, OrderDate = DateTime.Now, OrderSum = 100.50, UserId = 1 };
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var orders = new List<Order>();
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders); 
            var orderRepository = new OrderRepository(mockContext.Object);

            // Act
            var result = await orderRepository.AddOrder(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.OrderId, result.OrderId);
            Assert.Equal(order.OrderSum, result.OrderSum);
            Assert.Equal(order.UserId, result.UserId);
        }
        [Fact]
        public async Task AddOrder_NullOrder_ThrowsArgumentNullException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ToysContext>().Options;
            var mockContext = new Mock<ToysContext>(options);
            var orderRepository = new OrderRepository(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => orderRepository.AddOrder(null));
        }

    }
}
