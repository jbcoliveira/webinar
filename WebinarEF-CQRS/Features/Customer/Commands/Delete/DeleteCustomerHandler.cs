using MediatR;
using WebinarEFCQRS.Data;

namespace WebinarEFCQRS.Features.Customer.Commands.Delete;

public class DeleteCustomerHandler(MyDbContext context) : IRequestHandler<DeleteCustomerCommand>
{
    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FindAsync(request.Id);
        if (customer == null) return;
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
    }
}