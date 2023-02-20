namespace OrderService;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public float Price { get; set; }
    public string Description { get; set; } = default!;
}