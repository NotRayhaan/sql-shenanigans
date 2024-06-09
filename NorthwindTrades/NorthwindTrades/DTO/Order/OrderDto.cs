using NorthwindTrades.Dtos.OrderDetails;

namespace NorthwindTrades.Dtos.Order;

public class OrderDto
{
    public Guid OrderID { get; set; }
    public int CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int ShipperID { get; set; }
    public List<OrderDetailsDto> OrderDetails { get; set; }
}
