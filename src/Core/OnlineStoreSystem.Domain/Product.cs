using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain.Common;

namespace OnlineStoreSystem.Domain;
public class Product : BaseDomainEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory Category { get; set; }
    public bool Is_Available { get; set; }


    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
