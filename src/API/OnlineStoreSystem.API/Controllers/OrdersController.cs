using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderRepository.GetOrdersWithDetails();
        return Ok(orders);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderRepository.GetByIdWithDetailsAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        var entity = await _orderRepository.AddAsync(order);
        return Ok(entity);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
    {
        if (id != order.Id)
        {
            return BadRequest("Order ID mismatch");
        }
        await _orderRepository.UpdateAsync(order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _orderRepository.DeleteAsync(id);
        return NoContent();
    }

}
