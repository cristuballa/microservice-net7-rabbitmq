using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
