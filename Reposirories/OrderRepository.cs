using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposirories
{

    public class OrderRepository : IOrderRepository
    {
        ToysContext _toysContext;
        public OrderRepository(ToysContext toysContext)
        {
            _toysContext = toysContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _toysContext.Orders.AddAsync(order);
            await _toysContext.SaveChangesAsync();
            return order;
        }
    }
}
