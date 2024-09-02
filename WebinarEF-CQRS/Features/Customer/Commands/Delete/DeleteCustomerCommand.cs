using MediatR;

namespace WebinarEFCQRS.Features.Customer.Commands.Delete;

public record DeleteCustomerCommand(int Id) : IRequest;