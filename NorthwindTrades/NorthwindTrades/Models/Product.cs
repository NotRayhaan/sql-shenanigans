
using System.ComponentModel.DataAnnotations;

namespace NorthwindTrades.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal Price { get; set; }
}