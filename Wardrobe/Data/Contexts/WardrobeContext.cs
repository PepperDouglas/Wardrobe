using Microsoft.EntityFrameworkCore;
using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Contexts
{
    public class WardrobeContext : DbContext
    {
        public WardrobeContext(DbContextOptions<WardrobeContext> options) : base(options) {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
