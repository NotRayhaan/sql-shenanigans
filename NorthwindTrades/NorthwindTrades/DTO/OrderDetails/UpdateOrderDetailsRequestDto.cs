namespace NorthwindTrades.Dtos.OrderDetails;

public class UpdateOrderDetailsRequestDto
{
    public int OrderDetailID { get; set; }
    public Guid OrderID { get; set; }
    public int ProductD { get; set; }
    public int Quantity { get; set; }
}
