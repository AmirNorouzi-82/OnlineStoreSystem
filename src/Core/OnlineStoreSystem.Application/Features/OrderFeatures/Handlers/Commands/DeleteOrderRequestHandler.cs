using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.Features.OrderFeatures.Handlers.Commands;

internal class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest>
{
    private readonly IOrderRepository _orderRepository;
    public DeleteOrderRequestHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
    {
        var Id = request.DeleteOrderDTO.Id;
        await _orderRepository.DeleteAsync(Id);
    }
}
