using Microsoft.EntityFrameworkCore;

namespace NorthwindTrades.Models;

public class Order
{

    public Guid OrderID { get; set; }
    public int CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int ShipperID { get; set; }
}