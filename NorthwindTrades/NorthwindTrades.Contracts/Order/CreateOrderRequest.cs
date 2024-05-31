namespace Northwind.Contracts.Order;

public record CreateOrderRequest(
    Guid CustomerId,
    Guid EmployeeID,
    DateTime OrderDate,
    Guid ShipperID
);