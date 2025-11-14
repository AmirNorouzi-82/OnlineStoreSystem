using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.DTO.OrderDTOs;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.OrderStatusDTOs;

public class OrderStatusDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<OrderDTO> Orders { get; set; }
}
