using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreSystem.Application.DTO.CustomerDTOs;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Commands;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Queries;

namespace OnlineStoreSystem.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _mediator.Send(new GetAllCustomersRequest());
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var request = new GetCustomerByIdRequest { Id = id };
        var dto = await _mediator.Send(request);
        if (dto == null)
            return NotFound();

        return Ok(dto);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO dto)
    {
        if (dto == null)
            return BadRequest();

        dto.Register_date = DateTime.Now;
        await _mediator.Send(new CreateCustomerRequest { CreateCustomerDTO = dto });
        return CreatedAtAction(nameof(GetCustomerById), new { id = dto.Id }, dto);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDTO dto)
    {
        if (dto == null || id != dto.Id)
            return BadRequest();

        var request = new UpdateCustomerRequest { UpdateCustomerDTO = dto };
        await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var dto = new DeleteCustomerDTO { Id = id };
        var request = new DeleteCustomerRequest { DeleteCustomerDTO = dto };
        await _mediator.Send(request);
        return NoContent();
    }

    // اکشن تستی برای بررسی توکن
    [HttpGet("SecureTest")]
    public IActionResult SecureTest()
    {
        return Ok("توکن معتبره و دسترسی مجاز داری ✅");
    }
}