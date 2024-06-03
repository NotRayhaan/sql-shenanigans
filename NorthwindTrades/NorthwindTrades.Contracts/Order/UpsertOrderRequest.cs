namespace Northwind.Contracts.Order;

// todo: add created at/ updated at times
public record UpsertOrderRequest(
    Guid CustomerId,
    Guid EmployeeId,
    DateTime OrderDate,
    Guid ShipperId
);