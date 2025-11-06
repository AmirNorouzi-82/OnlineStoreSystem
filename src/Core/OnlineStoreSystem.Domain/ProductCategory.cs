using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain.Common;

namespace OnlineStoreSystem.Domain;
public class ProductCategory : BaseDomainEntity
{
    public required string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
