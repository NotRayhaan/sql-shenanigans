namespace NorthwindTrades.Dtos.Order;

public class UpdateOrderRequestDto
{
    public int CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public int ShipperID { get; set; }
}
