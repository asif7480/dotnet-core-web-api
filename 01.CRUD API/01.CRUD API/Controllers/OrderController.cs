using _01.CRUD_API.Data;
using _01.CRUD_API.Models;
using _01.CRUD_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01.CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public OrderController(ApplicationDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var allOrders = context.Orders.ToList();
            return Ok(allOrders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id) 
        {
            var order = context.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder(AddOrderDto addOrderDto)
        {
            var order = new Order() 
            { 
                Name = addOrderDto.Name, 
                Price = addOrderDto.Price, 
                Quantity = addOrderDto.Quantity 
            };

            context.Orders.Add(order);
            context.SaveChanges();

            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var order = context.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }

            order.Name = updateOrderDto.Name;
            order.Price = updateOrderDto.Price;
            order.Quantity = updateOrderDto.Quantity;

            context.SaveChanges();
            return Ok(updateOrderDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id) 
        {
            var order = context.Orders.Find(id);

            if(order is null)
            {
                return NotFound();
            }

            context.Orders.Remove(order);
            context.SaveChanges();

            return Ok($"Order deleted of id: {id}");
        }
    }
}
