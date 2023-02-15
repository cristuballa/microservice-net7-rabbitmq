using ItemService.Models;

namespace ItemService.Interfaces;

    public interface IItemService
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task  DeleteItemAsync(Guid id);
    }
