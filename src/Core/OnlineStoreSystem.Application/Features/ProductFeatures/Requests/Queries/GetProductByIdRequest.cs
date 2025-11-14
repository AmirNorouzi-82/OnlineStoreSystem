using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.DTO.ProductDTOs;

namespace OnlineStoreSystem.Application.Features.ProductFeatures.Requests.Queries;

public class GetProductByIdRequest : IRequest<ProductDTO>
{
    public GetProductByIdDTO GetProductByIdDTO { get; set; }
}
