
using NorthwindTrades.Models;

namespace NorthwindTrades.Interfaces;

public interface IOrderDetailsRepository
{
    Task<List<OrderDetails>> GetAllAsync();
    Task<OrderDetails?> GetByIdAsync(int id);
    // Task<OrderDetails> CreateAsync(OrderDetails orderDetailsModel);
    // Task<OrderDetails?> UpdateAsync(int id, UpdateOrderDetailsRequestDto orderDetailsDto);
    // Task<OrderDetails?> DeleteAsync(int id);
}