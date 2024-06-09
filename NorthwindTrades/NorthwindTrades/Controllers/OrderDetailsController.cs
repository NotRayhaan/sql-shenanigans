using Microsoft.AspNetCore.Mvc;
using NorthwindTrades.Dtos.OrderDetails;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Mappers;
using NorthwindTrades.Models;

namespace NorthwindTrades.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    public OrderDetailsController(IOrderDetailsRepository orderDetailsRepository)
    {
        _orderDetailsRepository = orderDetailsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderDetails()
    {
        List<OrderDetails> orderDetails = await _orderDetailsRepository.GetAllAsync();
        IEnumerable<OrderDetailsDto> orderDto = orderDetails.Select(s => s.toOrderDetailsDto());

        return Ok(orderDetails);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailsById([FromRoute] int id)
    {
        var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
        if (orderDetails == null) return NotFound();

        return Ok(orderDetails.toOrderDetailsDto());
    }
}