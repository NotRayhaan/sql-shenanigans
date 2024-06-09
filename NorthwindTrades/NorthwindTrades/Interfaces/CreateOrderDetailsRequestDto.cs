namespace NorthwindTrades.Dtos.OrderDetails;

public class CreateOrderDetailsRequestDto
{
    public int OrderDetailID { get; set; }
    public Guid OrderID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
}
