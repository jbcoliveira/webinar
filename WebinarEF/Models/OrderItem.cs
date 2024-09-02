using Newtonsoft.Json;

namespace WebinarEF.Models;

public class OrderItem : Entity
{
    public int OrderId { get; set; }

    [JsonIgnore]
    public virtual Order Order { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}