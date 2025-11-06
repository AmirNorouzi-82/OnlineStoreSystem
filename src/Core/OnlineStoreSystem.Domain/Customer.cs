using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain.Common;

namespace OnlineStoreSystem.Domain;
public class Customer : BaseDomainEntity
{
    public required string Name { get; set; }
    public required string Family { get; set; }
    public string? Phone { get; set; }
    public DateTime? Birthdate { get; set; }

    public DateTime Register_date { get; set; }
    public bool Is_Active { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
