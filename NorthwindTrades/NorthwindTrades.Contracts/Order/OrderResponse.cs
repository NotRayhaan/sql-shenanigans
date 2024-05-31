namespace Northwind.Contracts.Order;

// todo: add created at/ updated at times and order id (use auto increment)
public record OrderResponse(
    Guid CustomerId,
    Guid EmployeeID,
    DateTime OrderDate,
    Guid ShipperID
);