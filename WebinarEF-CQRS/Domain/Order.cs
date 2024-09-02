namespace WebinarEFCQRS.Domain;

public class Order : Entity
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}