using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Order;
using NorthwindTrades.Models;
using NorthwindTrades.Services.Orders;

namespace NorthwindTrades.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost]
    public IActionResult CreateOrder(CreateOrderRequest request)
    {
        var order = new Order(
            Guid.NewGuid(),
            request.CustomerId,
            request.EmployeeID,
            request.OrderDate,
            DateTime.UtcNow,
            request.ShipperID
        );

        _orderService.CreateOrder(order);

        var response = new OrderResponse(
            order.OrderId,
            order.CustomerId,
            order.EmployeeId,
            order.OrderDate,
            order.ModifiedDate,
            order.ShipperId
        );
        return CreatedAtAction(
            actionName: nameof(GetOrder),
            routeValues: new { id = order.OrderId },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetOrder(Guid id)
    {
        Order? order = _orderService.GetOrder(id);
        if (order == null) return NotFound();

        var response = new Order(
            order.OrderId,
            order.CustomerId,
            order.EmployeeId,
            order.OrderDate,
            order.ModifiedDate,
            order.ShipperId
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertOrder(Guid id, UpsertOrderRequest request)
    {
        var order = new Order(
            id,
            request.CustomerId,
            request.EmployeeId,
            request.OrderDate,
            DateTime.UtcNow,
            request.ShipperId
        );
        _orderService.UpsertOrder(order);

        // Todo: return 201 if new order created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteOrder(Guid id)
    {
        _orderService.DeleteOrder(id);
        return NoContent();
    }
}