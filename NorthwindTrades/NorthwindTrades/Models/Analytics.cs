namespace NorthwindTrades.Models;

public class Trades
{
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}