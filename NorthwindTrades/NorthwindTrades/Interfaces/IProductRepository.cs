
using NorthwindTrades.Models;

namespace NorthwindTrades.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    // Task<Product> CreateAsync(Product productModel);
    // Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDto productDto);
    // Task<Product?> DeleteAsync(Guid id);
}