namespace NorthwindTrades.Dtos.Product;

public class ProductDto
{

    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public String Unit { get; set; } = string.Empty;
    public int Price { get; set; }
}
