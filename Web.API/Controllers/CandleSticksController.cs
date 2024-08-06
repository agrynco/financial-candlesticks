namespace Web.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Services.CandleSticks;

[Route("api/[controller]")]
public class CandleSticksController : ControllerBase
{
	private readonly ICandleSticksService _candleSticksService;

	public CandleSticksController(ICandleSticksService candleSticksService)
	{
		_candleSticksService = candleSticksService;
	}

	[HttpGet]
	public IActionResult Get()
	{
		return Ok(_candleSticksService.GetCandleSticks());
	}
}