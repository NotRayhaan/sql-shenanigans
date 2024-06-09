
using System.ComponentModel.DataAnnotations;

namespace NorthwindTrades.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public String Unit { get; set; } = string.Empty;
    public int Price { get; set; }
}