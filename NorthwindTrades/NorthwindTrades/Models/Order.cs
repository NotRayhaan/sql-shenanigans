
using System.ComponentModel.DataAnnotations;

namespace NorthwindTrades.Models;

public class Order
{
    [Key]
    public Guid OrderID { get; set; }
    public int CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int ShipperID { get; set; }
    public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}