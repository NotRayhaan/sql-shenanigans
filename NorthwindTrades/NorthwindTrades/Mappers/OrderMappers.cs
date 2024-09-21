using NorthwindTrades.Dtos.Analytics;
using NorthwindTrades.Dtos.Order;
using NorthwindTrades.Models;

namespace NorthwindTrades.Mappers;

public static class OrderMappers
{
    public static OrderDto toOrderDto(this Order orderModel)
    {
        return new OrderDto
        {
            OrderID = orderModel.OrderID,
            CustomerID = orderModel.CustomerID,
            EmployeeID = orderModel.EmployeeID,
            OrderDate = orderModel.OrderDate,
            ModifiedDate = orderModel.ModifiedDate,
            ShipperID = orderModel.ShipperID,
            OrderDetails = orderModel.OrderDetails.Select(c => c.ToOrderDetailsDto()).ToList()
        };
    }
    public static Order toOrderFromCreateDto(this CreateOrderRequestDto orderDto)
    {
        return new Order
        {
            OrderID = Guid.NewGuid(),
            CustomerID = orderDto.CustomerID,
            EmployeeID = orderDto.EmployeeID,
            ModifiedDate = DateTime.UtcNow,
            OrderDate = orderDto.OrderDate,
            ShipperID = orderDto.ShipperID,
        };
    }
    /// TODO put into analytics
    public static List<TradeDto> toTradeDto(this Order orderModel)
    {
        return orderModel.OrderDetails.Select(orderDetails =>
        new TradeDto
        {
            OrderDate = orderModel.OrderDate,
            Quantity = orderDetails.Quantity,
            Price = orderDetails.Product.Price,
        }
        ).ToList();
    }
}