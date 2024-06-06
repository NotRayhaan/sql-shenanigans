namespace Northwind.Contracts.Order;

// todo: add created at/ updated at times and order id (use auto increment)
public record OrderResponse(
    int OrderCustomerId,
    int CustomerId,
    int EmployeeID,
    DateTime OrderDate,
    DateTime ModifiedDate,
    int ShipperID
);