using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.DTO.CustomerDTOs;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Queries;

namespace OnlineStoreSystem.Application.Features.CustomerFeatures.Handlers.Queries;

internal class GetAllCustomersRequestHandler : IRequestHandler<GetAllCustomersRequest, ICollection<CustomerDTO>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersRequestHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ICollection<CustomerDTO>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync();
        var dtoList = new List<CustomerDTO>();
        foreach (var customer in customers)
        {
            var dto = new CustomerDTO()
            {
                Birthdate = customer.Birthdate,
                Id = customer.Id,
                Family = customer.Family,
                Is_Active = customer.Is_Active,
                Name = customer.Name,
                Phone = customer.Phone,
                Register_date = customer.Register_date,
            };
        }
        return dtoList;
    }
}
