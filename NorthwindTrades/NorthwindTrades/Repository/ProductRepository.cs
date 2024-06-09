using Microsoft.EntityFrameworkCore;
using NorthwindTrades.Data;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Models;

namespace NorthwindTrades.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDBContext _context;
    public ProductRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

}