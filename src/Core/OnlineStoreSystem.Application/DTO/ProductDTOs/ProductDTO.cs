using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.DTO.ProductCategoryDTOs;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.ProductDTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategoryDTO Category { get; set; }
    public bool Is_Available { get; set; }


    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
