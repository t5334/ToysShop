using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Toys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        //[HttpGet]
        //public async Task<Order> Get()
        //{
        //    return await _orderService.AddOrder();
        //}

        // GET api/<OrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<OrderController>
        [HttpPost]
        public async Task<DTO.OrderDTO>  Post([FromBody] DTO.OrderDTO orderDto)
        {
            return await _orderService.AddOrder(orderDto);
        }

        //// PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
