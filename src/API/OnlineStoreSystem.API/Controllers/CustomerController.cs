using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _repository.GetAllAsync();
        return Ok(customers);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await _repository.GetAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest();
        }
        customer.Register_date = DateTime.Now;
        await _repository.AddAsync(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }
    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
    {
        if (customer == null || id != customer.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(customer);
        return NoContent();
    }
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
