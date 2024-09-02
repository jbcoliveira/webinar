using MediatR;
using WebinarEFCQRS.Features.Customer.Dtos;

namespace WebinarEFCQRS.Features.Customer.Queries.List;

public record ListCustomerQuery : IRequest<List<CustomerDto>>
{

}