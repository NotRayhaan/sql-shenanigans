using NorthwindTrades.Models;

namespace NorthwindTrades.Services.Orders;

public interface IOrderService
{
    void CreateOrder(Order order);
    void DeleteOrder(int id);
    Order? GetOrder(int id);
    void UpsertOrder(Order order);
}