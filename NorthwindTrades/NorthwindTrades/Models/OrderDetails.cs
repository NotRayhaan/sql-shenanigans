using Microsoft.EntityFrameworkCore;

namespace NorthwindTrades.Models;

public class OrderDetails
{

    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public OrderDetails(int orderId, int orderDetailId, int productId, int quantity)
    {
        OrderDetailId = orderDetailId;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

}