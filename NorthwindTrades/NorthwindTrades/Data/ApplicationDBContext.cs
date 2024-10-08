using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Models;

namespace NorthwindTrades.Data;
public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }

}

