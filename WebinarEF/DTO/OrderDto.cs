using Swashbuckle.AspNetCore.Annotations;

namespace WebinarEF.DTO;

public record OrderDto
{
    [SwaggerSchema(ReadOnly = true)] public int Id { get; set; }

    public int CustomerId { get; set; }
    public IEnumerable<OrderItemDto> OrderItems { get; set; }
}