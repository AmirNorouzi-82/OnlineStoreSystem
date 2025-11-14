using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.DTO.ProductDTOs;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.ProductCategoryDTOs;

public class ProductCategoryDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<ProductDTO> Products { get; set; }
}
