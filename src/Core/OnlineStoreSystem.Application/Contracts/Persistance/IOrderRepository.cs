using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.Contracts.Persistance;
public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order> GetByIdWithDetailsAsync(int id);
    public Task<IEnumerable<Order>> GetOrdersWithDetails();
}
