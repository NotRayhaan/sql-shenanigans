using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Order;

namespace NorthwindTrades.Controllers;

[ApiController]
    [Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost("")]
    public IActionResult CreateOrder(CreateOrderRequest request){
        return Ok(request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetOrder(Guid id){
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertOrder(Guid id, UpsertOrderRequest request){
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteOrder(Guid id){
        return Ok(id);
    }
}