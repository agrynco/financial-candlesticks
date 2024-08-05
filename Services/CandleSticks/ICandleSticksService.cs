namespace Services.CandleSticks;

public interface ICandleSticksService
{
	CandleSticksGetResponse GetCandleSticks(CandleSticksGetRequest? request = null);
}