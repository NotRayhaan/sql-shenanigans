using Microsoft.AspNetCore.Mvc;
using NorthwindTrades.Dtos.Analytics;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Mappers;
using NorthwindTrades.Models;

namespace NorthwindTrades.Controllers;

[ApiController]
[Route("[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IOrderRepository _OrderRepository;
    public AnalyticsController(IOrderRepository OrderRepository)
    {
        _OrderRepository = OrderRepository;
    }

    [HttpGet]
    [Route("trades")]
    public async Task<IActionResult> Trades()
    {
        List<Order> orders = await _OrderRepository.GetAllAsync();
        List<TradeDto> tradeDto = orders.SelectMany(s => s.toTradeDto()).ToList();

        return Ok(tradeDto);
    }
}