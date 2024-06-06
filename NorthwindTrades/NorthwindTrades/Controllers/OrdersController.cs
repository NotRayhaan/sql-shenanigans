using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Order;
using NorthwindTrades.Data;
using NorthwindTrades.Models;
using NorthwindTrades.Services.Orders;

namespace NorthwindTrades.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public OrdersController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        List<Order> orders = _context.Orders.ToList();
        return Ok(orders);
    }
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Order? order = _context.Orders.Find(id);
        if (order == null) return NotFound();

        // var response = new Order(
        //     order.OrderId,
        //     order.CustomerId,
        //     order.EmployeeId,
        //     order.OrderDate,
        //     order.ModifiedDate,
        //     order.ShipperId
        // );
        return Ok(order);
    }
    // [HttpPost]
    // public IActionResult CreateOrder(CreateOrderRequest request)
    // {
    //     var order = new Order(
    //         Guid.NewGuid(),
    //         request.CustomerId,
    //         request.EmployeeID,
    //         request.OrderDate,
    //         DateTime.UtcNow,
    //         request.ShipperID
    //     );

    //     _orderService.CreateOrder(order);

    //     var response = new OrderResponse(
    //         order.OrderId,
    //         order.CustomerId,
    //         order.EmployeeId,
    //         order.OrderDate,
    //         order.ModifiedDate,
    //         order.ShipperId
    //     );
    //     return CreatedAtAction(
    //         actionName: nameof(GetOrder),
    //         routeValues: new { id = order.OrderId },
    //         value: response);
    // }

    // [HttpPut("{id:guid}")]
    // public IActionResult UpsertOrder(Guid id, UpsertOrderRequest request)
    // {
    //     var order = new Order(
    //         id,
    //         request.CustomerId,
    //         request.EmployeeId,
    //         request.OrderDate,
    //         DateTime.UtcNow,
    //         request.ShipperId
    //     );
    //     _orderService.UpsertOrder(order);

    //     // Todo: return 201 if new order created
    //     return NoContent();
    // }

    // [HttpDelete("{id:guid}")]
    // public IActionResult DeleteOrder(Guid id)
    // {
    //     _orderService.DeleteOrder(id);
    //     return NoContent();
    // }
}