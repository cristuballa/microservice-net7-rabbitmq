
using ItemService.Models;

namespace ItemService.Common.Interfaces;
public interface IItemRepository
{
    Task<Item> GetItemAsync(Guid id);
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item> CreateItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);
}