using CsvMarketDataSource;
using FluentAssertions;
using MarketDataSource.Tests;
using Xunit;

public class FinancialCandlesticksBuilderTests
{
	private readonly FinancialCandlesticksBuilder _builder;
					 
	public FinancialCandlesticksBuilderTests()
	{
		// Initialize the FinancialCandlesticksBuilder here.
		// You might want to use a mocking framework if appropriate.
		_builder = new FinancialCandlesticksBuilder();
	}

	[Fact]
	public void Build_ShouldCreateCandlesticks_WhenMarketDataIsReadFromCSV()
	{
		// Arrange
		string testDataFilePath = TestUtilities.GetTestDataFilePath();
		var sut = new CsvMarketDataSource.CsvMarketDataSource(new CsvMarketDataSourceParams
		{
			FilePath = testDataFilePath
		});
		
		IList<MarketDataRecord> marketDataRecords = sut.GetData();

		var builder = new FinancialCandlesticksBuilder();

		// Act
		var result = builder.Build(marketDataRecords);

		// Assert
		result.Should().NotBeNull();
		result.Count.Should().BeGreaterThan(0);
	}
}