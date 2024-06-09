using NorthwindTrades.Dtos.Product;
using NorthwindTrades.Models;

namespace NorthwindTrades.Mappers;

public static class ProductMappers
{
    public static ProductDto toProductDto(this Product productModel)
    {
        return new ProductDto
        {
            ProductID = productModel.ProductID,
            ProductName = productModel.ProductName,
            SupplierID = productModel.SupplierID,
            CategoryID = productModel.CategoryID,
            Unit = productModel.Unit,
            Price = productModel.Price,
        };
    }
}