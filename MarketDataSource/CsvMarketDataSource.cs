namespace MarketDataSource;

using System.Globalization;

public class CsvMarketDataSource : IMarketDataSource
{
	private readonly CsvMarketDataSourceParams _marketDataSourceParams;

	public CsvMarketDataSource(CsvMarketDataSourceParams marketDataSourceParams)
	{
		_marketDataSourceParams = marketDataSourceParams;
	}

	public IList<MarketDataRecord> GetData(DateTime? from = null, DateTime? to = null)
	{
		var records = new List<MarketDataRecord>();
		using var reader = new StreamReader(_marketDataSourceParams.FilePath);
		bool isHeader = true;
		while (reader.ReadLine() is { } line)
		{
			if (isHeader)
			{
				isHeader = false;
				continue;
			}

			MarketDataRecord record = ParseCsvToMarketDataRecord(line);

			if (from.HasValue && record.Time < from.Value) 
				continue;

			if (to.HasValue && record.Time > to.Value) 
				continue;

			records.Add(record);
		}

		return records;
	}
	private MarketDataRecord ParseCsvToMarketDataRecord(string csvLine)
	{
		string[] fields = csvLine.Split(_marketDataSourceParams.Delimiter);
		return new MarketDataRecord
		{
			Time = DateTime.ParseExact(fields[0], "dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture),
			Quantity = int.Parse(fields[1]),
			Price = decimal.Parse(fields[2], CultureInfo.InvariantCulture)
		};
	}
}