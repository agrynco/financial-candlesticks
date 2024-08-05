namespace CsvMarketDataSource;

public interface IMarketDataSource
{
	IList<MarketDataRecord> GetData();
}