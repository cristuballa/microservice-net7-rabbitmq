using ItemService.Common.Interfaces;
using ItemService.DataAccess;
using ItemService.Models;
using Microsoft.EntityFrameworkCore;

public class ItemRepository : IItemRepository
{
    private readonly ItemDbContext _context;

    public ItemRepository(ItemDbContext context)
    {
        _context = context;
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
        return await _context.Items.Where(i => i.Id == id)?.SingleOrDefaultAsync() ??
            throw new KeyNotFoundException($"Item with id {id} not found");
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task UpdateItemAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var item = await GetItemAsync(id);
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }

}