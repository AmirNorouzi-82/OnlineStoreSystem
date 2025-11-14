using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.DTO.OrderDTOs;
using OnlineStoreSystem.Application.DTO.ProductDTOs;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.OrderItemDTOs;

public class OrderItemDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public decimal? Discount { get; set; }


    public virtual OrderDTO Order { get; set; } = null!;
    public virtual ProductDTO Product { get; set; } = null!;
}
