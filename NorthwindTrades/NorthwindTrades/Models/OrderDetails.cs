using System.ComponentModel.DataAnnotations;

namespace NorthwindTrades.Models;

public class OrderDetails
{
    [Key]
    public int OrderDetailID { get; set; }
    public Guid OrderID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; } = new Product();

}