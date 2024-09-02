using MediatR;

namespace WebinarEFCQRS.Features.Customer.Commands.Update;

public record UpdateCustomerCommand(int Id, Domain.Customer Customer) : IRequest<int>;