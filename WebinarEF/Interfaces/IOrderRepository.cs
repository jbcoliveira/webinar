using WebinarEF.Models;

namespace WebinarEF.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    IEnumerable<Order> GetOrdersByCustomer(string customerName);
    Task<IEnumerable<Order>> GetOrdersUsingSplittedQuery();
}