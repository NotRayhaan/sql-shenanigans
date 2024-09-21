using NorthwindTrades.Dtos.CreateOrderDetails;
using NorthwindTrades.Dtos.OrderDetails;
using NorthwindTrades.Models;

namespace NorthwindTrades.Mappers;

public static class OrderDetailsMappers
{
    public static OrderDetailsDto ToOrderDetailsDto(this OrderDetails orderDetailsModel)
    {
        return new OrderDetailsDto
        {
            OrderDetailID = orderDetailsModel.OrderDetailID,
            OrderID = orderDetailsModel.OrderID,
            ProductID = orderDetailsModel.ProductID,
            Quantity = orderDetailsModel.Quantity,
            Product = orderDetailsModel.Product.toProductDto()
        };
    }
    public static OrderDetails ToOrderDetailsFromCreateDto(this CreateOrderDetailsDto orderDetailsDto, Guid orderId)
    {
        return new OrderDetails
        {
            OrderID = orderId,
            ProductID = orderDetailsDto.ProductID,
            Quantity = orderDetailsDto.Quantity,
        };
    }
}