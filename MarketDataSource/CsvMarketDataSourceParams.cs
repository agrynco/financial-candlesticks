namespace MarketDataSource;

public record CsvMarketDataSourceParams
{
	public char Delimiter { get; init; } = ',';
	public string FilePath { get; init; }
}