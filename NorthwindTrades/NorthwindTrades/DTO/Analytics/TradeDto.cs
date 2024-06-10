namespace NorthwindTrades.Dtos.Analytics;

public class TradeDto
{
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
