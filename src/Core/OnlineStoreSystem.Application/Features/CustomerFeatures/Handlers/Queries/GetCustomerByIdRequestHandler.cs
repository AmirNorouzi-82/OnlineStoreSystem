using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.DTO.CustomerDTOs;
using OnlineStoreSystem.Application.DTO.OrderDTOs;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Queries;

namespace OnlineStoreSystem.Application.Features.CustomerFeatures.Handlers.Queries;

internal class GetCustomerByIdRequestHandler : IRequestHandler<GetCustomerByIdRequest, CustomerDTO>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdRequestHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDTO> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id);
        if (customer == null)
        {
            var dto = new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name,
                Family = customer.Family,
                Birthdate = customer.Birthdate,
                Is_Active = customer.Is_Active,
                Phone = customer.Phone,
                Register_date = customer.Register_date,
            };
            dto.Orders = new List<OrderDTO>();
            foreach (var order in customer.Orders) 
            {
                var orderDTO = new OrderDTO()
                {
                    TotalPrice = order.TotalPrice,
                    Customer = dto,
                    CustomerId = order.CustomerId,
                    OrderDate = order.OrderDate,
                    OrderStatusId = order.OrderStatusId
                };
                dto.Orders.Add(orderDTO);
            }
            return dto;

        }
        return null;
    }
}
