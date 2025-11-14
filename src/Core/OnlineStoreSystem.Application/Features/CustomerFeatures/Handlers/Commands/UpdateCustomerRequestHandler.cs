using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.Features.CustomerFeatures.Handlers.Commands;

internal class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerRequestHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateCustomerDTO;
        var customer = await _customerRepository.GetAsync(dto.Id);
        if (customer == null)
        {
            customer.Birthdate = dto.Birthdate;
            customer.Phone = dto.Phone;
            customer.Name = dto.Name;
            customer.Family = dto.Family;
            customer.Is_Active = dto.Is_Active;
            await _customerRepository.UpdateAsync(customer);
        }
    }
}
