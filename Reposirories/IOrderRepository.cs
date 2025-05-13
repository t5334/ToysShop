using Entities;

namespace Reposirories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
    }
}