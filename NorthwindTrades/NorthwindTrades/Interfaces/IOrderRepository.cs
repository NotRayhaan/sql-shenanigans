
using NorthwindTrades.Dtos.Order;
using NorthwindTrades.Models;

namespace NorthwindTrades.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order> CreateAsync(Order orderModel);
    Task<Order?> UpdateAsync(Guid id, UpdateOrderRequestDto orderDto);
    Task<Order?> DeleteAsync(Guid id);
}