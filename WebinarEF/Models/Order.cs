using Newtonsoft.Json;

namespace WebinarEF.Models;

public class Order : Entity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}