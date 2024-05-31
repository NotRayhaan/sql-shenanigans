namespace Northwind.Contracts.Order;

// todo: add created at/ updated at times
public record UpsertOrderRequest(
    Guid CustomerId,
    Guid EmployeeID,
    DateTime OrderDate,
    Guid ShipperID
);