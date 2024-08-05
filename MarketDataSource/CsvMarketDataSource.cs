namespace CsvMarketDataSource;

using System.Globalization;

public class CsvMarketDataSource : IMarketDataSource
{
	private readonly CsvMarketDataSourceParams _marketDataSourceParams;

	public CsvMarketDataSource(CsvMarketDataSourceParams marketDataSourceParams)
	{
		_marketDataSourceParams = marketDataSourceParams;
	}

	public IList<MarketDataRecord> GetData()
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