namespace WebinarEFCQRS.Domain;

public class OrderItem : Entity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}