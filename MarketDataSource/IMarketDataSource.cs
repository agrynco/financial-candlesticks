namespace MarketDataSource;

public interface IMarketDataSource
{
	IList<MarketDataRecord> GetData(DateTime? from = null, DateTime? to = null);
}