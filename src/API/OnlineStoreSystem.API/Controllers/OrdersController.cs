using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.DTO.OrderDTOs;
using OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Commands;
using OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Queries;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _mediator.Send(new GetAllOrdersWithDetailsRequest());
        return Ok(orders);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var dto = await _mediator.Send(new GetOrderByIdWithDetailsRequest { Id = id });
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
    {
        var request = new CreateOrderRequest { CreateOrderDTO = dto };
        await _mediator.Send(request);
        return Ok(dto);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("Order ID mismatch");
        }
        dto.Id = id;
        await _mediator.Send(new UpdateOrderRequest { UpdateOrderDTO = dto });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _mediator.Send(new DeleteOrderRequest { DeleteOrderDTO = new DeleteOrderDTO { Id = id } });
        return NoContent();
    }

}
