using Microsoft.EntityFrameworkCore;
using WebinarEF.Data;
using WebinarEF.Interfaces;
using WebinarEF.Models;

namespace WebinarEF.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private static readonly Func<MyDbContext, string, IEnumerable<Order>> CompiledQuery =
        EF.CompileQuery((MyDbContext context, string customerName) =>
            context.Orders.Where(o => o.Customer.Name == customerName));

    public OrderRepository(MyDbContext context) : base(context)
    {
    }

    public IEnumerable<Order> GetOrdersByCustomer(string customerName)
    {
        return CompiledQuery(_context, customerName);
    }

    public Task<IEnumerable<Order>> GetOrdersUsingSplittedQuery()
    {
        var list = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems);


        var listAsSplitQuery = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .AsSplitQuery();
        return Task.FromResult<IEnumerable<Order>>(listAsSplitQuery);
    }

}