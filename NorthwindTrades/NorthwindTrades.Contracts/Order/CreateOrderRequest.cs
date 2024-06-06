namespace Northwind.Contracts.Order;

public record CreateOrderRequest(
    int CustomerId,
    int EmployeeID,
    DateTime OrderDate,
    int ShipperID
);