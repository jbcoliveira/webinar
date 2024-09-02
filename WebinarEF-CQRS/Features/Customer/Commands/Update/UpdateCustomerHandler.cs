using MediatR;
using WebinarEFCQRS.Data;
using WebinarEFCQRS.Features.Customer.Commands.Delete;

namespace WebinarEFCQRS.Features.Customer.Commands.Update;

public class UpdateCustomerHandler(MyDbContext context) : IRequestHandler<UpdateCustomerCommand, int>
{
    public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FindAsync(request.Id);
        if (customer == null) return 0;

        customer.Email = request.Customer.Email;
        customer.Name = request.Customer.Name;
        context.Customers.Update(customer);
        await context.SaveChangesAsync();
        return customer.Id;
    }
}