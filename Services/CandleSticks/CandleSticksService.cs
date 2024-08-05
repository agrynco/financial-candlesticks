namespace Services.CandleSticks;

using MarketDataSource;

public class CandleSticksService : ICandleSticksService
{
	private readonly IMarketDataSource _marketDataSource;

	public CandleSticksService(IMarketDataSource marketDataSource)
	{
		_marketDataSource = marketDataSource;
	}

	public CandleSticksGetResponse GetCandleSticks(CandleSticksGetRequest? request)
	{
		return new CandleSticksGetResponse
		{
			CandleSticks = FinancialCandlesticksBuilder.Build(_marketDataSource.GetData(request?.From, request?.To))
		};
	}
}