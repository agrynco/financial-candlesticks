namespace CsvMarketDataSource;

public class FinancialCandlesticksBuilder
{
	public List<FinancialCandlestick> Build(IList<MarketDataRecord> marketDataRecords)
	{
		var groupedDataRecords = marketDataRecords
			.GroupBy(record => new DateTime(record.Time.Year, record.Time.Month, record.Time.Day, record.Time.Hour,
				record.Time.Minute, 0))
			.OrderBy(group => group.Key);

		var candleSticks = new List<FinancialCandlestick>();

		foreach (var group in groupedDataRecords)
		{
			var orderedGroup = group.OrderBy(record => record.Time);
			var high = group.Max(record => record.Price);
			var low = group.Min(record => record.Price);

			candleSticks.Add(new FinancialCandlestick
			{
				OpenTime = group.Key,
				CloseTime = group.Key.AddMinutes(1),
				Open = orderedGroup.First().Price,
				Close = orderedGroup.Last().Price,
				High = high,
				Low = low,
				
				OriginalMarketDataRecords = orderedGroup.ToArray()
			});
		}

		return candleSticks;
	}
}