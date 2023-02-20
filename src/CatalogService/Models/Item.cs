using Contracts;

namespace Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public float Price { get; set; }
    public string Description { get; set; } = default!;

    public ItemResponse AsDto()
    {
        return new ItemResponse(
            Id,
            Description,
            Name,
            Price
        );
    }

}

