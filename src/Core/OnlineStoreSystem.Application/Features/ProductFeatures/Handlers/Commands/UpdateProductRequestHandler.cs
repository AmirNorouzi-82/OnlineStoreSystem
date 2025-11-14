using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.Features.ProductFeatures.Handlers.Commands;

internal class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest>
{
    private readonly IProductRepository _repository;

    public UpdateProductRequestHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateProductDTO;
        var product = await _repository.GetAsync(dto.Id);
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.ProductCategoryId = dto.ProductCategoryId;
        product.Is_Available = dto.Is_Available;
        product.Name = dto.Name;
        product.StockQuantity = dto.StockQuantity;
        await _repository.UpdateAsync(product);
    }
}
