namespace WebinarEFCQRS.Features.Customer.Dtos;

public record CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}