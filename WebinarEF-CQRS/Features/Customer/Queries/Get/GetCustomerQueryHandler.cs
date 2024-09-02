using MediatR;
using WebinarEFCQRS.Data;
using WebinarEFCQRS.Features.Customer.Dtos;

namespace WebinarEFCQRS.Features.Customer.Queries.Get;

public class GetCustomerQueryHandler(MyDbContext context) : IRequestHandler<GetCustomerQuery, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Customers.FindAsync(request.Id);
        if (product == null)
        {
            return null;
        }

        return new CustomerDto
        {
            Id = product.Id,
            Name = product.Name,
            Email = product.Email
        };
    }
}