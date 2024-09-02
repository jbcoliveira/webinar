using WebinarEF.Models;

namespace WebinarEF.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer> GetCustomerLazyLoading(int id);
    Task<Customer> GetCustomerEagerLoading(int id);
}