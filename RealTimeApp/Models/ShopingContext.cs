using Microsoft.EntityFrameworkCore;

namespace RealTimeApp.Models
{
    public class ShopingContext:DbContext
    {
        public DbSet<Product> Product { get; set; }
        public ShopingContext(DbContextOptions<ShopingContext> option):base(option)
        {
            
        }
    }
}
