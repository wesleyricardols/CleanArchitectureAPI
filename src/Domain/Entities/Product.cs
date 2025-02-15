namespace Domain.Entities;

public class Product(string name, decimal price) : BaseEntity
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}