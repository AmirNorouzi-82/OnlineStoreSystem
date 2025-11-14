using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.Features.OrderFeatures.Handlers.Commands;

internal class UpdateOrderRequestHandler : IRequestHandler<UpdateOrderRequest>
{
    private readonly IOrderRepository _orderRepository;
    public UpdateOrderRequestHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateOrderDTO;
        var order = await _orderRepository.GetAsync(dto.Id);
        if (order == null)
        {
            order.OrderDate = dto.OrderDate;
            order.OrderStatusId = dto.OrderStatusId;
            order.CustomerId = dto.CustomerId;
            order.TotalPrice = dto.TotalPrice;
        }
        await _orderRepository.UpdateAsync(order);
    }
}
