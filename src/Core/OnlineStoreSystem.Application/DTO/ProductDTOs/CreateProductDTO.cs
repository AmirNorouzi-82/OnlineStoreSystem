using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.ProductDTOs;

public class CreateProductDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int ProductCategoryId { get; set; }
    public bool Is_Available { get; set; }
}
