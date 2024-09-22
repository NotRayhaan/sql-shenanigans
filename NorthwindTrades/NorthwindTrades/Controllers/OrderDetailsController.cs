using Microsoft.AspNetCore.Mvc;
using NorthwindTrades.Dtos.CreateOrderDetails;
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
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public OrderDetailsController(IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderDetails()
    {
        List<OrderDetails> orderDetails = await _orderDetailsRepository.GetAllAsync();
        List<OrderDetailsDto> orderDetailsDto = orderDetails.Select(s => s.ToOrderDetailsDto()).ToList();

        return Ok(orderDetailsDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailsById([FromRoute] int id)
    {
        var orderDetails = await _orderDetailsRepository.GetByIdAsync(id);
        if (orderDetails == null) return NotFound();

        return Ok(orderDetails.ToOrderDetailsDto());
    }

    [HttpPost("{orderId}")]
    public async Task<IActionResult> Create([FromRoute] Guid orderId, CreateOrderDetailsDto createOrderDetailsDto)
    {
        if (!await _orderRepository.OrderExists(orderId))
        {
            return BadRequest("Order does not exist");
        }

        var orderDetailsModel = createOrderDetailsDto.ToOrderDetailsFromCreateDto(orderId);
        var product = await _productRepository.GetByIdAsync(orderDetailsModel.ProductID);
        if (product != null)
        {
            orderDetailsModel.Product = product;
        }
        else
        {
            return BadRequest("Product does not exist");
        }

        await _orderDetailsRepository.CreateAsync(orderDetailsModel);

        return CreatedAtAction(
            nameof(GetOrderDetailsById),
            new { id = orderDetailsModel.OrderDetailID },
            orderDetailsModel.ToOrderDetailsDto()
        );
    }

    [HttpPut("{orderDetailsId}")]
    public async Task<IActionResult> Update([FromRoute] int orderDetailsId, [FromBody] UpdateOrderDetailsRequestDto updateDto)
    {

        var orderDetailsModel = updateDto.ToOrderDetailsFromUpdateDto();

        var product = await _productRepository.GetByIdAsync(updateDto.ProductID);

        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());

        if (product != null)
        {
            orderDetailsModel.Product = product;
        }
        else
        {
            return BadRequest("Product does not exist");
        }
        var orderDetails = await _orderDetailsRepository.UpdateAsync(orderDetailsId, orderDetailsModel);

        if (orderDetails == null)
        {
            return NotFound("Order Details not found");
        }


        return Ok(orderDetails.ToOrderDetailsDto());
    }
}