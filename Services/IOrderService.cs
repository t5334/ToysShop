using Entities;
using DTO;
namespace Services
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrder(OrderDTO order);
    }
}