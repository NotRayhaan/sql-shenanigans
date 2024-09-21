using Microsoft.AspNetCore.Mvc;
using NorthwindTrades.Dtos.Order;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Mappers;
using NorthwindTrades.Models;

namespace NorthwindTrades.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        List<Order> orders = await _orderRepository.GetAllAsync();
        List<OrderDto> orderDto = orders.Select(s => s.toOrderDto()).ToList();

        return Ok(orderDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) return NotFound();

        return Ok(order.toOrderDto());
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto orderDto)
    {
        Order orderModel = orderDto.toOrderFromCreateDto();
        await _orderRepository.CreateAsync(orderModel);

        return CreatedAtAction(
            nameof(GetOrderById),
            new { id = orderModel.OrderID },
            orderModel.toOrderDto()
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderRequestDto updateDto)
    {
        Order? orderModel = await _orderRepository.UpdateAsync(id, updateDto);
        if (orderModel == null) return NotFound();

        return Ok(orderModel.toOrderDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
    {

        Order? order = await _orderRepository.DeleteAsync(id);
        if (order == null) return NotFound();

        return NoContent();
    }
}