using Interfaces;
using Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Catalog.Controllers;


[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _repository;
    private readonly IPublishEndpoint _publishEndpoint;

    public ItemsController(IItemService repository, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<IEnumerable<ItemResponse>> GetItemsAsync()
    {
        var items = (await _repository.GetItemsAsync())
            .Select(item => item.AsDto());

        return items;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemResponse>> GetItemAsync(Guid id)
    {
        var item = await _repository.GetItemAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        return item.AsDto();
    }

    [HttpPost("create")]
    public async Task<ActionResult<ItemResponse>> CreateItemAsync([FromBody] ItemRequest itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
        };

        Console.WriteLine($"Item {item.Name} was published");
        await _publishEndpoint.Publish(item);

        return Ok();
        // return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, itemDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, ItemRequest itemDto)
    {
        var existingItem = await _repository.GetItemAsync(id);

        if (existingItem is null)
        {
            return NotFound();
        }

        // Item updatedItem = existingItem with
        // {
        //     Name = itemDto.Name,
        //     Price = itemDto.Price
        // };

        // await _repository.UpdateItemAsync(updatedItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItemAsync(Guid id)
    {
        var existingItem = await _repository.GetItemAsync(id);

        if (existingItem is null)
        {
            return NotFound();
        }

        await _repository.DeleteItemAsync(id);

        return NoContent();
    }
}