using ECommercePlatform.Data;
using ECommercePlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public OrderProductsController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/OrderProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderProduct>>> GetOrderProducts()
        {
            return await _context.OrderProducts.Include(op => op.Product).Include(op => op.Order).ToListAsync();
        }

        // GET: api/OrderProducts/5
        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderProduct>> GetOrderProduct(Guid orderId, Guid productId)
        {
            var orderProduct = await _context.OrderProducts
                .Include(op => op.Product)
                .Include(op => op.Order)
                .FirstOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);

            if (orderProduct == null)
            {
                return NotFound();
            }

            return orderProduct;
        }

        // POST: api/OrderProducts
        [HttpPost]
        public async Task<ActionResult<OrderProduct>> PostOrderProduct(OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderProduct), new { orderId = orderProduct.OrderId, productId = orderProduct.ProductId }, orderProduct);
        }

        // DELETE: api/OrderProducts/5
        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderProduct(Guid orderId, Guid productId)
        {
            var orderProduct = await _context.OrderProducts
                .FirstOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);
            if (orderProduct == null)
            {
                return NotFound();
            }

            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
