using WebinarEF.Data;
using WebinarEF.Interfaces;
using WebinarEF.Models;

namespace WebinarEF.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(MyDbContext context) : base(context)
    {
    }
}