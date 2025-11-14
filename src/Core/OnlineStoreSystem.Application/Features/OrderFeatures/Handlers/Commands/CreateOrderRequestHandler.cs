using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Commands;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.Features.OrderFeatures.Handlers.Commands;

internal class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderRequestHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var dto = request.CreateOrderDTO;
        var order = new Order
        {
            TotalPrice = dto.TotalPrice,
            CustomerId = dto.CustomerId,
            OrderDate = dto.OrderDate,
            OrderStatusId = dto.OrderStatusId,
        };
        await _orderRepository.AddAsync(order);
        dto.Id = order.Id;
    }
}
