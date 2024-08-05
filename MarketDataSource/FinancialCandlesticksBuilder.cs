namespace MarketDataSource;

public class FinancialCandlesticksBuilder
{
	public static IList<CandleStick> Build(IList<MarketDataRecord> marketDataRecords)
	{
		var groupedDataRecords = marketDataRecords
			.GroupBy(record => new DateTime(record.Time.Year, record.Time.Month, record.Time.Day, record.Time.Hour,
				record.Time.Minute, 0))
			.OrderBy(group => group.Key);

		var candleSticks = new List<CandleStick>();

		foreach (var group in groupedDataRecords)
		{
			var orderedGroup = group.OrderBy(record => record.Time);
			decimal high = group.Max(record => record.Price);
			decimal low = group.Min(record => record.Price);

			candleSticks.Add(new CandleStick
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