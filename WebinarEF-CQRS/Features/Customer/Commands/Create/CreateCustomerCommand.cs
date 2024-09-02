using MediatR;

namespace WebinarEFCQRS.Features.Customer.Commands.Create;

public record CreateCustomerCommand(Domain.Customer Customer) : IRequest<int>;