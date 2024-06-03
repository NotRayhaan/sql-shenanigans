namespace NorthwindTrades.Models;

public class Order{

    public Guid OrderId{get;}
    public Guid CustomerId{get;}
    public Guid EmployeeId{get;}
    public DateTime OrderDate{get;}
    public DateTime ModifiedDate{get;}
    public Guid ShipperId{get;}

    public Order(Guid orderId, Guid customerId, Guid employeeId, DateTime orderDate, DateTime modifiedDate, Guid shipperId )
    {
        OrderId = orderId;
        CustomerId = customerId;
        EmployeeId = employeeId;
        OrderDate = orderDate;
        ModifiedDate = modifiedDate;
        ShipperId = shipperId;
    }
    
}