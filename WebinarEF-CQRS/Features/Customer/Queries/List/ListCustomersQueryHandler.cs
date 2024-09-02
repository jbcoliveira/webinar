using MediatR;
using Microsoft.EntityFrameworkCore;
using WebinarEFCQRS.Data;
using WebinarEFCQRS.Features.Customer.Dtos;

namespace WebinarEFCQRS.Features.Customer.Queries.List;



public class ListCustomersQueryHandler(MyDbContext context) : IRequestHandler<ListCustomerQuery, List<CustomerDto>>
{
    public async Task<List<CustomerDto>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
    {
        return await context.Customers
            .Select(p => new CustomerDto
            {
                Email = p.Email,
                Name = p.Name,
                Id = p.Id
            })
            .ToListAsync();
    }
}