namespace Services.CandleSticks;

using MarketDataSource;

public record CandleSticksGetResponse
{
	public IList<CandleStick> CandleSticks { get; init; }
}