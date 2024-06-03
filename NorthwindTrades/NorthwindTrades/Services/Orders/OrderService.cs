using NorthwindTrades.Models;

namespace NorthwindTrades.Services.Orders;

public class OrderService : IOrderService
{
    private static readonly Dictionary<Guid, Order> _orders = new();
    public void CreateOrder(Order order)
    {
        // Todo: repository and store in mysql db
        _orders.Add(order.OrderId, order);
    }


    public Order GetOrder(Guid id)
    {
        // Todo: repository and store in mysql db
        return _orders[id];
    }
    public void UpsertOrder(Order order)
    {
        // Todo: repository and store in mysql db
        _orders[order.OrderId] = order;
    }
    public void DeleteOrder(Guid id)
    {
        // Todo: repository and store in mysql db
        _orders.Remove(id);
    }
}