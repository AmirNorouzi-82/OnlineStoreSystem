using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.OrderDTOs;

public class CreateOrderDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public required decimal TotalPrice { get; set; }
    public int OrderStatusId { get; set; }
}