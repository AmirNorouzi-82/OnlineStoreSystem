using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain.Common;

namespace OnlineStoreSystem.Domain;
public class OrderStatus : BaseDomainEntity
{
    public required string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}
