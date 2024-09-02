using Microsoft.EntityFrameworkCore.Storage;
using WebinarEF.Data;
using WebinarEF.Interfaces;
using WebinarEF.Repositories;

namespace WebinarEF.UnitOfWork;

public class TestUnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MyDbContext _context;

    private IDbContextTransaction? _objTran;
    private ICustomerRepository _customerRepository;
    private IOrderRepository _orderRepository;
    private IOrderItemRepository _orderItemRepository;

    public ICustomerRepository Customers
    {
        get { return _customerRepository ??= new CustomerRepository(_context); }
    }

    public IOrderRepository Orders
    {
        get { return _orderRepository ??= new OrderRepository(_context); }
    }

    public IOrderItemRepository OrderItems
    {
        get { return _orderItemRepository ??= new OrderItemRepository(_context); }
    }

    public TestUnitOfWork(MyDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void CreateTransaction()
    {
        _objTran = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _objTran?.Commit();
    }

    public void Rollback()
    {
        _objTran?.Rollback();
        _objTran?.Dispose();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }


}