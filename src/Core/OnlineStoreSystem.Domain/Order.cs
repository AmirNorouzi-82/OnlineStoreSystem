using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain.Common;

namespace OnlineStoreSystem.Domain;
public class Order : BaseDomainEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public required decimal TotalPrice { get; set; }
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }


    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
