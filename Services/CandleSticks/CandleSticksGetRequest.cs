namespace Services.CandleSticks;

public record CandleSticksGetRequest
{
	public DateTime From { get; init; }
	public DateTime To { get; init; }
}