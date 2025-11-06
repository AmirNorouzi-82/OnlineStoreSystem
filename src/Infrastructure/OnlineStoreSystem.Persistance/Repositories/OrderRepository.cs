using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStoreSystem.Application.Contracts.Persistance;
using OnlineStoreSystem.Domain;
using OnlineStoreSystem.Persistance.Contexts;

namespace OnlineStoreSystem.Persistance.Repositories;
internal class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order> GetByIdWithDetailsAsync(int id)
    {
        var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersWithDetails()
    {
        return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
    }
}
