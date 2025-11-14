using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.Features.ProductFeatures.Handlers.Commands;

internal class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest>
{
    private readonly IProductRepository _repository;

    public DeleteProductRequestHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.DeleteProductDTO.Id);
    }
}
