using Microsoft.EntityFrameworkCore;
using WebinarEF.Data;
using WebinarEF.Interfaces;
using WebinarEF.Models;

namespace WebinarEF.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(MyDbContext context) : base(context)
    {
    }

    public Task<Customer> GetCustomerLazyLoading(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        var orders = customer.Orders;
        return Task.FromResult(customer);
    }

    public async Task<Customer> GetCustomerEagerLoading(int id)
    {
        var customer =  _context.Customers
            .Include(c => c.Orders)
            .ThenInclude(o => o.OrderItems) // Inclui também os OrderItems
            .FirstOrDefault(c => c.Id == id);
        return customer;
    }
}