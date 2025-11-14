using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Commands;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.Features.ProductFeatures.Handlers.Commands;

internal class CreateProductRequestHandler : IRequestHandler<CreateProductRequest>
{
    private readonly IProductRepository _repository;

    public CreateProductRequestHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var dto = request.CreateProductDTO;
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Is_Available = dto.Is_Available,
            Description = dto.Description,
            ProductCategoryId = dto.ProductCategoryId,
            StockQuantity = dto.StockQuantity
        };
        await _repository.AddAsync(product);
        dto.Id = product.Id;
    }
}
