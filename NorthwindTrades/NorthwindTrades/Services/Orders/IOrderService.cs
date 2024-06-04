using NorthwindTrades.Models;

namespace NorthwindTrades.Services.Orders;

public interface IOrderService
{
    void CreateOrder(Order order);
    void DeleteOrder(Guid id);
    Order? GetOrder(Guid id);
    void UpsertOrder(Order order);
}