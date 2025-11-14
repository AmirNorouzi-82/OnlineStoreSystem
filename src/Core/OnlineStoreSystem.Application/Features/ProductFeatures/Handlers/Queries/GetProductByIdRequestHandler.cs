using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.DTO.ProductDTOs;
using OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Queries;

namespace OnlineStoreSystem.Application.Features.ProductFeatures.Handlers.Queries;

public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDTO>
{
    private readonly IProductRepository _repository;
    public async Task<ProductDTO> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetAsync(request.GetProductByIdDTO.Id);
        if (product == null) return null;
        var dto = new ProductDTO
        {
            Name = product.Name,
            Price = product.Price,
            Id = product.Id,
            Description = product.Description,
            Is_Available = product.Is_Available,
            ProductCategoryId = product.ProductCategoryId,
            StockQuantity = product.StockQuantity,
        };
        return dto;
    }
}
