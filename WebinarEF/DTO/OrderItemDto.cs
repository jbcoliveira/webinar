using Swashbuckle.AspNetCore.Annotations;

namespace WebinarEF.DTO;

public record OrderItemDto
{
    [SwaggerSchema(ReadOnly = true)] public int Id { get; set; }

    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}