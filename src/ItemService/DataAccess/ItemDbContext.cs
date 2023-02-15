using ItemService.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemService.DataAccess
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
