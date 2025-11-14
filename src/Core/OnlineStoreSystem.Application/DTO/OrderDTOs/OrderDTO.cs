using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.DTO.CustomerDTOs;
using OnlineStoreSystem.Application.DTO.OrderItemDTOs;
using OnlineStoreSystem.Application.DTO.OrderStatusDTOs;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.OrderDTOs;

public class OrderDTO
{
    public int CustomerId { get; set; }
    public virtual CustomerDTO Customer { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public required decimal TotalPrice { get; set; }
    public int OrderStatusId { get; set; }
    public OrderStatusDTO OrderStatus { get; set; }


    public virtual ICollection<OrderItemDTO> OrderItems { get; set; }
}
