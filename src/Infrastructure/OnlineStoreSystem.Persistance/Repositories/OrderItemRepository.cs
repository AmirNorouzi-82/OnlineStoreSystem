using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Domain;
using OnlineStoreSystem.Persistance.Contexts;

namespace OnlineStoreSystem.Persistance.Repositories;
internal class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    private readonly ApplicationDbContext _context;

    public OrderItemRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
