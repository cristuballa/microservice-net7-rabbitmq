namespace ItemService.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }

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

