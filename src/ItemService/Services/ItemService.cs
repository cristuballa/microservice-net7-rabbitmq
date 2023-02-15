using ItemService.Common.Interfaces;
using ItemService.Interfaces;
using ItemService.Models;

namespace ItemService.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await _itemRepository.GetItemAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _itemRepository.GetItemsAsync();
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
           return await _itemRepository.CreateItemAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            await _itemRepository.UpdateItemAsync(item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }

    }
}