using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.DTO.CustomerDTOs;
using OnlineStoreSystem.Application.DTO.OrderDTOs;
using OnlineStoreSystem.Application.DTO.OrderItemDTOs;
using OnlineStoreSystem.Application.DTO.OrderStatusDTOs;
using OnlineStoreSystem.Application.DTO.ProductCategoryDTOs;
using OnlineStoreSystem.Application.DTO.ProductDTOs;
using OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Queries;

namespace OnlineStoreSystem.Application.Features.OrderFeatures.Handlers.Queries;

internal class GetAllOrdersWithDetailsRequestHandler : IRequestHandler<GetAllOrdersWithDetailsRequest, ICollection<OrderDTO>>
{
    private readonly IOrderRepository _repository;

    public GetAllOrdersWithDetailsRequestHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<OrderDTO>> Handle(GetAllOrdersWithDetailsRequest request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetOrdersWithDetails();
        var list = new List<OrderDTO>();
        foreach (var order in orders)
        {
            var dto = new OrderDTO
            {
                TotalPrice = order.TotalPrice,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderStatusId = order.OrderStatusId,
                Customer = new CustomerDTO
                {
                    Id = order.CustomerId,
                    Birthdate = order.Customer.Birthdate,
                    Family = order.Customer.Family,
                    Is_Active = order.Customer.Is_Active,
                    Name = order.Customer.Name,
                    Phone = order.Customer.Phone,
                    Register_date = order.Customer.Register_date,
                },
                OrderItems = new List<OrderItemDTO>(),
                OrderStatus = new OrderStatusDTO
                {
                    Name = order.OrderStatus.Name,
                    Id = order.OrderStatus.Id
                }
            };
            foreach (var item in order.OrderItems)
            {
                var itemDTO = new OrderItemDTO
                {
                    UnitPrice = item.UnitPrice,
                    Discount = item.Discount,
                    Id = item.Id,
                    Order = dto,
                    OrderId = item.OrderId,
                    Product = new ProductDTO 
                    {
                        Name = item.Product.Name,
                        Price = item.Product.Price,
                        Id = item.ProductId,
                        Category = new ProductCategoryDTO
                        {
                            Name = item.Product.Category.Name,
                            Id = item.Product.Category.Id
                        }
                    },
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };
                dto.OrderItems.Add(itemDTO);
            }

            list.Add(dto);
        }
        return list;
    }
}
