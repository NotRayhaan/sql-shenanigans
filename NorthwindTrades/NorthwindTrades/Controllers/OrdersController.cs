using Microsoft.AspNetCore.Mvc;
using NorthwindTrades.Data;
using NorthwindTrades.Dtos.Order;
using NorthwindTrades.Mappers;
using NorthwindTrades.Models;

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
        IEnumerable<OrderDto> orders = _context.Orders.ToList().Select(s => s.toOrderDto());
        return Ok(orders);
    }
    [HttpGet("{id}")]
    public IActionResult GetOrderById([FromRoute] Guid id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();

        return Ok(order.toOrderDto());
    }
    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequestDto orderDto)
    {
        Order orderModel = orderDto.toOrderFromCreateDto();

        _context.Orders.Add(orderModel);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetOrderById),
            new { id = orderModel.OrderID },
            orderModel.toOrderDto()
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderRequestDto updateDto)
    {
        Order? orderModel = _context.Orders.FirstOrDefault(x => x.OrderID == id);
        if (orderModel == null) return NotFound();

        orderModel.CustomerID = updateDto.CustomerID;
        orderModel.EmployeeID = updateDto.EmployeeID;
        orderModel.OrderDate = updateDto.OrderDate;
        orderModel.ModifiedDate = DateTime.UtcNow;
        orderModel.ShipperID = updateDto.ShipperID;

        _context.SaveChanges();

        return Ok(orderModel.toOrderDto());
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder([FromRoute] Guid id)
    {
        Order? orderModel = _context.Orders.FirstOrDefault(x => x.OrderID == id);
        if (orderModel == null) return NoContent();

        _context.Orders.Remove(orderModel);
        _context.SaveChanges();

        return NoContent();
    }
}