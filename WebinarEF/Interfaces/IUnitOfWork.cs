namespace WebinarEF.Interfaces;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }
    IOrderRepository Orders { get; }
    IOrderItemRepository OrderItems { get; }

    void CreateTransaction();

    void Commit();

    void Rollback();

    Task Save();
}