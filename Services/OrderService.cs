using DTO;
using Entities;
using Reposirories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper=mapper;
        }
        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            Order order1=_mapper.Map<Order>(order);
            Order order2= await _orderRepository.AddOrder(order1);
            return _mapper.Map<OrderDTO>(order2);
        }
    }
}
