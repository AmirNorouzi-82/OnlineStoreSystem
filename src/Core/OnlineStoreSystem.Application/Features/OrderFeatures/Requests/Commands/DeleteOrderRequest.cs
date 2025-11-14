using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.DTO.OrderDTOs;

namespace OnlineStoreSystem.Application.Features.OrderFeatures.Requests.Commands;

public class DeleteOrderRequest : IRequest
{
    public DeleteOrderDTO DeleteOrderDTO { get; set; }
}
