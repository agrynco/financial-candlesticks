namespace CsvMarketDataSource;

public record FinancialCandlestick
{
	public DateTime OpenTime { get; set; }
	public DateTime CloseTime { get; set; }
	public decimal Open { get; set; }
	public decimal Close { get; set; }
	public decimal High { get; set; }
	public decimal Low { get; set; }
	
	public MarketDataRecord[] OriginalMarketDataRecords { get; set; }
	
}