namespace Northwind.Contracts.Order;

// todo: add created at/ updated at times and order id (use auto increment)
public record OrderResponse(
    Guid OrderCustomerId,
    Guid CustomerId,
    Guid EmployeeID,
    DateTime OrderDate,
    DateTime ModifiedDate,
    Guid ShipperID
);