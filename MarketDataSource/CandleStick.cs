namespace MarketDataSource;

using System.Text.Json.Serialization;

public record CandleStick
{
	public decimal Close { get; set; }
	public DateTime CloseTime { get; set; }
	public decimal High { get; set; }
	public decimal Low { get; set; }
	public decimal Open { get; set; }
	public DateTime OpenTime { get; set; }

	[JsonIgnore]
	public MarketDataRecord[] OriginalMarketDataRecords { get; set; }
}