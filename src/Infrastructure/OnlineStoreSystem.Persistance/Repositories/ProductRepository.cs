using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Domain;
using OnlineStoreSystem.Persistance.Contexts;

namespace OnlineStoreSystem.Persistance.Repositories;
internal class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
