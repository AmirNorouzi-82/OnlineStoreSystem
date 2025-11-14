using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.DTO.ProductDTOs;
using OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Commands;
using OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Queries;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _mediator.Send(new GetAllProductsRequest());
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var dto = new GetProductByIdDTO { Id = id };
        var product = await _mediator.Send(new GetProductByIdRequest { GetProductByIdDTO = dto });
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO dto)
    {
        await _mediator.Send(new CreateProductRequest { CreateProductDTO = dto });
        return CreatedAtAction(nameof(GetProductById), new { id = dto.Id }, dto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("Product ID mismatch");
        }
        await _mediator.Send(new UpdateProductRequest { UpdateProductDTO = dto });
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _mediator.Send(new DeleteProductRequest { DeleteProductDTO = new DeleteProductDTO { Id = id } });
        return NoContent();
    }
}
