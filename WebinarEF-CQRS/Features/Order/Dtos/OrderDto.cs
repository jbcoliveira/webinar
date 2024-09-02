using Swashbuckle.AspNetCore.Annotations;
using WebinarEFCQRS.Features.OrderItem.Dtos;

namespace WebinarEFCQRS.Features.Order.Dtos;

public record OrderDto
{
    [SwaggerSchema(ReadOnly = true)] public int Id { get; set; }

    public int CustomerId { get; set; }
    public IEnumerable<OrderItemDto> OrderItems { get; set; }
}