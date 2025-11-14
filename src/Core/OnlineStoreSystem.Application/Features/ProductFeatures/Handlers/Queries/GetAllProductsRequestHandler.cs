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

internal class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, ICollection<ProductDTO>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsRequestHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ProductDTO>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();
        if (products is null) return null;
        var list = new List<ProductDTO>();
        foreach (var product in products)
        {
            var dto = new ProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Is_Available = product.Is_Available,
                ProductCategoryId = product.ProductCategoryId,
                StockQuantity = product.StockQuantity,
            };
            list.Add(dto);
        }
        return list;
    }
}
