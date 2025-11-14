using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.Features.CustomerFeatures.Handlers.Commands;

internal class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerRequestHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var dto = request.DeleteCustomerDTO;
        await _customerRepository.DeleteAsync(dto.Id);
    }
}
