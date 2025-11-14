using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Commands;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.Features.CustomerFeatures.Handlers.Commands;

internal class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerRequestHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var dto = request.CreateCustomerDTO;
        var customer = new Customer()
        {
            Name = dto.Name,
            Family = dto.Family,
            Birthdate = dto.Birthdate,
            Phone = dto.Phone,
            Register_date = dto.Register_date,
            Is_Active = dto.Is_Active
        };
        await _repository.AddAsync(customer);
        dto.Id = customer.Id;
    }
}
