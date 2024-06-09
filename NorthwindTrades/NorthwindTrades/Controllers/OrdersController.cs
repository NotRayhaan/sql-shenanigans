using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> GetOrders()
    {
        List<Order> orders = await _context.Orders.ToListAsync();
        IEnumerable<OrderDto> orderDto = orders.Select(s => s.toOrderDto());

        return Ok(orders);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return NotFound();

        return Ok(order.toOrderDto());
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto orderDto)
    {
        Order orderModel = orderDto.toOrderFromCreateDto();

        await _context.Orders.AddAsync(orderModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetOrderById),
            new { id = orderModel.OrderID },
            orderModel.toOrderDto()
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderRequestDto updateDto)
    {
        Order? orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        if (orderModel == null) return NotFound();

        orderModel.CustomerID = updateDto.CustomerID;
        orderModel.EmployeeID = updateDto.EmployeeID;
        orderModel.OrderDate = updateDto.OrderDate;
        orderModel.ModifiedDate = DateTime.UtcNow;
        orderModel.ShipperID = updateDto.ShipperID;

        await _context.SaveChangesAsync();

        return Ok(orderModel.toOrderDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
    {
        Order? orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.OrderID == id);
        if (orderModel == null) return NoContent();

        _context.Orders.Remove(orderModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}