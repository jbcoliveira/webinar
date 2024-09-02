using Swashbuckle.AspNetCore.Annotations;

namespace WebinarEFCQRS.Features.OrderItem.Dtos;

public record OrderItemDto
{
    [SwaggerSchema(ReadOnly = true)] public int Id { get; set; }

    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}