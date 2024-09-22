
using NorthwindTrades.Models;

namespace NorthwindTrades.Interfaces;

public interface IOrderDetailsRepository
{
    Task<List<OrderDetails>> GetAllAsync();
    Task<OrderDetails?> GetByIdAsync(int id);
    Task<OrderDetails> CreateAsync(OrderDetails orderDetailsModel);
    Task<OrderDetails?> UpdateAsync(int id, OrderDetails orderDetailsModel);
    Task<OrderDetails?> DeleteAsync(int id);
}