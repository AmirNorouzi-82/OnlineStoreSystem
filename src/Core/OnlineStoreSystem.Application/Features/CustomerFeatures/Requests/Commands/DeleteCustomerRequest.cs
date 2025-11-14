using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.DTO.CustomerDTOs;

namespace OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Commands;

public class DeleteCustomerRequest : IRequest
{
    public DeleteCustomerDTO DeleteCustomerDTO { get; set; }
}
