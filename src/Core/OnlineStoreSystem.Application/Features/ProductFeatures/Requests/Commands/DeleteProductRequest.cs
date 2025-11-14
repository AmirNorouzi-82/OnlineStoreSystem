using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.DTO.ProductDTOs;

namespace OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Commands;

public class DeleteProductRequest : IRequest
{
    public DeleteProductDTO DeleteProductDTO { get; set; }
}
