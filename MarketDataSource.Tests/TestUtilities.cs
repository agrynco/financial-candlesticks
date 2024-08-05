using System.Reflection;

namespace MarketDataSource.Tests;

public static class TestUtilities
{
	public static string GetTestDataFilePath()
	{
		var assembly = Assembly.GetExecutingAssembly();
		using Stream? stream = assembly.GetManifestResourceStream("MarketDataSource.Tests.MarketTestData.csv");
		using var reader = new StreamReader(stream);
		string testData = reader.ReadToEnd();
		string tempFilePath = Path.GetTempFileName();
		File.WriteAllText(tempFilePath, testData);
		return tempFilePath;
	}
}