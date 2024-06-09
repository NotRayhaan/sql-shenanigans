using NorthwindTrades.Dtos.OrderDetails;
using NorthwindTrades.Models;

namespace NorthwindTrades.Mappers;

public static class OrderDetailsMappers
{
    public static OrderDetailsDto toOrderDetailsDto(this OrderDetails orderDetailsModel)
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
    public static OrderDetails toOrderDetailsFromCreateDto(this CreateOrderDetailsRequestDto orderDetailsDto)
    {
        return new OrderDetails
        {
            OrderID = orderDetailsDto.OrderID,
            ProductID = orderDetailsDto.ProductID,
            Quantity = orderDetailsDto.Quantity,
        };
    }
}