using MarketDataSource;
using Services.CandleSticks;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddTransient<IMarketDataSource, CsvMarketDataSource>();
builder.Services.AddTransient<CsvMarketDataSourceParams>(_ =>
	new CsvMarketDataSourceParams 
	{
		FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MarketTestData.csv")
	});
builder.Services.AddTransient<ICandleSticksService, CandleSticksService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();