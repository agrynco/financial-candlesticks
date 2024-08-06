using MarketDataSource;
using Services.CandleSticks;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins",
		builder => builder.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod());
});

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

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseHttpsRedirection();

app.Urls.Add("http://localhost:5000");
app.Run();