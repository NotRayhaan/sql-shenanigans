namespace Northwind.Contracts.Order;

// todo: add created at/ updated at times
public record UpsertOrderRequest(
    int CustomerId,
    int EmployeeId,
    DateTime OrderDate,
    int ShipperId
);