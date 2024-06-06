namespace NorthwindTrades.Models;

public class Order
{

    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    // public DateTime ModifiedDate { get; set; }
    public int ShipperId { get; set; }

    // public Order(int orderId, int customerId, int employeeId, DateTime orderDate, DateTime modifiedDate, int shipperId)
    // {
    //     OrderId = orderId;
    //     CustomerId = customerId;
    //     EmployeeId = employeeId;
    //     OrderDate = orderDate;
    //     ModifiedDate = modifiedDate;
    //     ShipperId = shipperId;
    // }

}