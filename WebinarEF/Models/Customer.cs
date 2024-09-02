namespace WebinarEF.Models;

public class Customer : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}