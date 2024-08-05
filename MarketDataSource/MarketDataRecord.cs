namespace MarketDataSource;

public record MarketDataRecord
{
	public decimal Price { get; init; }
	public int Quantity { get; init; }
	public required DateTime Time { get; init; }
}