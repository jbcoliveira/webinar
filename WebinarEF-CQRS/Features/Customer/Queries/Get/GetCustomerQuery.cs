using MediatR;
using WebinarEFCQRS.Features.Customer.Dtos;

namespace WebinarEFCQRS.Features.Customer.Queries.Get;

public record GetCustomerQuery(int Id) : IRequest<CustomerDto>;