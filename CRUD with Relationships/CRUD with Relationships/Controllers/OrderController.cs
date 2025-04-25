using CRUD_with_Relationships.Data;
using CRUD_with_Relationships.Models.Dto;
using CRUD_with_Relationships.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_with_Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var orders = _context.Orders.Include(o => o.Product)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderName = o.OrderName,
                    ProductId = o.ProductId,
                    ProductName = o.Product.Name
                }).ToList();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            var order = _context.Orders.Include(o => o.Product).FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();

            var dto = new OrderDto
            {
                Id = order.Id,
                OrderName = order.OrderName,
                ProductId = order.ProductId,
                ProductName = order.Product.Name
            };

            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<OrderDto> Create(CreateOrderDto dto)
        {
            var order = new Order
            {
                OrderName = dto.OrderName,
                ProductId = dto.ProductId
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            var resultDto = new OrderDto
            {
                Id = order.Id,
                OrderName = order.OrderName,
                ProductId = order.ProductId,
                ProductName = _context.Products.Find(order.ProductId)?.Name
            };

            //return CreatedAtAction(nameof(GetById), new { id = order.Id }, resultDto);
            return Ok(resultDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateOrderDto dto)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            order.OrderName = dto.OrderName;
            order.ProductId = dto.ProductId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
