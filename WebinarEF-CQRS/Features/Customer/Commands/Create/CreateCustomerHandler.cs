using MediatR;
using WebinarEFCQRS.Data;

namespace WebinarEFCQRS.Features.Customer.Commands.Create;

public class CreateCustomerHandler(MyDbContext context) : IRequestHandler<CreateCustomerCommand, int>
{
    public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = command.Customer;
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
        return customer.Id;
    }
}