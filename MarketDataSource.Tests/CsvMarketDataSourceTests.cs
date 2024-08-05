namespace MarketDataSource.Tests;

using MarketDataSource;
using FluentAssertions;
using Xunit;

public class CsvMarketDataSourceTests
{
	[Fact]
	public void GetData_WhenFileDoesNotExist_ShouldThrowException()
	{
		// Arrange
		var sut = new CsvMarketDataSource(new CsvMarketDataSourceParams
		{
			FilePath = "nonexistent.csv"
		});

		// Act
		var act = () => sut.GetData();

		// Assert
		act.Should().Throw<FileNotFoundException>();
	}

	[Fact]
	public void GetData_WhenFileExists_ShouldLoadData()
	{
		// Arrange
		string testDataFilePath = TestUtilities.GetTestDataFilePath();
		var sut = new CsvMarketDataSource(new CsvMarketDataSourceParams
		{
			FilePath = testDataFilePath
		});

		// Act
		var data = sut.GetData();

		// Assert
		data.Should().NotBeNull();
		data.Count.Should().BeGreaterThan(0);
	}
}