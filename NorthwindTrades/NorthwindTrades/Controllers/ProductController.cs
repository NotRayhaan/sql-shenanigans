using Microsoft.AspNetCore.Mvc;
using NorthwindTrades.Dtos.Product;
using NorthwindTrades.Interfaces;
using NorthwindTrades.Mappers;
using NorthwindTrades.Models;

namespace NorthwindTrades.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        List<Product> product = await _productRepository.GetAllAsync();
        List<ProductDto> productDto = product.Select(s => s.toProductDto()).ToList();

        return Ok(productDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return NotFound();

        return Ok(product.toProductDto());
    }
}